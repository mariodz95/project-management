using AutoMapper;
using Common.Helpers;
using Common.Interface_Sort_Pag_Flt;
using DAL.Entities;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.ProjectManagement
{
    public class OrganizationService : IOrganizationService
    {

        private IOrganizationRepositroy organizationRepository;
        private IMapper mapper;

        public OrganizationService(IOrganizationRepositroy organizationRepository, IMapper mapper)
        {
            this.organizationRepository = organizationRepository;
            this.mapper = mapper;
        }

        public async Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization)
        {
            var newOrganization = mapper.Map<Organization>(organization);

            if (string.IsNullOrWhiteSpace(newOrganization.Name))
            {
                throw new AppException("Organization name is required");
            }

            if (await organizationRepository.CheckIfExistAsync(newOrganization.Name))
            {
                throw new AppException("Organization name \"" + newOrganization.Name + "\" is already taken");
            }

            newOrganization.Id = Guid.NewGuid();
            newOrganization.Abrv = organization.Name.ToLower();
            newOrganization.DateCreated = DateTime.Now;
            newOrganization.DateUpdated = DateTime.Now;
            //newOrganization.UserId = userId;


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

            newOrganization.OrganizationRole = organizationRole;
            await organizationRepository.CreateAsync(newOrganization);
            return mapper.Map<IOrganizationModel>(newOrganization);
        }

        public async Task<IEnumerable<IOrganizationModel>> GetAllAsync(Guid userId, IPaging paging)
        {

            var organizations = await organizationRepository.GetAllAsync(userId, paging);
            return mapper.Map<IEnumerable<IOrganizationModel>>(organizations);
        }
    }
}
