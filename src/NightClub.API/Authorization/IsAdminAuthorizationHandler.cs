using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;

namespace NightClub.API.Authorization
{
    public class IsAdminAuthorizationHandler : AuthorizationHandler<IsAdminAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdminAuthorizationRequirement requirement)
        {
            var permission = context.User?.Claims?.FirstOrDefault(x => x.Type == "permissions" && x.Value == requirement.ValidPermission);
            if (permission != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
