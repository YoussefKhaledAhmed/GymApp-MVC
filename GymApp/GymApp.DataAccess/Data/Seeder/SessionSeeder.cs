using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class SessionSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.Sessions.AnyAsync()) return;

        var yogaCategory = await context.Categories.FirstAsync(c => c.Name == "Yoga");
        var cardioCategory = await context.Categories.FirstAsync(c => c.Name == "Cardio");
        var crossFitCategory = await context.Categories.FirstAsync(c => c.Name == "CrossFit");
        var weightliftingCategory = await context.Categories.FirstAsync(c => c.Name == "Weightlifting");

        var yogaTrainer = await context.Trainers.FirstAsync(t => t.Email == "ahmed.hassan@gym.com");
        var crossFitTrainer = await context.Trainers.FirstAsync(t => t.Email == "sara.mohamed@gym.com");
        var generalTrainer = await context.Trainers.FirstAsync(t => t.Email == "omar.ali@gym.com");
        var boxingTrainer = await context.Trainers.FirstAsync(t => t.Email == "layla.ibrahim@gym.com");

        var sessions = new List<Session>
        {
            new()
            {
                Description = "Morning Yoga Flow",
                Capacity = 15,
                StartDate = new DateTime(2025, 6, 10, 7, 0, 0),
                EndDate = new DateTime(2025, 6, 10, 8, 0, 0),
                TrainerId = yogaTrainer.Id,
                CategoryId = yogaCategory.Id,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Description = "HIIT Cardio Blast",
                Capacity = 20,
                StartDate = new DateTime(2025, 6, 10, 9, 0, 0),
                EndDate = new DateTime(2025, 6, 10, 10, 0, 0),
                TrainerId = generalTrainer.Id,
                CategoryId = cardioCategory.Id,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Description = "CrossFit WOD",
                Capacity = 12,
                StartDate = new DateTime(2025, 6, 11, 17, 0, 0),
                EndDate = new DateTime(2025, 6, 11, 18, 30, 0),
                TrainerId = crossFitTrainer.Id,
                CategoryId = crossFitCategory.Id,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Description = "Boxing Fundamentals",
                Capacity = 10,
                StartDate = new DateTime(2025, 6, 12, 18, 0, 0),
                EndDate = new DateTime(2025, 6, 12, 19, 0, 0),
                TrainerId = boxingTrainer.Id,
                CategoryId = cardioCategory.Id,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Description = "Strength Training Basics",
                Capacity = 8,
                StartDate = new DateTime(2025, 6, 13, 10, 0, 0),
                EndDate = new DateTime(2025, 6, 13, 11, 30, 0),
                TrainerId = generalTrainer.Id,
                CategoryId = weightliftingCategory.Id,
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            }
        };

        await context.Sessions.AddRangeAsync(sessions);
        await context.SaveChangesAsync();
    }
}
