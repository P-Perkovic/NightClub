using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using NightClub.API.Authorization;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Services;
using NightClub.Infrastructure.Context;
using NightClub.Infrastructure.Repositories;

namespace NightClub.API.Configuration
{
    public static class DependencyInjectionConfig
    {

        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<NightClubDbContext>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITableRepository, TableRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITableService, TableService>();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAdminConfigService, AdminConfigService>();
            services.AddScoped<IAdminConfigRepository, AdminConfigRepository>();

            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            services.AddSingleton<IAuthorizationHandler, IsAdminAuthorizationHandler>();

            return services;
        }
    }
}
