using Microsoft.AspNetCore.Mvc;

public class PaginationViewComponent : ViewComponent
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }

    public IViewComponentResult Invoke(int currentPage, int pageSize, int total)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        Total = total;
        return View("Pagination", this);
    }
}