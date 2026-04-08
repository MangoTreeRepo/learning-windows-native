// To use SqlConnectionStringBuilder.
using Microsoft.Data;

// To use DbContext, DbSet<T>.
using Microsoft.EntityFrameworkCore;

namespace NorthWind.EntityModels;

public class NorthwindDb : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string database = "Northwind.db";
        string dir = Environment.CurrentDirectory;
        string path = Path.Combine(dir, database);
        path = Path.GetFullPath(path);
        WriteLine($"SQLite database path: {path}");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(message: $"{path} not found.", fileName: path);
        }

        optionsBuilder.UseSqlite($"Data Source={path}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (Database.ProviderName is not null && Database.ProviderName.Contains("Sqlite"))
        {
            modelBuilder.Entity<Product>()
                .Property(product => product.UnitPrice)
                .HasConversion<double>();
        }
    }

}