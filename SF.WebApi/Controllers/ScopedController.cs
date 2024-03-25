using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.WebApi.BL.Services;
using System.Net.Mime;

namespace SF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class ScopedController(IScopedService scopedService) : ControllerBase
{

    /// <summary>
    /// Запуск scoped
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult RunScoped()
    {
        var i = scopedService.Start();
        var i2 = scopedService.Start();
        var i3 = scopedService.Start();
        return Ok(i + i2 + i3);
    }
}
