using App.Entities;
using App.Results;

namespace App.Services
{
    public interface IInstitutionService
    {
        Task<Result<IEnumerable<Institution>>> ListInstitutions();
        Task<Result<IEnumerable<Course>>> ListCourses(Guid institutionId);
    }
}
