using App.Repositories;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("dashboard")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _service;

    public DashboardController(IDashboardService service)
    {
        _service = service;
    }

    [HttpGet("simulations-by-institution/{year}")]
    public async Task<IActionResult> GetSimulationsByInstitution(int year)
    {
        var result = await _service.SimulationsByInstitution(year);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }

    [HttpGet("simulations-by-course/{year}")]
    public async Task<IActionResult> GetSimulationsByCourse(int year)
    {
        var result = await _service.SimulationsByCourse(year);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }

    [HttpGet("conversions-by-institution/{year}")]
    public async Task<IActionResult> GetConversionsByInstitution(int year)
    {
        var result = await _service.ConversionsByInstitution(year);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }

    [HttpGet("conversions-by-course/{year}")]
    public async Task<IActionResult> GetConversionsByCourse(int year)
    {
        var result = await _service.ConversionsByCourse(year);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }
}