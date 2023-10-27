using App.Entities;
using App.Models;
using App.Results;

namespace App.Services
{
    public class SimulationService : ISimulationService
    {
        public Task<Result<Simulation>> CreateSimulation(AddSimulationModel model)
        {
            // var simulation = new Simulation()
            // {
            //     InstitutionId = model.Institution,
            //     CourseId = model.Course,
            //     Semester = model.Semester,
            //     Fee = model.Fee,
            //     Name = model.Name,
            //     Document = model.Document,
            //     Email = model.Email,
            //     CityId = model.City,
            // };

            return null;
        }
    }
}
