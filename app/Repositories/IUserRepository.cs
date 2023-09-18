using App.Entities;

namespace App.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsername(string username);
    }
}
