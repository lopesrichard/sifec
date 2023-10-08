namespace App.Services
{
    public interface IPdfService
    {
        byte[] CreateFromHtml(string html);
    }
}