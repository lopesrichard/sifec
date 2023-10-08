using App.Entities;
using App.Exceptions;
using App.Repositories;
using App.Results;

namespace App.Services
{
    public class VoucherService : IVoucherService
    {
        public readonly ISimulationRepository _repository;

        public VoucherService(ISimulationRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Simulation>> GetSimulation(Guid id)
        {
            var simulation = await _repository.Get(id);

            if (simulation == null)
            {
                return new ResourceNotFoundException();
            }

            return simulation;
        }
    }
}
