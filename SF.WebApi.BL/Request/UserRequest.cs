using SF.DAL;

namespace SF.WebApi.BL.Request;

public class UserRequest
{
    /// <summary>
    /// Имя для тестов
    /// </summary>
    /// <example>Имя для тестов</example>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Тип пользователя 1 или 2
    /// </summary>
    /// <example>1</example>
    public TypeUser TypeUser { get; set; }
}
