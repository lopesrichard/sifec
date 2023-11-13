using App.Entities;
using App.Exceptions;
using App.Extensions;
using App.Models;
using App.Repositories;
using App.Results;

namespace App.Services
{
    public class SimulationService : ISimulationService
    {
        private const int MONTHS_IN_A_SEMESTER = 6;
        private readonly ICourseRepository _courseRepository;
        private readonly ISimulationRepository _simulationRepository;

        public SimulationService(ICourseRepository courseRepository, ISimulationRepository simulationRepository)
        {
            _courseRepository = courseRepository;
            _simulationRepository = simulationRepository;
        }

        public async Task<Result<Simulation>> CreateSimulation(AddSimulationModel model)
        {
            var fee = await GetCourseFee(model);
            var requestedAmount = CalculateRequestedAmount(model);
            var totalValue = CalculateTotalValue(requestedAmount, fee.Data);
            var installmentValue = CalculateInstallmentValue(totalValue);
            var firstPaymentDue = CalculateFirstPaymentDue();
            var lastPaymentDue = CalculateLastPaymentDue(firstPaymentDue);
            var gracePeriodDays = CalculateGracePeriodDays(firstPaymentDue);

            var simulation = new Simulation()
            {
                InstitutionId = model.Institution,
                CourseId = model.Course,
                Semester = model.Semester,
                TuitionFee = model.Fee,
                Name = model.Name,
                Document = model.Document,
                Email = model.Email,
                CityId = model.City,
                RequestedAmount = requestedAmount,
                Fee = fee.Data,
                TotalValue = totalValue,
                InstallmentValue = installmentValue,
                GracePeriodDays = gracePeriodDays,
                FirstPaymentDue = firstPaymentDue,
                LastPaymentDue = lastPaymentDue,
                ValidationKey = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow,
                WasConverted = false,
            };

            try
            {
                await _simulationRepository.Insert(simulation);
            }
            catch
            {
                return new UnprocessableContentException();
            }

            return simulation;
        }

        private decimal CalculateRequestedAmount(AddSimulationModel model)
        {
            return model.Fee * MONTHS_IN_A_SEMESTER;
        }

        private decimal CalculateTotalValue(decimal amount, decimal fee)
        {
            return (decimal)((double)amount * Math.Pow((double)(1 + fee / 100), MONTHS_IN_A_SEMESTER - 1));
        }

        private decimal CalculateInstallmentValue(decimal total)
        {
            return total / MONTHS_IN_A_SEMESTER;
        }

        private DateTime CalculateFirstPaymentDue()
        {
            return DateTime.UtcNow.AddMonths(MONTHS_IN_A_SEMESTER);
        }

        private DateTime CalculateLastPaymentDue(DateTime firstPaymentDue)
        {
            return firstPaymentDue.AddMonths(MONTHS_IN_A_SEMESTER);
        }

        private int CalculateGracePeriodDays(DateTime firstPaymentDue)
        {
            return (int)firstPaymentDue.Subtract(DateTime.Now).TotalDays;
        }

        private async Task<Result<decimal>> GetCourseFee(AddSimulationModel model)
        {
            var course = await _courseRepository.Get(model.Course);
            if (course == null) return new ResourceNotFoundException();
            return course.Fee;
        }

        public async Task<Result<IEnumerable<Simulation>>> ListSimulations(int page)
        {
            var results = await _simulationRepository.List(page, 10);
            return results.AsResult();
        }

        public async Task<Result<int>> CountSimulations()
        {
            return await _simulationRepository.Count();
        }

        public async Task<Result<Simulation>> GetSimulation(Guid id)
        {
            var simulation = await _simulationRepository.Get(id);
            if (simulation == null) return new ResourceNotFoundException();
            return simulation;
        }
    }
}
