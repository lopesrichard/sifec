using App.Entities;
using App.Results;

namespace App.Services
{
    public interface ICourseService
    {
        Task<Result<Course>> GetCourse(Guid courseId);
    }
}
