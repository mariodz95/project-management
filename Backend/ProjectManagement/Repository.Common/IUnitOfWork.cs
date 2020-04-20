using DAL.Entities;
using System;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<DAL.Entities.User> UserRepository { get; }
        IGenericRepository<UserRole> UserRole { get; }
        Task<int> SaveAsync();
    }
}
