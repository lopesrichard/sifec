using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class SimulationRepository : Repository<Simulation>, ISimulationRepository
    {
        public SimulationRepository(ApplicationContext context) : base(context)
        {
        }

        public new async Task<Simulation?> Get(Guid id)
        {
            return await Set
                .Include(s => s.Course)
                .Include(s => s.Institution)
                .Include(s => s.City)
                .SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
