using App.Components;
using App.Entities;
using App.Services;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> OnGet([FromRoute] Guid simulationId)
        {
            var result = await _service.GetSimulation(simulationId);

            if (!result.Success)
            {
                return RedirectToPage("/Index");
            }

            Simulation = result.Data;

            var html = await _renderer.Render(nameof(Voucher), this);

            var password = Simulation.Document.Replace(".", "")[..5];

            var content = _pdf.CreateFromHtml(html, password);

            return File(content, "application/pdf");
        }
    }
}


