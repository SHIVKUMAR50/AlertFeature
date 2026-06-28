using Microsoft.AspNetCore.Mvc;

namespace AlertAPI.RoleAuthorizationFilter
{
    public class RoleAuthorizeAttribute:TypeFilterAttribute
    {
        public RoleAuthorizeAttribute(string role):base(typeof(RoleAuthorizeFilter))
        {
            Arguments = new object[] { role };
        }
    }
}
