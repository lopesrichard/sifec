using App.Entities;
using App.Models;
using App.Results;

namespace App.Services
{
    public interface ICourseService
    {
        Task<Result<Course>> GetCourse(Guid institutionId, Guid courseId);
        Task<Result<int>> CountCourses(Guid institutionId);
        Task<Result<IEnumerable<Course>>> ListCourses(Guid institutionId, int page);
        Task<Result<Course>> DeleteCourse(Guid institutionId, Guid courseId);
        Task<Result<Course>> UpdateCourse(Guid institutionId, Guid courseId, UpdateCourseModel model);
        Task<Result<Course>> CreateCourse(Guid institutionId, AddCourseModel model);
    }
}
