using App.Data;
using App.Entities;
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
    }
}
