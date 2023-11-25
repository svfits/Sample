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

public class UserService : IUserService
{
    private readonly DataDbContext _dataDbContext;
    private readonly IMapper _mapper;
    private readonly ILogger<UserService> _logger;

    public UserService(DataDbContext dataDbContext, IMapper mapper, ILogger<UserService> logger)
    {
        _dataDbContext = dataDbContext;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<UserResponse>> GetUsers()
    {
        var users = await _dataDbContext.User.ToListAsync();

        var result = _mapper.Map<List<UserResponse>>(users);

        _logger.LogInformation("Был запрошен список всех пользователей {@result }", result);
        return result;
    }

    public async Task<int> AddUser(UserRequest userRequest)
    {
        var userDb = _mapper.Map<User>(userRequest);

        await _dataDbContext.User.AddAsync(userDb);
        await _dataDbContext.SaveChangesAsync();

        return userDb.Key;
    }
}
