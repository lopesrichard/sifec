using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Models;
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

        public async Task<Result<Course>> GetCourse(Guid institutionId, Guid courseId)
        {
            var course = await _repository.Get(course => course.InstitutionId == institutionId && course.Id == courseId);

            if (course == null)
            {
                return new ResourceNotFoundException();
            }

            return course;
        }

        public async Task<Result<IEnumerable<Course>>> ListCourses(Guid institutionId, int page)
        {
            var results = await _repository.List(page, 10, course => course.InstitutionId == institutionId);
            return results.AsResult();
        }

        public async Task<Result<int>> CountCourses(Guid institutionId)
        {
            return await _repository.Count(course => course.InstitutionId == institutionId);
        }

        public async Task<Result<Course>> DeleteCourse(Guid institutionId, Guid courseId)
        {
            try
            {
                var course = await _repository.Get(course => course.InstitutionId == institutionId && course.Id == courseId);
                if (course == null) return new ResourceNotFoundException();
                await _repository.Delete(course);
                return course;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Course>> CreateCourse(Guid institutionId, AddCourseModel model)
        {
            var course = new Course()
            {
                Code = model.Code,
                Name = model.Name,
                Duration = model.Duration,
                Fee = model.Fee,
                InstitutionId = institutionId
            };

            try
            {
                await _repository.Insert(course);
                return course;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Course>> UpdateCourse(Guid institutionId, Guid courseId, UpdateCourseModel model)
        {
            try
            {
                var entity = await _repository.Get(course => course.InstitutionId == institutionId && course.Id == courseId);

                if (entity == null) return new ResourceNotFoundException();

                entity.Code = model.Code;
                entity.Name = model.Name;
                entity.Duration = model.Duration;
                entity.Fee = model.Fee;

                await _repository.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
