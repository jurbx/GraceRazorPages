using Domain.Services.Contracts.Services;
using Domain.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IHomeSlideService, HomeSlideService>();
            services.AddScoped<ICategoryService, CategoryService>();


            services.AddScoped<IS3BucketService, S3BucketService>();

            return services;
        }
    }
}
