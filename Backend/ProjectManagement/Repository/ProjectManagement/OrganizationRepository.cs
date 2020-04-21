using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
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

            var allOrganizations = await unitOfWork.OrganizationRepository.Get(null, null, null);
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

        public async Task<List<IOrganizationModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            //var allUsers = await unitOfWork.UserRepository.Get(pagingObj, filter: w => w.FirstName == filterObj.FilterValue, sortObj, orderBy: q => q.OrderBy(d => d.FirstName),
            //    orderByDescending: q => q.OrderByDescending(d => d.FirstName));
            var allOrganizations = await unitOfWork.OrganizationRepository.Get(null, null, null);
            return mapper.Map<List<IOrganizationModel>>(allOrganizations);
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

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
