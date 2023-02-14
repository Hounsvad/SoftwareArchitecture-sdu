using Microsoft.AspNetCore.Mvc;
using PerformanceSink.Services;

namespace PerformanceSink.Controllers;

[ApiController]
[Route("[controller]")]
public class PiController : ControllerBase
{
    private readonly ILoadService _loadService;

    public PiController(ILoadService loadService)
    {
        _loadService = loadService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPi()
    {
        return Ok(await _loadService.GetPiPrecision(1700));
    }
}
