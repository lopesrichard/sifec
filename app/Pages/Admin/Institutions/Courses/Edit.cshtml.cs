using App.Components;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class Edit : Page
    {
        private readonly ICourseService _service;

        public required UpdateCourseModel Model { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid CourseId { get; set; }
        public string? Message { get; set; }

        public Edit(ICourseService service) : base("Editar Curso")
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(Guid institutionId, Guid courseId)
        {
            InstitutionId = institutionId;
            CourseId = courseId;

            var result = await _service.GetCourse(institutionId, courseId);

            if (!result.Success)
            {
                return NotFound();
            }

            Model = new UpdateCourseModel()
            {
                Code = result.Data.Code,
                Name = result.Data.Name,
                Duration = result.Data.Duration,
                Fee = result.Data.Fee,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostSave(Guid institutionId, Guid courseId, UpdateCourseModel model)
        {
            try
            {
                await _service.UpdateCourse(institutionId, courseId, model);

                return RedirectToPage($"/Admin/Institutions/Courses/List", new { institutionId });
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostRemove(Guid institutionId, Guid courseId)
        {
            try
            {
                await _service.DeleteCourse(institutionId, courseId);

                return RedirectToPage("/Admin/Institutions/Courses/List", new { institutionId });
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }
    }
}
