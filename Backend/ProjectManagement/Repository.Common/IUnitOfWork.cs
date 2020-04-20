using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<DAL.Entities.User> UserRepository { get; }
        IGenericRepository<UserRole> UserRole { get; }
        IGenericRepository<Organization> OrganizationRepository { get; }
        IGenericRepository<OrganizationRole> OrganizationRoleRepository { get; }
        Task<int> SaveAsync();
    }
}
