using GymApp.DataAccess.Data.Contexts;

namespace GymApp.DataAccess.Data.Seeder;

public static class DatabaseSeeder
{
    public static async Task SeedAllDataAsync(GymDbContext dbcontext)
    {
        await PlanSeeder.SeedDataAsync(dbcontext);
        await CategorySeeder.SeedDataAsync(dbcontext);
        await TrainerSeeder.SeedDataAsync(dbcontext);
        await MemberSeeder.SeedDataAsync(dbcontext);
        await SessionSeeder.SeedDataAsync(dbcontext);
        await HealthRecordSeeder.SeedDataAsync(dbcontext);
        await MembershipSeeder.SeedDataAsync(dbcontext);
        await BookingSeeder.SeedDataAsync(dbcontext);
    }
}
