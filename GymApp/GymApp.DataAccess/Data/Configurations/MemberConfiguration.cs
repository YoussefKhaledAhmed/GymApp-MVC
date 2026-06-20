using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.DataAccess.Data.Configurations;

public class MemberConfiguration : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
#warning TODO: apply reflection in the commonUserConfig file and remove this config from here
        builder.OwnsOne(m => m.Address, address =>
        {
            address.Property("BuildingNo").HasColumnName("BuildingNo");
            address.Property("Street").HasColumnName("Street");
            address.Property("City").HasColumnName("City");
        });
    }
}
