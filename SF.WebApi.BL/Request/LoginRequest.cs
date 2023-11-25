using System.ComponentModel.DataAnnotations;

namespace SF.WebApi.BL.Request;

public class LoginRequest
{
    /// <summary>
    /// Тут надо передать id пользователя
    /// </summary>
    /// <example>2</example>
    [Required(ErrorMessage = "Это обязательное поле")]
    [Range(1, 130, ErrorMessage = "Должен быть в интервале {1} {2}")]
    public int Id { get; set; }
}
