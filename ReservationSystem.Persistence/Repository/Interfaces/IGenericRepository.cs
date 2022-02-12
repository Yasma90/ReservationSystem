using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationSystem.Persistence.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetbyIdAsync(object Id);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);
        Task<TEntity> DeleteAsync(object id);
        IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities);
        bool Exists(object id);
    }
}