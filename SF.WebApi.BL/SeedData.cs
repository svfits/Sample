using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SF.DAL;

namespace SF.WebApi.BL;

public class SeedData
{
    public static async Task CreatedAdmin(IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var db = scope.ServiceProvider.GetService<DataDbContext>();

        var isAdmin = await db!.User.FirstOrDefaultAsync(s => s.TypeUser == TypeUser.Admin);
        if (isAdmin == null)
        {
            await db.User.AddAsync(new User() { Name = "Супер Админ", TypeUser = TypeUser.Admin });
            await db.SaveChangesAsync();
        }

        var isUser = await db!.User
            .TagWith("Тут выполняется какой то запрос").FirstOrDefaultAsync(s => s.TypeUser == TypeUser.User);
        if (isUser == null)
        {
            await db.User.AddAsync(new User() { Name = "Простой пользователь", TypeUser = TypeUser.User });
            await db.SaveChangesAsync();
        }
    }
}