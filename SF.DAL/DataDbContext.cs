using Microsoft.EntityFrameworkCore;

namespace SF.DAL;

public class DataDbContext : DbContext
{
    public DataDbContext(DbContextOptions<DataDbContext> opt) : base(opt)
    {
            
    }

    public DbSet<User> User { get; set; }
}