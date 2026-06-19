using GymApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymApp.Data.Contexts;

public class GymDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=GymTestDb;Trusted_Connection=True;TrustServerCertificate = true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
    }

    public DbSet<Plan> Plans { get; set; }
}
