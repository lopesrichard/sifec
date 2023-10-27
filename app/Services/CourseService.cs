using App.Entities;
using App.Exceptions;
using App.Repositories;
using App.Results;

namespace App.Services
{
    public class CourseService : ICourseService
    {
        public readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Course>> GetCourse(Guid courseId)
        {
            var course = await _repository.Get(courseId);

            if (course == null)
            {
                return new ResourceNotFoundException();
            }

            return course;
        }
    }
}
