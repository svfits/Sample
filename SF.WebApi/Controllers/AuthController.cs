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
public class AuthController(IAuthService authService, ILogger<AuthController> logger) : ControllerBase
{

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
        logger.LogTrace("Поступили данные для авторизации {@loginRequest}", loginRequest);

        try
        {
            var result = await authService.GetToken(loginRequest);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Ошибка при авторизации {@login}", loginRequest);
            return BadRequest(ex.Message);
        }
    }
}

