using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("cities")]
public class CityController : ControllerBase
{
    private readonly ICityService _service;

    public CityController(ICityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.ListCities();
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }
}