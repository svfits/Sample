using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SF.DAL;
using SF.WebApi.BL.Request;
using SF.WebApi.BL.Response;
using System.Diagnostics.CodeAnalysis;

namespace SF.WebApi.BL.Services;

public interface IUserService
{
    Task<List<UserResponse>> GetUsers();

    Task<int> AddUser(UserRequest userRequest);
}

public class UserService(DataDbContext dataDbContext, IMapper mapper, ILogger<UserService> logger) : IUserService
{
    private readonly DataDbContext _dataDbContext = dataDbContext;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<UserService> _logger = logger;

    public async Task<List<UserResponse>> GetUsers()
    {
        var users = await _dataDbContext.User.ToListAsync();

        var result = _mapper.Map<List<UserResponse>>(users);

        _logger.LogInformation("Был запрошен список всех пользователей {@result }", result);
        return result;
    }

    public async Task<int> AddUser(UserRequest userRequest)
    {
        throw new NotImplementedException("Ошибка!!!");

        var userDb = _mapper.Map<User>(userRequest);

        await _dataDbContext.User.AddAsync(userDb);
        await _dataDbContext.SaveChangesAsync();

        return userDb.Key;
    }
}
