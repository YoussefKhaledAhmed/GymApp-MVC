using GymApp.Data.Contexts;
using GymApp.Data.Seeder;
using GymApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Fix 1: register GymDbContext
builder.Services.AddDbContext<GymDbContext>();

// Fix 2: register the filter only once via AddScoped
builder.Services.AddScoped<SoftDeleteInterceptor>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<SoftDeleteInterceptor>();
});  

var app = builder.Build();

app.UseRouting();

app.MapStaticAssets();

// convesional routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

await DatabaseSeeder.SeedAllDataAsync();

app.Run();