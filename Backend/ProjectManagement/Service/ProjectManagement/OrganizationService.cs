using AutoMapper;
using Common.Interface_Sort_Pag_Flt;
using DAL;
using Model.Common.ProjectManagement;
using Repository;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ProjectManagement
{
    public class OrganizationService : IOrganizationService
    {

        private IOrganizationRepositroy organizationRepository;
        private IMapper mapper;
        private ProjectManagementContext ctx;

        public OrganizationService(IOrganizationRepositroy organizationRepository, IMapper mapper, ProjectManagementContext ctx)
        {
            this.organizationRepository = organizationRepository;
            this.mapper = mapper;
            this.ctx = ctx;
        }

        public async Task<IOrganizationModel> CreateAsync(Guid userId, IOrganizationModel organization)
        {
            return await organizationRepository.CreateAsync(userId, organization);
        }

        public async Task<IEnumerable<IOrganizationModel>> GetAllAsync(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            var organizations = await organizationRepository.GetAllAsync(filterObj, sortObj, pagingObj);
            return organizations;
        }

        //public async Task<IOrganizationModel> GetOrganizationByUserIdAsync(Guid userId)
        //{
        //    var organization = await organizationRepository.GetOrganizationByUserIdAsync(userId);
        //    return organization;
        //}

    }
}
