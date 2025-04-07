using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Context;
using AuthService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AuthService.Service
{
    public class AuthService(AuthDbContext authDbContext) : IAuthService
    {
        private readonly AuthDbContext _authDbContext;

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super_secret_key"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "authService",
                audience: "foodDeliveryApp",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<User> AuthenticateUser(RequestDto loginUser)
        {
            var user = await _authDbContext.Users.AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Email == loginUser.EmailId && u.Password == loginUser.Password);

            if (user == null) return null;

            return user;
        }
    }
}
