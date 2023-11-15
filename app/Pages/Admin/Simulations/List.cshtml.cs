using App.Components;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Simulations
{
    public class List : Page
    {
        private readonly ISimulationService _service;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int SimulationCount { get; set; }
        public IEnumerable<Simulation> SimulationList { get; set; } = new List<Simulation>();

        public List(ISimulationService service) : base("Simulações")
        {
            _service = service;
        }

        public async Task OnGet([FromQuery] int page = 1)
        {
            CurrentPage = page;
            await CountSimulations();
            await ListSimulations(page);
        }

        private async Task CountSimulations()
        {
            var result = await _service.CountSimulations();

            if (result.Success)
            {
                SimulationCount = result.Data;
            }
        }

        private async Task ListSimulations(int page)
        {
            var result = await _service.ListSimulations(page);

            if (result.Success)
            {
                SimulationList = result.Data;
            }
        }
    }
}

