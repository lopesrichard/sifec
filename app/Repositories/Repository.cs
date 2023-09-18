using System.Linq.Expressions;
using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly DbSet<T> _set;
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _set = context.Set<T>();
            _context = context;
        }

        public async Task<T?> Get(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<T?> Get(Expression<Func<T, bool>> predicate)
        {
            return await _set.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> List(int page, int limit, Expression<Func<T, bool>>? predicate = null)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;
            var query = _set.Skip(skip).Take(limit);
            if (predicate != null) query = query.Where(predicate);
            return await query.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            _set.Add(entity);
            await SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _set.Update(entity);
            await SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _set.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
