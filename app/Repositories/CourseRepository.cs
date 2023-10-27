using App.Data;
using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
