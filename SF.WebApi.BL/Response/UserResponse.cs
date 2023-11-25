using SF.DAL;
using System.Text.Json.Serialization;

namespace SF.WebApi.BL.Response;

public class UserResponse
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    [JsonPropertyName("id")]
    public int Key { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Тип пользователя
    /// </summary>
    public TypeUser TypeUser { get; set; }
}
