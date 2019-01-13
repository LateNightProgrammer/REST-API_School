using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SriSloka.Data
{
    // We are not using this interface, delete it.
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> All();

        Task<IEnumerable<TEntity>> AllAsync();

        IEnumerable<TEntity> AllInclude
            (params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> AllIncludeAsync
            (params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindByInclude
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        Task<IEnumerable<TEntity>> FindByIncludeAsync
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FindByKey(int id);

        Task<TEntity> FindByKeyAsync(int id);

        void Insert(TEntity entity);

        Task InsertAsync(TEntity entity);

        void Update(TEntity entity);

        Task UpdateAsync(TEntity entity);

        void Delete(int id);

        Task DeleteAsync(int id);
    }
}
