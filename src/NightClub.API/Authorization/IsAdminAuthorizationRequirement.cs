using Microsoft.AspNetCore.Authorization;

namespace NightClub.API.Authorization
{
    public class IsAdminAuthorizationRequirement : IAuthorizationRequirement
    {
        public string ValidPermission = "admin";
    }
}
