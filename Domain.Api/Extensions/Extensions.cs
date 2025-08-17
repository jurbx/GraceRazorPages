using Domain.Persistance;
using Domain.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Domain.Api.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureDomainServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("grace-furniture.s3-accelerate.amazonaws.com").AllowAnyMethod();
                                  });
            });

            services.AddDbContextFactory<ProgramDbContext>();
            services.AddScoped<ProgramDbContext>();
            services.ConfigureRepositories();
            services.ConfigureServices();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }

        public static IServiceCollection ConfigureAuth(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.AccessDeniedPath = "/";
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "GraceSAllowAdmin"));
            });

            return services;
        }
    }
}
