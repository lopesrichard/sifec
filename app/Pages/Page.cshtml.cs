using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class Page : PageModel
    {
        public string Title { get; }

        public Page(string title)
        {
            Title = title;
        }
    }
}

