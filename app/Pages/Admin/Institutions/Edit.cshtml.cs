using App.Components;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions
{
    public class Edit : Page
    {
        private readonly IInstitutionService _service;

        public required UpdateInstitutionModel Model { get; set; }
        public Guid InstitutionId { get; set; }
        public string? Message { get; set; }

        public Edit(IInstitutionService service) : base("Editar Instituição")
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(Guid institutionId)
        {
            InstitutionId = institutionId;

            var result = await _service.GetInstitution(institutionId);

            if (!result.Success)
            {
                return NotFound();
            }

            Model = new UpdateInstitutionModel()
            {
                Code = result.Data.Code,
                Name = result.Data.Name
            };

            return Page();
        }

        public async Task<IActionResult> OnPostSave(Guid institutionId, UpdateInstitutionModel model)
        {
            try
            {
                await _service.UpdateInstitution(institutionId, model);

                return RedirectToPage("/Admin/Institutions/List");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemove(Guid institutionId)
        {
            try
            {
                await _service.DeleteInstitution(institutionId);

                return RedirectToPage("/Admin/Institutions/List");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }
    }
}
