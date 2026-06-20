using GymApp.BusinessLogic.Services.MemberServices;
using GymApp.BusinessLogic.Services.Plan;
using Microsoft.Extensions.DependencyInjection;

namespace GymApp.BusinessLogic
{
    public static class ServiceCollectionExtensions 
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IMemberService , MemberService>();
            services.AddScoped<IPlanService , PlanService>();
            return services;
        }
    }
}
