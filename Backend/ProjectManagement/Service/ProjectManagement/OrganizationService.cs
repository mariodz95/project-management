using AutoMapper;
using Common.Interface_Sort_Pag_Flt;
using Model.Common.ProjectManagement;
using Repository.Common.ProjectManagement;
using Service.Common.ProjectManagement;
using System;
using System.Collections.Generic;
using System.Text;
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
            return await organizationRepository.CreateAsync(userId, organization);
        }

        public async Task<List<IOrganizationModel>> GetAll(IFiltering filterObj, ISorting sortObj, IPaging pagingObj)
        {
            var organizations = await organizationRepository.GetAllAsync(filterObj, sortObj, pagingObj);
            return mapper.Map<List<IOrganizationModel>>(organizations);
        }
        public virtual void Dispose()
        {
            organizationRepository.Dispose();
        }
    }
}
