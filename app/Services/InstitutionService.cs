using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Repositories;
using App.Results;

namespace App.Services
{
    public class InstitutionService : IInstitutionService
    {
        public readonly IInstitutionRepository _institutionRepository;
        public readonly ICourseRepository _courseRepository;
        public readonly ICityRepository _cityRepository;

        public InstitutionService(IInstitutionRepository institutionRepository, ICourseRepository courseRepository, ICityRepository cityRepository)
        {
            _institutionRepository = institutionRepository;
            _courseRepository = courseRepository;
            _cityRepository = cityRepository;
        }

        public async Task<Result<IEnumerable<Institution>>> ListInstitutions()
        {
            var institutions = await _institutionRepository.List();
            return institutions.AsResult();
        }

        public async Task<Result<IEnumerable<Course>>> ListCourses(Guid institutionId)
        {
            var courses = await _courseRepository.List(course => course.InstitutionId == institutionId);
            return courses.AsResult();
        }
    }
}
