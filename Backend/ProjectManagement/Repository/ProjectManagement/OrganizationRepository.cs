using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using Common.Sort_Pag_Flt;
using DAL.Entities;
using Model.Common.ProjectManagement;
using Repository.Common;
using Repository.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.ProjectManagement
{
    public class OrganizationRepository : IOrganizationRepositroy
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrganizationRepository(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization)
        {
            var newOrganization = mapper.Map<Organization>(organization);

            if (string.IsNullOrWhiteSpace(newOrganization.Name))
            {
                throw new AppException("Organization name is required");
            }


            IPaging paging = new Paging
            {
                PageNumber = 0,
                PageSize = 0,
                TotalPages = 0,
            };

            var allOrganizations = await unitOfWork.OrganizationRepository.Get(paging, null, null, null, null, "");
            if (allOrganizations.Any(o => o.Name == organization.Name))
            {
                throw new AppException("Organization name \"" + newOrganization.Name + "\" is already taken");
            }

            newOrganization.Id = Guid.NewGuid();
            newOrganization.Abrv = organization.Name.ToLower();
            newOrganization.DateCreated = DateTime.Now;
            newOrganization.DateUpdated = DateTime.Now;
            newOrganization.UserId = userId;

            var organizationRole = new OrganizationRole
            {
                Id = Guid.NewGuid(),
                DateUpdated = DateTime.Now,
                DateCreated = DateTime.Now,
                Name = Role.User,
                Abrv = Role.User,
                UserId = userId,
                OrganizationId = newOrganization.Id,       
            };


            await unitOfWork.OrganizationRepository.Create(newOrganization);
            await unitOfWork.OrganizationRoleRepository.Create(organizationRole);
            await unitOfWork.SaveAsync();

            return mapper.Map<IOrganizationModel>(newOrganization);
        }
       

        public async Task<IEnumerable<IOrganizationModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            var allOrganizations = await unitOfWork.OrganizationRepository.Get(pagingObj, filter: w => w.UserId == Guid.Parse(filterObj.FilterValue), sortObj, orderBy: q => q.OrderByDescending(d => d.Name),
                orderByDescending: q => q.OrderByDescending(d => d.Name));
            return mapper.Map<IEnumerable<IOrganizationModel>>(allOrganizations);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await unitOfWork.OrganizationRepository.GetByID(id);
            if (user != null)
            {
                unitOfWork.OrganizationRepository.Delete(user);
                await unitOfWork.SaveAsync();
                return true;
            }
            return false;
        }

        //public async Task<IOrganizationModel> GetOrganizationByUserIdAsync(Guid userId)
        //{
        //    var organization = await context.Organization.FirstOrDefaultAsync(o => o.UserId == userId);
        //    if(organization == null)
        //    {
        //        throw new AppException("User doenst have organization");
        //    }

        //    return mapper.Map<IOrganizationModel>(organization);
        //}

    }
}
