using App.Entities;

namespace App.Repositories
{
    public interface IInstitutionRepository : IRepository<Institution>
    {
        Task<IEnumerable<Course>?> ListCourses(Guid institutionId);
    }
}
