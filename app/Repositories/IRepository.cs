using System.Linq.Expressions;
using App.Entities;
using App.Pages;

namespace App.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> Get(Guid id);
        Task<T?> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> List(int page, int limit, Expression<Func<T, bool>>? predicate = null);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
