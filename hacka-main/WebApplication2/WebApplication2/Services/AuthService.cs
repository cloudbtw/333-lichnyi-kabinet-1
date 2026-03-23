using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UrmetJournal.Models;

namespace UrmetJournal.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "student", Password = "student123", Role = "student", GroupId = 1 },
            new User { Id = 2, Username = "teacher", Password = "teacher123", Role = "teacher", GroupId = 1 },
            new User { Id = 3, Username = "admin", Password = "admin123", Role = "admin", GroupId = 0 },
            new User { Id = 4, Username = "coach", Password = "coach123", Role = "coach", GroupId = 1}
        };

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Authenticate(string username, string password)
        {
            return _users.FirstOrDefault(u =>
                u.Username == username &&
                u.Password == password);
        }

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("GroupId", user.GroupId.ToString())
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}