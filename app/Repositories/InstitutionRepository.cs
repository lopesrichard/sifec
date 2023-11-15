using System.Linq.Expressions;
using App.Data;
using App.Entities;
using App.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class InstitutionRepository : Repository<Institution>, IInstitutionRepository
    {
        public InstitutionRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Course>?> ListCourses(Guid institutionId)
        {
            return await Set.Include(institution => institution.Courses)
                .Select(institution => institution.Courses)
                .FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Institution>> List(int page, int limit, Expression<Func<Institution, bool>>? predicate = null)
        {
            var query = Set.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.OrderBy(simulation => simulation.Code)
                .Paginate(page, limit)
                .ToListAsync();
        }
    }
}
