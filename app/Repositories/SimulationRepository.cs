using System.Collections;
using System.Linq.Expressions;
using App.Data;
using App.Entities;
using App.Extensions;
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

        public async Task<IDictionary<Institution, int>> CountByInstitution(int year)
        {
            return await Set
                .Where(simulation => simulation.CreatedAt.Year == year)
                .GroupBy(simulation => simulation.Institution.Id)
                .Select(group => KeyValuePair.Create(group.First().Institution, group.Count()))
                .ToDictionaryAsync(item => item.Key, item => item.Value);
        }

        public async Task<IDictionary<Course, int>> CountByCourse(int year)
        {
            return await Set
                .Include(simulation => simulation.Course.Institution)
                .Where(simulation => simulation.CreatedAt.Year == year)
                .GroupBy(simulation => simulation.Course.Id)
                .Select(group => KeyValuePair.Create(group.First().Course, group.Count()))
                .ToDictionaryAsync(item => item.Key, item => item.Value);
        }

        public async Task<IDictionary<Institution, int>> CountConversionsByInstitution(int year)
        {
            return await Set
                .Where(simulation => simulation.WasConverted)
                .Where(simulation => simulation.CreatedAt.Year == year)
                .GroupBy(simulation => simulation.Institution.Id)
                .Select(group => KeyValuePair.Create(group.First().Institution, group.Count()))
                .ToDictionaryAsync(item => item.Key, item => item.Value);
        }

        public async Task<IDictionary<Course, int>> CountConversionsByCourse(int year)
        {
            return await Set
                .Include(simulation => simulation.Course.Institution)
                .Where(simulation => simulation.WasConverted)
                .Where(simulation => simulation.CreatedAt.Year == year)
                .GroupBy(simulation => simulation.Course.Id)
                .Select(group => KeyValuePair.Create(group.First().Course, group.Count()))
                .ToDictionaryAsync(item => item.Key, item => item.Value);
        }

        public override async Task<IEnumerable<Simulation>> List(int page, int limit, Expression<Func<Simulation, bool>>? predicate = null)
        {
            return await Set
                .Include(simulation => simulation.Course)
                .Include(simulation => simulation.Institution)
                .OrderByDescending(simulation => simulation.CreatedAt)
                .Paginate(page, limit)
                .ToListAsync();
        }
    }
}
