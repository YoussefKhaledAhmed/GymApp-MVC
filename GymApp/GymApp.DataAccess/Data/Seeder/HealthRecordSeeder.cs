using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using GymApp.Shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class HealthRecordSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.HealthRecords.AnyAsync()) return;

        var members = await context.Members.ToListAsync();

        var healthRecords = new List<HealthRecord>
        {
            new()
            {
                MemberId = members[0].Id,
                Height = 178,
                Weight = 82,
                BloodType = BloodTypeEnum.OPositive,
                Note = "No known allergies. Cleared for all activities.",
                CreatedAt = new DateTime(2024, 3, 1),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[1].Id,
                Height = 175,
                Weight = 70,
                BloodType = BloodTypeEnum.APositive,
                Note = "Mild knee injury history. Avoid high-impact exercises.",
                CreatedAt = new DateTime(2024, 4, 15),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[2].Id,
                Height = 165,
                Weight = 58,
                BloodType = BloodTypeEnum.BNegative,
                Note = "Vegetarian diet. No restrictions.",
                CreatedAt = new DateTime(2024, 1, 20),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[3].Id,
                Height = 182,
                Weight = 75,
                BloodType = BloodTypeEnum.ABPositive,
                Note = "Asthma - inhaler available during sessions.",
                CreatedAt = new DateTime(2024, 6, 10),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[4].Id,
                Height = 168,
                Weight = 62,
                BloodType = BloodTypeEnum.ONegative,
                Note = "Regular yoga practitioner. Flexible schedule.",
                CreatedAt = new DateTime(2024, 5, 5),
                IsDeleted = false
            }
        };

        await context.HealthRecords.AddRangeAsync(healthRecords);
        await context.SaveChangesAsync();
    }
}
