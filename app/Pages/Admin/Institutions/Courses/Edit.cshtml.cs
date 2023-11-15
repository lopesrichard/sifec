using App.Components;
using App.Entities;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class Edit : Page
    {
        private readonly IInstitutionService _institutionService;
        private readonly ICourseService _courseService;

        public required UpdateCourseModel Model { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid CourseId { get; set; }
        public string? Message { get; set; }
        public Institution Institution { get; set; }

        public Edit(ICourseService courseService, IInstitutionService institutionService) : base("Editar Curso")
        {
            _courseService = courseService;
            _institutionService = institutionService;
        }

        public async Task<IActionResult> OnGet(Guid institutionId, Guid courseId)
        {
            CourseId = courseId;

            var result = await _courseService.GetCourse(institutionId, courseId);

            if (!result.Success)
            {
                return NotFound();
            }

            await GetInstitution(institutionId);

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
                await _courseService.UpdateCourse(institutionId, courseId, model);

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
                await _courseService.DeleteCourse(institutionId, courseId);

                return RedirectToPage("/Admin/Institutions/Courses/List", new { institutionId });
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Page();
            }
        }

        private async Task GetInstitution(Guid institutionId)
        {
            var result = await _institutionService.GetInstitution(institutionId);

            if (result.Success)
            {
                Institution = result.Data;
            }
        }
    }
}
