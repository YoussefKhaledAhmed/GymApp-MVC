using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Entities.OwnedEntites;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Configurations.GlobalConfigurations;

public static class CommonUserConfigurations
{ 
    public static void ApplyCommonUsersConfigurations(ModelBuilder modelBuilder)
    {
        foreach(var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(UserBaseEntity).IsAssignableFrom(entity.ClrType))
            {
                modelBuilder.Entity(entity.ClrType).Property("Name").HasMaxLength(100).IsRequired();
                modelBuilder.Entity(entity.ClrType).Property("Email").HasMaxLength(100).IsRequired();
                modelBuilder.Entity(entity.ClrType).Property("Phone").HasMaxLength(11).IsRequired();
                modelBuilder.Entity(entity.ClrType).Property("Gender").HasConversion<string>();
                
                modelBuilder.Entity(entity.ClrType)
                            .HasIndex("Phone")
                            .IsUnique();
                modelBuilder.Entity(entity.ClrType)
                            .HasIndex("Email")
                            .IsUnique();
            }
        }
    }
}
