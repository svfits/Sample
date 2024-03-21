using Microsoft.AspNetCore.Mvc;
using SF.DAL;
using SF.WebApi.BL.Atribute;
using SF.WebApi.BL.Request;
using SF.WebApi.BL.Response;
using SF.WebApi.BL.Services;
using System.Net.Mime;

namespace SF.WebApi.Controllers;

/// <summary>
/// Тут тоже может быть описание
/// </summary>
[ApiController]
[Route("[controller]")]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Получение клиентов
    /// </summary>
    /// <returns></returns>
    /// <response code="200">Все хорошо должны быть</response>
    /// <response code="400">Что то поломалось при получении</response>
    [HttpGet]
    [Authorize(TypeUser.Admin, TypeUser.User)]
    [ProducesResponseType(typeof(List<UserResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<UserResponse>>> GetUsers()
    {
        try
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Создание пользователя только для админов
    /// </summary>
    /// <param name="userRequest"></param>
    /// <returns>Вернется Id созданного клиента</returns>
    /// <response code="200">Все хорошо должны быть</response>
    /// <response code="400">Что то поломалось при получении</response>
    [HttpPost]
    [Authorize(TypeUser.Admin)]
    public async Task<ActionResult<int>> AddUser(UserRequest userRequest)
    {
        var result = await _userService.AddUser(userRequest);
        return Ok(result);
    }
}
