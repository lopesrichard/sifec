using App.Entities;
using App.Models;
using App.Results;

namespace App.Services
{
    public interface ISimulationService
    {
        Task<Result<Simulation>> CreateSimulation(AddSimulationModel model);
    }
}
