using DbIntegation.Entitites;
using Microsoft.EntityFrameworkCore;

namespace DbIntegation.Database;

public class DbIntegrationDbContext:DbContext
{
    private readonly IConfiguration _configuration;

    public DbIntegrationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("AppConnection"));
        }
        catch (Exception)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BackupDatabase"));
        }
    }
}
