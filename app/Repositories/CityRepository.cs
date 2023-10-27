using App.Data;
using App.Entities;

namespace App.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
