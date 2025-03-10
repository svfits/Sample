using Microsoft.EntityFrameworkCore;

namespace SF.DAL;

public class DataDbContext(DbContextOptions<DataDbContext> opt) : DbContext(opt)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .LogTo(Console.WriteLine)
        .EnableSensitiveDataLogging();

    public DbSet<User> User { get; set; }
}