using System.Linq.Expressions;
using App.Data;
using App.Entities;
using App.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> Set;
        protected readonly ApplicationContext Context;

        public Repository(ApplicationContext context)
        {
            Set = context.Set<T>();
            Context = context;
        }

        public virtual async Task<T?> Get(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public virtual async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await Set.Where(predicate).SingleOrDefaultAsync();
        }

        public virtual async Task<int> Count(Expression<Func<T, bool>>? predicate = null)
        {
            var query = Set.AsQueryable();
            if (predicate != null) query = query.Where(predicate);
            return await query.CountAsync();
        }

        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>>? predicate = null)
        {
            var query = Set.AsQueryable();
            if (predicate != null) query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> List(int page, int limit, Expression<Func<T, bool>>? predicate = null)
        {
            var query = Set.AsQueryable();
            if (predicate != null) query = query.Where(predicate);
            query = query.Paginate(page, limit);
            return await query.ToListAsync();
        }

        public virtual async Task Insert(T entity)
        {
            Set.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Update(T entity)
        {
            Set.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task Delete(T entity)
        {
            Set.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}
