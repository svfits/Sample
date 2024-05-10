using Microsoft.EntityFrameworkCore;
using SF.DAL;
using SF.WebApi.BL.Request;

namespace SF.WebApi.BL.Services;

public interface IAuthService
{
    Task<string> GetToken(LoginRequest loginRequest);
}

public class AuthService(IJwtService jwtService, DataDbContext dataDbContext) : IAuthService
{
    private readonly IJwtService _jwtService = jwtService;
    private readonly DataDbContext _dataDbContext = dataDbContext;

    public async Task<string> GetToken(LoginRequest loginRequest)
    {
        var user = await _dataDbContext.User.FirstAsync(f => f.Key == loginRequest.Id);

        var token = _jwtService.GenerationTokenStation(user.Key);

        return token;
    }
}
