using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.DataAccess.Data.Configurations;

internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.Property(b => b.IsAttended)
               .IsRequired()
               .HasDefaultValue(false);

        builder.HasIndex(b => new
        {
            b.MemberId,
            b.SessionId
        }).IsUnique().HasFilter("[IsDeleted] = 0");
    }
}
