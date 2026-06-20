using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Data.Seeder;

public static class BookingSeeder
{
    public static async Task SeedDataAsync(GymDbContext context)
    {
        if (await context.Bookings.AnyAsync()) return;

        var members = await context.Members.ToListAsync();
        var sessions = await context.Sessions.ToListAsync();

        var bookings = new List<Booking>
        {
            new()
            {
                MemberId = members[0].Id,
                SessionId = sessions[0].Id,
                BookingDay = new DateTime(2025, 6, 9),
                IsAttended = true,
                CreatedAt = new DateTime(2025, 6, 8),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[1].Id,
                SessionId = sessions[1].Id,
                BookingDay = new DateTime(2025, 6, 9),
                IsAttended = false,
                CreatedAt = new DateTime(2025, 6, 8),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[2].Id,
                SessionId = sessions[2].Id,
                BookingDay = new DateTime(2025, 6, 10),
                IsAttended = true,
                CreatedAt = new DateTime(2025, 6, 9),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[3].Id,
                SessionId = sessions[3].Id,
                BookingDay = new DateTime(2025, 6, 11),
                IsAttended = false,
                CreatedAt = new DateTime(2025, 6, 10),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[4].Id,
                SessionId = sessions[0].Id,
                BookingDay = new DateTime(2025, 6, 9),
                IsAttended = true,
                CreatedAt = new DateTime(2025, 6, 7),
                IsDeleted = false
            },
            new()
            {
                MemberId = members[0].Id,
                SessionId = sessions[4].Id,
                BookingDay = new DateTime(2025, 6, 12),
                IsAttended = false,
                CreatedAt = new DateTime(2025, 6, 11),
                IsDeleted = false
            }
        };

        await context.Bookings.AddRangeAsync(bookings);
        await context.SaveChangesAsync();
    }
}
