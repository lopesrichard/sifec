using Microsoft.AspNetCore.Mvc;

public class LogoViewComponent : ViewComponent
{
    public int FontSize { get; set; }
    public bool Dark { get; set; }

    public IViewComponentResult Invoke(int fontSize = 48, bool dark = false)
    {
        FontSize = fontSize;
        Dark = dark;

        return View("Logo", this);
    }
}