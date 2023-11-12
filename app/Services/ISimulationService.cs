using App.Entities;
using App.Models;
using App.Results;

namespace App.Services
{
    public interface ISimulationService
    {
        Task<Result<IEnumerable<Simulation>>> ListSimulations(int page);
        Task<Result<Simulation>> CreateSimulation(AddSimulationModel model);
        Task<Result<int>> CountSimulations();
    }
}
