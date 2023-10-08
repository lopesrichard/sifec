using System.Net.WebSockets;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace App.Pages
{
    public class Voucher : Page
    {
        public readonly IVoucherService _service;
        public readonly IViewRenderService _renderer;
        public readonly IPdfService _pdf;

        public required Simulation Simulation { get; set; }

        public Voucher(IVoucherService service, IViewRenderService renderer, IPdfService pdf) : base("Voucher")
        {
            _service = service;
            _renderer = renderer;
            _pdf = pdf;
        }

        public async Task<IActionResult> OnGet([FromRoute] Guid simulation)
        {
            var result = await _service.GetSimulation(simulation);

            if (!result.Success)
            {
                return RedirectToPage("/404");
            }

            Simulation = result.Data;

            var html = await _renderer.Render(nameof(Voucher), this);

            var content = _pdf.CreateFromHtml(html);

            return File(content, "application/pdf");
        }
    }
}


