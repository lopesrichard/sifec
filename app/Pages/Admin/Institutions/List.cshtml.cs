using App.Components;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions
{
    public class List : Page
    {
        private readonly IInstitutionService _service;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int InstitutionCount { get; set; }
        public IEnumerable<Institution> InstitutionList { get; set; } = new List<Institution>();

        public List(IInstitutionService service) : base("Simulações")
        {
            _service = service;
        }

        public async Task OnGet([FromQuery] int page = 1)
        {
            CurrentPage = page;
            await CountInstitutions();
            await ListInstitutions(page);
        }

        private async Task CountInstitutions()
        {
            var result = await _service.CountInstitutions();

            if (result.Success)
            {
                InstitutionCount = result.Data;
            }
        }

        private async Task ListInstitutions(int page)
        {
            var result = await _service.ListInstitutions(page);

            if (result.Success)
            {
                InstitutionList = result.Data;
            }
        }
    }
}

