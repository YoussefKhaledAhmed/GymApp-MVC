using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;

namespace GymApp.DataAccess.Data.Seeder;

public static class CategorySeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (context.Categories.Any()) return;

        var categories = new List<Category>
        {
            new Category { Name = "Yoga" },
            new Category { Name = "Cardio" },
            new Category { Name = "Weightlifting" },
            new Category { Name = "Pilates" },
            new Category { Name = "CrossFit" }
        };

        await context.Categories.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }
}