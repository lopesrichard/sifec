namespace App.Services
{
    public interface IViewRenderService
    {
        Task<string> Render(string viewName, object model);
    }
}