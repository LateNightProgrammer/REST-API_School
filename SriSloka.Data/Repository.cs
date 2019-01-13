using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SriSloka.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal SriSlokaDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(SriSlokaDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }
       
        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> AllInclude
            (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public async Task<IEnumerable<TEntity>> AllIncludeAsync
            (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return await GetAllIncluding(includeProperties).ToListAsync();
        }

        public IEnumerable<TEntity> FindByInclude
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        public async Task<IEnumerable<TEntity>> FindByIncludeAsync
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);

            return await query.Where(predicate).ToListAsync();
        }

        private IQueryable<TEntity> GetAllIncluding
            (params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = _dbSet.AsNoTracking();

            return includeProperties.Aggregate
                (queryable, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IEnumerable<TEntity> results = _dbSet.AsNoTracking()
                .Where(predicate).ToList();
            return results;
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public TEntity FindByKey(int id)
        {
            Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);
            return _dbSet.AsNoTracking().SingleOrDefault(lambda);
        }

        public async  Task<TEntity> FindByKeyAsync(int id)
        {
            Expression<Func<TEntity, bool>> lambda = Utilities.BuildLambdaForFindByKey<TEntity>(id);

            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(lambda);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);

            _context.SaveChanges();
        }

        public async Task InsertAsync(TEntity entity)
        {
            _dbSet.Add(entity);

            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

            // This will fix the child entity state. (If you update child entity, you can update it with parent Entity)
            _context.FixState();

            _context.SaveChanges();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

            // This will fix the child entity state. (If you update child entity, you can update it with parent Entity)
            _context.FixState();

            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// We should never use this in production
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            var entity = FindByKey(id);

            _dbSet.Remove(entity);

            _context.SaveChanges();
        }

        /// <summary>
        /// We should never use this in production
        /// </summary>
        /// <param name="id"></param>
        public async Task DeleteAsync(int id)
        {
            var entity = FindByKey(id);

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
