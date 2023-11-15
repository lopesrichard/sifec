using App.Components;
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

        public async Task<IActionResult> OnGet([FromRoute] Guid simulationId)
        {
            var result = await _service.GetSimulation(simulationId);

            if (!result.Success)
            {
                return NotFound();
            }

            Simulation = result.Data;

            return Page();
        }
    }
}

