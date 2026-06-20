using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class PlanSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        bool hasAnyPlans = await context.Plans.AnyAsync();

        if (hasAnyPlans) return;

        List<Plan> plans = new()
        {
            new Plan
            {
                Name = "Basic",
                Description = "Access to gym floor and standard equipment during off-peak hours.",
                Price = 19.99m,
                DurationDays = 30,
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = null,
                IsDeleted = false,
                DeletedAt = null
            },
            new Plan
            {
                Name = "Standard",
                Description = "Full gym access during all operating hours including group classes.",
                Price = 39.99m,
                DurationDays = 30,
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = null,
                IsDeleted = false,
                DeletedAt = null
            },
            new Plan
            {
                Name = "Premium",
                Description = "Unlimited gym access, group classes, personal trainer sessions, and sauna.",
                Price = 69.99m,
                DurationDays = 30,
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 3, 15),
                IsDeleted = false,
                DeletedAt = null
            },
            new Plan
            {
                Name = "Student",
                Description = "Discounted full gym access for enrolled students. Valid ID required.",
                Price = 24.99m,
                DurationDays = 30,
                IsActive = true,
                CreatedAt = new DateTime(2024, 2, 1),
                UpdatedAt = null,
                IsDeleted = false,
                DeletedAt = null
            },
            new Plan
            {
                Name = "Annual Basic",
                Description = "Full year of basic gym access at a discounted rate.",
                Price = 199.99m,
                DurationDays = 365,
                IsActive = true,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 4, 10),
                IsDeleted = false,
                DeletedAt = null
            },
            new Plan
            {
                Name = "Summer Promo",
                Description = "Limited summer access plan. Gym floor only, no classes.",
                Price = 14.99m,
                DurationDays = 90,
                IsActive = false,
                CreatedAt = new DateTime(2023, 5, 1),
                UpdatedAt = new DateTime(2023, 9, 1),
                IsDeleted = true,
                DeletedAt = new DateTime(2023, 9, 1)
            },
        };

        await context.Plans.AddRangeAsync(plans);
        await context.SaveChangesAsync();
    }
}
