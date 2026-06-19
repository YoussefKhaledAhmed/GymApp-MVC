namespace GymApp.Data.Seeder;

public static class DatabaseSeeder
{
    public static async Task SeedAllDataAsync()
    {
        await PlanSeeder.SeedDataAsync();
    }
}
