using App.Components;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class List : Page
    {
        private readonly ICourseService _service;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int CourseCount { get; set; }
        public IEnumerable<Course> CourseList { get; set; } = new List<Course>();

        public List(ICourseService service) : base("Simulações")
        {
            _service = service;
        }

        public async Task OnGet(Guid institutionId, [FromQuery] int page = 1)
        {
            CurrentPage = page;
            await CountCourses(institutionId);
            await ListCourses(institutionId, page);
        }

        private async Task CountCourses(Guid institutionId)
        {
            var result = await _service.CountCourses(institutionId);

            if (result.Success)
            {
                CourseCount = result.Data;
            }
        }

        private async Task ListCourses(Guid institutionId, int page)
        {
            var result = await _service.ListCourses(institutionId, page);

            if (result.Success)
            {
                CourseList = result.Data;
            }
        }
    }
}

