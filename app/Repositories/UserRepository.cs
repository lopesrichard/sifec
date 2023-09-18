using App.Data;
using App.Entities;

namespace App.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await Get(user => user.Username == username);
        }
    }
}
