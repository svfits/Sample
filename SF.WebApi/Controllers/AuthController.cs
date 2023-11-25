using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SF.WebApi.BL.Request;
using SF.WebApi.BL.Response;
using SF.WebApi.BL.Services;
using System.Net.Mime;

namespace SF.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    /// <summary>
    /// Получить токен для авторизации
    /// Мне лень писать авторизацию просто передаем Id существующего пользователя
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Все хорошо должен быть токен</response>
    /// <response code="400">Что то поломалось когда слали</response>
    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult<List<UserResponse>>> GetToken([FromBody] LoginRequest loginRequest)
    {
        _logger.LogTrace("Поступили данные для авторизации {@loginRequest}", loginRequest);

        try
        {
            var result = await _authService.GetToken(loginRequest);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при авторизации {@login}", loginRequest);
            return BadRequest(ex.Message);
        }
    }
}

