using Common.Interface_Sort_Pag_Flt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get(
           IPaging pagingObj,
           Expression<Func<TEntity, bool>> filter, ISorting sortObj,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDescending = null,
           string includeProperties = "");
        Task<TEntity> GetByID(object id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Delete(object id);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
