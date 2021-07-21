using Microsoft.Extensions.DependencyInjection;
using NightClub.API.Authorization;
using static NightClub.Domain.Constants;

namespace NightClub.API.Configuration
{
    public static class AuthorizationConfig
    {

        public static IServiceCollection ResolveAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(ADMIN_POLICY, policy => policy.Requirements.Add(new IsAdminAuthorizationRequirement()));
            });

            return services;
        }
    }
}
