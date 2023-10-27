using App.Repositories;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers;

[ApiController]
[Route("institutions")]
public class InstitutionController : ControllerBase
{
    private readonly IInstitutionService _service;

    public InstitutionController(IInstitutionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.ListInstitutions();
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }

    [HttpGet("{id}/courses")]
    public async Task<IActionResult> GetCourses(Guid id)
    {
        var result = await _service.ListCourses(id);
        if (!result.Success) return StatusCode(500);
        return Ok(result.Data);
    }
}