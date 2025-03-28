using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PathfinderSecondEdition;

public class CharacterSheetDbContext : DbContext
{
    public DbSet<CharacterSheetModel> CharacterSheetModels { get; set; }
    public DbSet<AbilityScore> AbilityScores { get; set; }
    public string DbPath { get; private set; }

    public CharacterSheetDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        if (!Directory.Exists($"{path}\\Centuras"))
        {
            path = $"{path}\\Centuras";
            Directory.CreateDirectory(path);
        }
        else
        {
            path = $"{path}\\Centuras";
        }
        DbPath = Path.Combine(path, "CharacterSheetDb1.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
