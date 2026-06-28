using Domain;
using Infrastructure;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public interface ITokenService
    {
        Task<string> GetToken(string username, string password);
        Task RegisterUser(string username, string password);
    }
    public class TokenService(AlertDbContext context) : ITokenService
    {
        public async Task<string> GetToken(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == username) ?? throw new Exception("User does not exist");
            if (user.Password == password)
            {
                var claims = new[]
                 {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Role, Enum.GetName((UserRole)user.UserRole)),
            new Claim(ClaimTypes.Email, user.Email)
        };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("603deb1015ca71be2b73aef0857d77811f352c073b6108d72d9810a30914df1a")
                );

                var credentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                );

                var token = new JwtSecurityToken(
                    issuer: "Authentication_Server",
                    audience: "AlertAPI",
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials
                );

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                return jwtToken;
            }
            throw new Exception("Invalid password");
        }
        public async Task RegisterUser(string userEmail, string password)
        {
            Users user = new()
            {
                Email = userEmail,
                Password = password,
                UserRole = 1,
                FullName=userEmail

            };
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
