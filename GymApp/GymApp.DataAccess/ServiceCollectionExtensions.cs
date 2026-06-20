using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Filters;
using GymApp.DataAccess.Repository.MemberRepo;
using GymApp.DataAccess.Repository.PlanRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GymApp.DataAccess
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services , string connection)
        {
            services.AddSingleton<SoftDeleteInterceptor>();

            services.AddDbContext<GymDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>());
                options.UseSqlServer(connection);
            });
            services.AddScoped<IMemberRepository , MemberRepository>();
            services.AddScoped<IPlanRepository , PlanRepository>();
            return services;
        }
    }
}
