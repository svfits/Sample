using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using SF.DAL;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SF.WebApi.Middleware;

public class AuthMiddleWare
{
    private readonly RequestDelegate _next;

    public AuthMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, DataDbContext adminDbContext)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            await AttachUserToContext(context, adminDbContext, token);
        }

        await _next(context);
    }

    private static async Task AttachUserToContext(HttpContext context, DataDbContext dBContext, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Тут ключ для подписи111111111111");
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.MaxValue
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            int accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserId").Value);

            // attach account to context on successful jwt validation
            var user = await dBContext.User.FindAsync(accountId);

            context.Items["LoggedInUser"] = user;
        }
        catch
        {
            // do nothing if jwt validation fails
            // account is not attached to context so request won't have access to secure routes
        }
    }
}

