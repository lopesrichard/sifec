using App.Components;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions
{
    public class New : Page
    {
        private readonly IInstitutionService _service;

        public string? Message { get; set; }

        public New(IInstitutionService service) : base("Nova Instituição")
        {
            _service = service;
        }

        public async Task<IActionResult> OnPost(AddInstitutionModel model)
        {
            var result = await _service.CreateInstitution(model);

            if (!result.Success)
            {
                Message = result.Exception.Message;
                return Page();
            }

            return RedirectToPage("/Admin/Institutions/List");
        }
    }
}
