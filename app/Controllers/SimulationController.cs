using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("simulations")]
public class SimulationController : ControllerBase
{
    private readonly ISimulationService _service;

    public SimulationController(ISimulationService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddSimulationModel model)
    {
        var result = await _service.CreateSimulation(model);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }
}