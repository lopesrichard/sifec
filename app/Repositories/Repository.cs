using System.Linq.Expressions;
using App.Data;
using App.Entities;
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

        public async Task<T?> Get(Guid id)
        {
            return await Set.FindAsync(id);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await Set.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> List(int page, int limit, Expression<Func<T, bool>>? predicate = null)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;
            var query = Set.Skip(skip).Take(limit);
            if (predicate != null) query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            Set.Add(entity);
            await SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            Set.Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            Set.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();
    }
}
