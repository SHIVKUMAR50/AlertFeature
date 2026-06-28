using AlertAPI.RoleAuthorizationFilter;
using Domain;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace AlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")] //This filter is based on JWT  token claim
    //[RoleAuthorize("Administrator")]
    public class AlertController(IAlertService alertService) : ControllerBase
    {
        [HttpGet("/alerts")]
        public async Task<ActionResult<List<AlertResponse>>> GetAllAlertsForUser()
        {
            var userEmail = User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value ?? throw new Exception("Claim not found");
            var alerts = await alertService.GetAlertInfo(userEmail);
            
            return alerts;
        }
    }
}
