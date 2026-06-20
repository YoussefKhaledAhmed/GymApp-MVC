using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using GymApp.Shared.Enums;
using GymApp.DataAccess.Entities.OwnedEntites;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class TrainerSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.Trainers.AnyAsync()) return;

        var trainers = new List<Trainer>
        {
            new()
            {
                Name = "Ahmed Hassan",
                Email = "ahmed.hassan@gym.com",
                Phone = "01012345601",
                DateOfBirth = new DateTime(1988, 3, 15),
                Gender = GenderEnum.Male,
                Address = new AddressDetails { BuildingNo = 12, Street = "Tahrir St", City = "Cairo" },
                Specialty = FitnessSpecialtyEnum.Yoga,
                HireDate = new DateTime(2020, 6, 1),
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Name = "Sara Mohamed",
                Email = "sara.mohamed@gym.com",
                Phone = "01012345602",
                DateOfBirth = new DateTime(1992, 7, 22),
                Gender = GenderEnum.Female,
                Address = new AddressDetails { BuildingNo = 45, Street = "Nasr City", City = "Cairo" },
                Specialty = FitnessSpecialtyEnum.CrossFit,
                HireDate = new DateTime(2021, 2, 10),
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Name = "Omar Ali",
                Email = "omar.ali@gym.com",
                Phone = "01012345603",
                DateOfBirth = new DateTime(1985, 11, 8),
                Gender = GenderEnum.Male,
                Address = new AddressDetails { BuildingNo = 7, Street = "Zamalek", City = "Cairo" },
                Specialty = FitnessSpecialtyEnum.GeneralFitness,
                HireDate = new DateTime(2019, 9, 15),
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new()
            {
                Name = "Layla Ibrahim",
                Email = "layla.ibrahim@gym.com",
                Phone = "01012345604",
                DateOfBirth = new DateTime(1990, 1, 30),
                Gender = GenderEnum.Female,
                Address = new AddressDetails { BuildingNo = 22, Street = "Maadi", City = "Cairo" },
                Specialty = FitnessSpecialtyEnum.Boxing,
                HireDate = new DateTime(2022, 4, 20),
                CreatedAt = new DateTime(2024, 1, 1),
                IsDeleted = false
            }
        };

        await context.Trainers.AddRangeAsync(trainers);
        await context.SaveChangesAsync();
    }
}
