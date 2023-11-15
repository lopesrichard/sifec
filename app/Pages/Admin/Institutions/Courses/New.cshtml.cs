using App.Components;
using App.Entities;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class New : Page
    {
        private readonly IInstitutionService _institutionService;
        private readonly ICourseService _courseService;

        public Institution Institution { get; set; }

        public string? Message { get; set; }

        public New(ICourseService courseService, IInstitutionService institutionService) : base("Novo Curso")
        {
            _courseService = courseService;
            _institutionService = institutionService;
        }

        public async Task OnGet(Guid institutionId)
        {
            await GetInstitution(institutionId);
        }

        private async Task GetInstitution(Guid institutionId)
        {
            var result = await _institutionService.GetInstitution(institutionId);

            if (result.Success)
            {
                Institution = result.Data;
            }
        }

        public async Task<IActionResult> OnPost(Guid institutionId, AddCourseModel model)
        {
            var result = await _courseService.CreateCourse(institutionId, model);

            if (!result.Success)
            {
                Message = result.Exception.Message;
                return Page();
            }

            return RedirectToPage("/Admin/Institutions/Courses/List", new { institutionId });
        }
    }
}
