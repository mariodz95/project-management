using Common.Interface_Sort_Pag_Flt;
using DAL;
using Microsoft.EntityFrameworkCore;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ProjectManagementContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ProjectManagementContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(
           IPaging pagingObj,
           Expression<Func<TEntity, bool>> filter, ISorting sortObj,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByDescending = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            bool pagingEnabled = false;
            if (pagingObj != null)
            {
                pagingEnabled = pagingObj.PageSize > 0;
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pagingEnabled)
                pagingObj.TotalPages = (int)Math.Ceiling((decimal)query.Count() / (decimal)pagingObj.PageSize);
            else
                pagingObj.TotalPages = 1;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (sortObj != null)
            {
                switch (sortObj.SortOrder)
                {
                    case "name_desc":
                        query = orderByDescending(query);
                        break;
                    default:
                        query = orderBy(query);
                        break;
                }
            }
            if (pagingEnabled)
            {
                return await query.Skip(pagingObj.PageSize * (pagingObj.PageNumber ?? -1)).Take(pagingObj.PageSize).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> Delete(object id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            Delete(entityToDelete);
            return entityToDelete;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
