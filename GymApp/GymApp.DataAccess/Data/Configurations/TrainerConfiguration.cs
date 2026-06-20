using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Entities.OwnedEntites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace GymApp.DataAccess.Data.Configurations;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
#warning TODO: apply reflection in the commonUserConfig file and remove this config from here
        builder.OwnsOne(t => t.Address, address =>
        {
            address.Property("BuildingNo").HasColumnName("BuildingNo");
            address.Property("Street").HasColumnName("Street");
            address.Property("City").HasColumnName("City");
        });
        builder.Property(t => t.Specialty).HasConversion<string>();
    }
}
