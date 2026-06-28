using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlertAPI.RoleAuthorizationFilter
{
    public class RoleAuthorizeFilter(AlertDbContext alertDbContext, string requiredRole) : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var userEmail = context.HttpContext.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value;
            if (userEmail is null)
            {
                context.Result = new UnauthorizedResult();
            }
            var userRole = alertDbContext.Users.Where(x => x.Email == userEmail).Select(x => x.UserRole).ToList();
            var role = userRole[0];
            var name = Enum.GetName((UserRole)role);
            if (!String.Equals(name, requiredRole, StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
