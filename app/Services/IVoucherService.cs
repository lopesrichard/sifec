using App.Entities;
using App.Results;

namespace App.Services
{
    public interface IVoucherService
    {
        Task<Result<Simulation>> GetSimulation(Guid id);
    }
}
