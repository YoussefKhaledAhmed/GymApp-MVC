using GymApp.DataAccess.Data.Configurations.GlobalConfigurations;
using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Filters;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GymApp.DataAccess.Data.Contexts;

public class GymDbContext : DbContext
{

    public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
    {
    }

    public GymDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new SoftDeleteInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
        GlobalQueryFilters.ApplySoftDeleteFilter(modelBuilder);
        CommonUserConfigurations.ApplyCommonUsersConfigurations(modelBuilder);
    }
    public DbSet<Member> Members { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Trainer> Trainers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Membership> Memberships { get; set; }
}
