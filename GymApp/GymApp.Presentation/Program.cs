using GymApp.BusinessLogic;
using GymApp.DataAccess;
using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Data.Seeder;
using GymApp.DataAccess.Filters;
using GymApp.DataAccess.Repository.GenericRepo;
using GymApp.DataAccess.Repository.PlanRepo;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDataAccess(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddBusinessLogic();

//builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.AddKeyedScoped<IPlanRepository, PlanRepository>("plan");
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<GymDbContext>();
    await dbContext.Database.MigrateAsync();
    await DatabaseSeeder.SeedAllDataAsync(dbContext);
}

app.Run();