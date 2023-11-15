using System.Linq.Expressions;
using App.Data;
using App.Entities;
using App.Extensions;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Course>> List(int page, int limit, Expression<Func<Course, bool>>? predicate = null)
        {
            var query = Set.AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.OrderBy(course => course.Code)
                .Paginate(page, limit)
                .ToListAsync();
        }
    }
}
