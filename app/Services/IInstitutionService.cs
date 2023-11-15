using App.Entities;
using App.Models;
using App.Results;

namespace App.Services
{
    public interface IInstitutionService
    {
        Task<Result<Institution>> GetInstitution(Guid id);
        Task<Result<int>> CountInstitutions();
        Task<Result<IEnumerable<Institution>>> ListInstitutions();
        Task<Result<IEnumerable<Institution>>> ListInstitutions(int page);
        Task<Result<IEnumerable<Course>>> ListCourses(Guid institutionId);
        Task<Result<Institution>> CreateInstitution(AddInstitutionModel model);
        Task<Result<Institution>> DeleteInstitution(Guid institutionId);
        Task<Result<Institution>> UpdateInstitution(Guid institutionId, UpdateInstitutionModel model);
    }
}
