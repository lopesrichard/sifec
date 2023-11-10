using App.Repositories;
using App.Results;

namespace App.Services
{
    public class DashboardService : IDashboardService
    {
        public readonly ISimulationRepository _repository;

        public DashboardService(ISimulationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<IDictionary<string, int>>> SimulationsByInstitution(int year)
        {
            var dict = await _repository.CountByInstitution(year);
            return dict.ToDictionary(item => item.Key.Name, item => item.Value);
        }

        public async Task<Result<IDictionary<string, int>>> SimulationsByCourse(int year)
        {
            var dict = await _repository.CountByCourse(year);
            return dict.ToDictionary(item => item.Key.Institution.Code + "-" + item.Key.Name, item => item.Value);
        }

        public async Task<Result<IDictionary<string, int>>> ConversionsByInstitution(int year)
        {
            var dict = await _repository.CountConversionsByInstitution(year);
            return dict.ToDictionary(item => item.Key.Name, item => item.Value);
        }

        public async Task<Result<IDictionary<string, int>>> ConversionsByCourse(int year)
        {
            var dict = await _repository.CountConversionsByCourse(year);
            return dict.ToDictionary(item => item.Key.Institution.Code + "-" + item.Key.Name, item => item.Value);
        }

    }
}
