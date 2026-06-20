using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.DataAccess.Data.Configurations;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.ToTable(tb =>
        {
            tb.HasCheckConstraint(
                "CK_MemberShip_DateRange",
                "[EndDate] > [StartDate]"
                );
        });

        builder.HasIndex(ms => new
        {
            ms.MemberId,
            ms.PlanId
        }).IsUnique().HasFilter("[IsDeleted] = 0");

    }
}
