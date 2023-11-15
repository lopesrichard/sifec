using App.Components;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class New : Page
    {
        private readonly ICourseService _service;

        public string? Message { get; set; }

        public New(ICourseService service) : base("Novo Curso")
        {
            _service = service;
        }

        public async Task<IActionResult> OnPost(Guid institutionId, AddCourseModel model)
        {
            var result = await _service.CreateCourse(institutionId, model);

            if (!result.Success)
            {
                Message = result.Exception.Message;
                return Page();
            }

            return RedirectToPage("/Admin/Institutions/Courses/List", new { institutionId });
        }
    }
}
