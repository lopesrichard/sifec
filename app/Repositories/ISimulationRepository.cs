using App.Entities;

namespace App.Repositories
{
    public interface ISimulationRepository : IRepository<Simulation>
    {
        Task<IDictionary<Institution, int>> CountByInstitution(int year);
        Task<IDictionary<Course, int>> CountByCourse(int year);
        Task<IDictionary<Institution, int>> CountConversionsByInstitution(int year);
        Task<IDictionary<Course, int>> CountConversionsByCourse(int year);
    }
}
