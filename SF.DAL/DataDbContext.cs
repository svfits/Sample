using Microsoft.EntityFrameworkCore;

namespace SF.DAL;

public class DataDbContext(DbContextOptions<DataDbContext> opt) : DbContext(opt)
{
    public DbSet<User> User { get; set; }
}