using Domain.Persistance.Contracts.Repositories;
using Domain.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Persistance
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
