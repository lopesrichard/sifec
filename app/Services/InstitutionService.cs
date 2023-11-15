using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Models;
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

        public async Task<Result<IEnumerable<Institution>>> ListInstitutions(int page)
        {
            var results = await _institutionRepository.List(page, 10);
            return results.AsResult();
        }

        public async Task<Result<int>> CountInstitutions()
        {
            return await _institutionRepository.Count();
        }

        public async Task<Result<Institution>> GetInstitution(Guid id)
        {
            var simulation = await _institutionRepository.Get(id);
            if (simulation == null) return new ResourceNotFoundException();
            return simulation;
        }

        public async Task<Result<Institution>> CreateInstitution(AddInstitutionModel model)
        {
            var institution = new Institution()
            {
                Code = model.Code,
                Name = model.Name
            };

            try
            {
                await _institutionRepository.Insert(institution);
                return institution;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Institution>> DeleteInstitution(Guid institutionId)
        {
            try
            {
                var institution = await _institutionRepository.Get(institutionId);
                if (institution == null) return new ResourceNotFoundException();
                await _institutionRepository.Delete(institution);
                return institution;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public async Task<Result<Institution>> UpdateInstitution(Guid institutionId, UpdateInstitutionModel model)
        {
            try
            {
                var entity = await _institutionRepository.Get(institutionId);

                if (entity == null) return new ResourceNotFoundException();

                entity.Code = model.Code;
                entity.Name = model.Name;

                await _institutionRepository.Update(entity);

                return entity;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
