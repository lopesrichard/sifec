using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Components
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

