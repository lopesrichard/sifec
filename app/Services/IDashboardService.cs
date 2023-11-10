using App.Results;

namespace App.Services
{
    public interface IDashboardService
    {
        Task<Result<IDictionary<string, int>>> SimulationsByInstitution(int year);
        Task<Result<IDictionary<string, int>>> SimulationsByCourse(int year);
        Task<Result<IDictionary<string, int>>> ConversionsByInstitution(int year);
        Task<Result<IDictionary<string, int>>> ConversionsByCourse(int year);
    }
}
