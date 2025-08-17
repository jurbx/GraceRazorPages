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
            services.AddScoped<IHomeSlideRepository, HomeSlideRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }
    }
}
