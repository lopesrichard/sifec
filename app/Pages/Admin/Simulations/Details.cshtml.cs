using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Simulations
{
    public class Details : Page
    {
        private readonly ISimulationService _service;

        public required Simulation Simulation { get; set; }

        public Details(ISimulationService service) : base("Detalhes da Simulação")
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet([FromRoute] Guid simulation)
        {
            var result = await _service.GetSimulation(simulation);

            if (!result.Success)
            {
                return NotFound();
            }

            Simulation = result.Data;

            return Page();
        }
    }
}

