using SelectPdf;

namespace App.Services
{
    public class PdfService : IPdfService
    {
        private readonly IHttpContextAccessor _acessor;

        public PdfService(IHttpContextAccessor acessor)
        {
            _acessor = acessor;
        }

        public byte[] CreateFromHtml(string html)
        {
            var request = _acessor.HttpContext!.Request;

            using var ms = new MemoryStream();

            var converter = new HtmlToPdf();

            converter.Options.MarginLeft = 20;
            converter.Options.MarginRight = 20;
            converter.Options.MarginTop = 20;
            converter.Options.MarginBottom = 20;

            var path = Directory.GetCurrentDirectory();

            var document = converter.ConvertHtmlString(html, $"{request.Scheme}://{request.Host}");

            document.Save(ms);
            document.Close();

            return ms.ToArray();
        }
    }
}