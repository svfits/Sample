using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SF.WebApi.BL.Services;

public interface IJwtService
{
    public string GenerationTokenStation(int userId);
}

public class JwtService : IJwtService
{
    public string GenerationTokenStation(int userId)
    {
        var key = "Тут ключ для подписи111111111111";

        var claims = new List<Claim> { new Claim("UserId", userId.ToString()) };
        var jwt = new JwtSecurityToken(
                issuer: "Кто выдал токен",
                audience: "Для кого выдан",
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)), SecurityAlgorithms.HmacSha256));

        var tokenHandler = new JwtSecurityTokenHandler().WriteToken(jwt);
        return tokenHandler.ToString();
    }
}
