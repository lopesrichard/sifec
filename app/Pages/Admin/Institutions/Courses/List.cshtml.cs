using App.Components;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Pages.Admin.Institutions.Courses
{
    public class List : Page
    {
        private readonly IInstitutionService _institutionService;
        private readonly ICourseService _courseService;

        public int CurrentPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int CourseCount { get; set; }
        public Institution Institution { get; set; }
        public IEnumerable<Course> CourseList { get; set; } = new List<Course>();

        public List(IInstitutionService institutionService, ICourseService courseService) : base("Simulações")
        {
            _institutionService = institutionService;
            _courseService = courseService;
        }

        public async Task OnGet(Guid institutionId, [FromQuery] int page = 1)
        {
            CurrentPage = page;
            await GetInstitution(institutionId);
            await CountCourses(institutionId);
            await ListCourses(institutionId, page);
        }

        private async Task GetInstitution(Guid institutionId)
        {
            var result = await _institutionService.GetInstitution(institutionId);

            if (result.Success)
            {
                Institution = result.Data;
            }
        }

        private async Task CountCourses(Guid institutionId)
        {
            var result = await _courseService.CountCourses(institutionId);

            if (result.Success)
            {
                CourseCount = result.Data;
            }
        }

        private async Task ListCourses(Guid institutionId, int page)
        {
            var result = await _courseService.ListCourses(institutionId, page);

            if (result.Success)
            {
                CourseList = result.Data;
            }
        }
    }
}

