using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SF.DAL;

public class User
{
    [Key]
    [Comment("Это ключ PK")]
    public int Key { get; set; }

    [Required]
    [Comment("Имя пользователя")]
    public string Name { get; set; } = null!;

    [Comment("Тип пользователя")]
    public TypeUser TypeUser { get; set; }
}

public enum TypeUser
{
    /// <summary>
    /// Админ
    /// </summary>
    Admin = 1,

    /// <summary>
    /// Обычный пользователь
    /// </summary>
    User = 2,
}