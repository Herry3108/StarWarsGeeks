using Microsoft.EntityFrameworkCore;
using StarWarsGeeks.Business.Models;

namespace StarWarsGeeks.Database.Context;
public class StarWarsDbContext : DbContext
{
    public StarWarsDbContext(DbContextOptions<StarWarsDbContext> options) : base(options) { }

    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Planet> Planets { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Person entity configuration
        _ = modelBuilder.Entity<Person>().HasKey(p => p.Name);
        _ = modelBuilder.Entity<Person>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        _ = modelBuilder.Entity<Person>().Property(p => p.Height).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.Mass).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.HairColor).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.SkinColor).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.EyeColor).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.BirthYear).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.Gender).HasMaxLength(50);
        _ = modelBuilder.Entity<Person>().Property(p => p.Homeworld).HasMaxLength(100);

        // Planet entity configuration
        _ = modelBuilder.Entity<Planet>().HasKey(p => p.Name);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Name).IsRequired().HasMaxLength(100);
        _ = modelBuilder.Entity<Planet>().Property(p => p.RotationPeriod).HasMaxLength(50);
        _ = modelBuilder.Entity<Planet>().Property(p => p.OrbitalPeriod).HasMaxLength(50);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Diameter).HasMaxLength(50);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Climate).HasMaxLength(200);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Gravity).HasMaxLength(50);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Terrain).HasMaxLength(200);
        _ = modelBuilder.Entity<Planet>().Property(p => p.SurfaceWater).HasMaxLength(50);
        _ = modelBuilder.Entity<Planet>().Property(p => p.Population).HasMaxLength(50);
    }
}
