using Microsoft.EntityFrameworkCore; // To use DbContext

namespace ServerUtilities;

public class AppDbContext : DbContext
{
    public DbSet<Server> Servers { get; set; }
    public DbSet<DatabaseServer> DatabaseServers { get; set; } // Adds Table-Per-Hierarchy (TPH) awareness!
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        string databaseFile = "netdash.db";
        string path = Path.Combine(Environment.CurrentDirectory, databaseFile);
        string connectionString = $"Data Source={path}";
        optionsBuilder.UseSqlite(connectionString);
    }
}