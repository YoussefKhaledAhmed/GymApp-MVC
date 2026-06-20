using GymApp.DataAccess.Entities;
using GymApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymApp.DataAccess.Data.Configurations;

internal class HealthRecordConfiguration : IEntityTypeConfiguration<HealthRecord>
{
    public void Configure(EntityTypeBuilder<HealthRecord> builder)
    {
        var toDb = new Dictionary<BloodTypeEnum, string>
        {
            { BloodTypeEnum.APositive,  "A+" },
            { BloodTypeEnum.ANegative,  "A-" },
            { BloodTypeEnum.BPositive,  "B+" },
            { BloodTypeEnum.BNegative,  "B-" },
            { BloodTypeEnum.ABPositive, "AB+" },
            { BloodTypeEnum.ABNegative, "AB-" },
            { BloodTypeEnum.OPositive,  "O+" },
            { BloodTypeEnum.ONegative,  "O-" },
        };

        var fromDb = toDb.ToDictionary(x => x.Value, x => x.Key);


        builder.Property(hr => hr.Height).IsRequired();
        builder.Property(hr => hr.Weight).IsRequired();
        builder.Property(hr => hr.BloodType)
               .HasConversion(
                   b => toDb[b],
                   b => fromDb[b]
               );
        builder.Property(hr => hr.Note).IsRequired(false).HasMaxLength(150);

        // Relation
        builder.HasOne(hr => hr.Member)
               .WithOne(m => m.HealthRecord)
               .HasForeignKey<HealthRecord>(hr => hr.MemberId);
    }
}
