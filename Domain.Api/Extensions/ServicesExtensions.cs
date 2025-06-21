using Domain.Persistance;
using Domain.Services;

namespace Domain.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddSingleton<ProgramDbContext>();
            services.ConfigureRepositories();
            services.ConfigureServices();

            return services;
        } 
    }
}
