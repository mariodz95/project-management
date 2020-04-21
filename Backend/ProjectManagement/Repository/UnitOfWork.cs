using DAL;
using DAL.Entities;
using Repository.Common;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ProjectManagementContext context;
        private IGenericRepository<DAL.Entities.User> userRepository;
        private IGenericRepository<UserRole> userRoleRepository;
        private IGenericRepository<Organization> organizationRepository;
        private IGenericRepository<OrganizationRole> organizationRoleRepository;

        public UnitOfWork(ProjectManagementContext context)
        {
            this.context = context;
        }

        public IGenericRepository<DAL.Entities.User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<DAL.Entities.User>(context);
                }
                return userRepository;
            }
        }

        public IGenericRepository<UserRole> UserRole
        {
            get
            {

                if (this.userRoleRepository == null)
                {
                    this.userRoleRepository = new GenericRepository<UserRole>(context);
                }
                return userRoleRepository;
            }
        }

        public IGenericRepository<Organization> OrganizationRepository
        {
            get
            {

                if (this.organizationRepository == null)
                {
                    this.organizationRepository = new GenericRepository<Organization>(context);
                }
                return organizationRepository;
            }
        }

        public IGenericRepository<OrganizationRole> OrganizationRoleRepository
        {
            get
            {

                if (this.organizationRoleRepository == null)
                {
                    this.organizationRoleRepository = new GenericRepository<OrganizationRole>(context);
                }
                return organizationRoleRepository;
            }
        }


        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
