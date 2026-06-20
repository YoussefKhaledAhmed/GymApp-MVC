using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class MembershipSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.Memberships.AnyAsync()) return;

        var members = await context.Members.ToListAsync();
        var standardPlan = await context.Plans.FirstAsync(p => p.Name == "Standard");
        var premiumPlan = await context.Plans.FirstAsync(p => p.Name == "Premium");
        var basicPlan = await context.Plans.FirstAsync(p => p.Name == "Basic");
        var studentPlan = await context.Plans.FirstAsync(p => p.Name == "Student");

        var memberships = new List<Membership>
        {
            new()
            {
                MemberId = members[0].Id,
                PlanId = standardPlan.Id,
                StartDate = new DateTime(2024, 3, 1),
                EndDate = new DateTime(2024, 3, 31),
                CreatedAt = new DateTime(2024, 3, 1),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[1].Id,
                PlanId = studentPlan.Id,
                StartDate = new DateTime(2024, 4, 15),
                EndDate = new DateTime(2024, 5, 15),
                CreatedAt = new DateTime(2024, 4, 15),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[2].Id,
                PlanId = premiumPlan.Id,
                StartDate = new DateTime(2024, 1, 20),
                EndDate = new DateTime(2024, 2, 19),
                CreatedAt = new DateTime(2024, 1, 20),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[3].Id,
                PlanId = basicPlan.Id,
                StartDate = new DateTime(2024, 6, 10),
                EndDate = new DateTime(2024, 7, 10),
                CreatedAt = new DateTime(2024, 6, 10),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[4].Id,
                PlanId = standardPlan.Id,
                StartDate = new DateTime(2024, 5, 5),
                EndDate = new DateTime(2024, 6, 4),
                CreatedAt = new DateTime(2024, 5, 5),
                IsDeleted = false
            }
        };

        await context.Memberships.AddRangeAsync(memberships);
        await context.SaveChangesAsync();
    }
}
