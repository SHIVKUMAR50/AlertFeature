using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using Services;

namespace AlertAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IAlertService alertService,ITokenService tokenService) : ControllerBase
    {
        [HttpPost("/token")]
        public async Task<ActionResult<string>> GetToken(string userEmail,string password)
        {
            var token = await tokenService.GetToken(userEmail, password);
            return new JsonResult(token);
        }

        [HttpPost("/register")]
        public async Task< IActionResult> RegisterUser(string userEmail,string passWord)
        {
            await tokenService.RegisterUser(userEmail, passWord);
            return Ok();
        }


        //[HttpGet("/get")]
        ////[ProducesResponseType]
        //public async Task<IActionResult> GetUsers()
        //{
        //    // Simulate fetching users from a database
        //    var users = await alertService.GetAllUsers();
        //    return Ok(users);
        //   // return users;
        //}

        //[HttpGet("/get/typesafe")]
        //public async Task<ActionResult<Users[]>> GetUsersWithType()
        //{
        //    // Simulate fetching users from a database
        //    var users = await alertService.GetAllUsers();
        //    return users;
        //}
    }
}
