using Microsoft.AspNetCore.Mvc;
using UrmetJournal.Models;
using UrmetJournal.Services;

namespace UrmetJournal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _authService.Authenticate(request.Username, request.Password);

            if (user == null)
                return BadRequest(new { message = "Неверный логин или пароль" });

            var token = _authService.GenerateJwtToken(user);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
                GroupId = user.GroupId,
                Token = token
            });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}