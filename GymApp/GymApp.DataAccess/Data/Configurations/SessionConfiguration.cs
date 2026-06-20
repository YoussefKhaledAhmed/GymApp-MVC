using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.DataAccess.Data.Configurations;

internal class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.Property(s => s.Description).HasMaxLength(100);
        builder.ToTable(tb =>
        {
            tb.HasCheckConstraint("CX_Session_Capacity",
                "Capacity BETWEEN 1 AND 25");
        });
        builder.HasOne(s => s.Trainer)
               .WithMany(t => t.Sessions)
               .HasForeignKey(s => s.TrainerId);
        builder.HasOne(s => s.Category)
               .WithMany(t => t.Sessions)
               .HasForeignKey(s => s.CategoryId);

        builder.ToTable(tb =>
        {
            tb.HasCheckConstraint(
                "CK_Sessions_DateRange",
                 "[EndDate] > [StartDate]"
                );
        });
    }
}
