using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using GymApp.Shared.Enums;
using GymApp.DataAccess.Entities.OwnedEntites;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class MemberSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.Members.AnyAsync()) return;

        var members = new List<Member>
        {
            new()
            {
                Name = "Karim Mahmoud",
                Email = "karim.mahmoud@email.com",
                Phone = "01112345601",
                DateOfBirth = new DateTime(1995, 5, 10),
                Gender = GenderEnum.Male,
                Address = new AddressDetails { BuildingNo = 3, Street = "Heliopolis", City = "Cairo" },
                JoinDate = new DateTime(2024, 3, 1),
                CreatedAt = new DateTime(2024, 3, 1),
                IsDeleted = false
            },
            new()
            {
                Name = "Nour El-Din",
                Email = "nour.eldin@email.com",
                Phone = "01112345602",
                DateOfBirth = new DateTime(1998, 9, 18),
                Gender = GenderEnum.Male,
                Address = new AddressDetails { BuildingNo = 18, Street = "Dokki", City = "Giza" },
                JoinDate = new DateTime(2024, 4, 15),
                CreatedAt = new DateTime(2024, 4, 15),
                IsDeleted = false
            },
            new()
            {
                Name = "Fatma Hassan",
                Email = "fatma.hassan@email.com",
                Phone = "01112345603",
                DateOfBirth = new DateTime(1993, 12, 5),
                Gender = GenderEnum.Female,
                Address = new AddressDetails { BuildingNo = 9, Street = "6th October", City = "Giza" },
                JoinDate = new DateTime(2024, 1, 20),
                CreatedAt = new DateTime(2024, 1, 20),
                IsDeleted = false
            },
            new()
            {
                Name = "Youssef Ahmed",
                Email = "youssef.ahmed@email.com",
                Phone = "01112345604",
                DateOfBirth = new DateTime(2000, 2, 28),
                Gender = GenderEnum.Male,
                Address = new AddressDetails { BuildingNo = 31, Street = "Alexandria Corniche", City = "Alexandria" },
                JoinDate = new DateTime(2024, 6, 10),
                CreatedAt = new DateTime(2024, 6, 10),
                IsDeleted = false
            },
            new()
            {
                Name = "Mona Saleh",
                Email = "mona.saleh@email.com",
                Phone = "01112345605",
                DateOfBirth = new DateTime(1997, 8, 14),
                Gender = GenderEnum.Female,
                Address = new AddressDetails { BuildingNo = 14, Street = "Smouha", City = "Alexandria" },
                JoinDate = new DateTime(2024, 5, 5),
                CreatedAt = new DateTime(2024, 5, 5),
                IsDeleted = false
            }
        };

        await context.Members.AddRangeAsync(members);
        await context.SaveChangesAsync();
    }
}
