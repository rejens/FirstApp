using FirstApp.Entity;
using Microsoft.EntityFrameworkCore;
namespace FirstApp.DataContext
;

public class AppDbContext:DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection"); // Get connection string from appsettings.json
        base.OnConfiguring(optionsBuilder); // This is for default configuration
        optionsBuilder.UseNpgsql(connectionString).UseSnakeCaseNamingConvention(); // UseSnakeCaseNamingConvention() is for converting PascalCase to snake_case

        
    }
    public DbSet<ClassInfo> ClassInfos { get; set; } // DbSet is for mapping table in database
    public DbSet<Faculty> Faculties { get; set; } // DbSet is for mapping table in database
    
}