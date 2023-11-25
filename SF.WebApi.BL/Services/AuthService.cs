using Microsoft.EntityFrameworkCore;
using SF.DAL;
using SF.WebApi.BL.Request;

namespace SF.WebApi.BL.Services;

public interface IAuthService
{
    Task<string> GetToken(LoginRequest loginRequest);
}

public class AuthService : IAuthService
{
    private readonly IJwtService _jwtService;
    private readonly DataDbContext _dataDbContext;

    public AuthService(IJwtService jwtService, DataDbContext dataDbContext)
    {
        _jwtService = jwtService;
        _dataDbContext = dataDbContext;
    }

    public async Task<string> GetToken(LoginRequest loginRequest)
    {
        var user = await _dataDbContext.User.FirstAsync(f => f.Key == loginRequest.Id);

        var token = _jwtService.GenerationTokenStation(user.Key);

        return token;
    }
}
