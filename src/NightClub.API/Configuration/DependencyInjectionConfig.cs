using Microsoft.Extensions.DependencyInjection;
using NightClub.Domain.Interfaces;
using NightClub.Domain.Services;
using NightClub.Infrastructure.Context;
using NightClub.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            return services;
        }
    }
}
