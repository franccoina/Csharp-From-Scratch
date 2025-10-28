using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using LibreriaDigital.Api.Data;
using LibreriaDigital.Api.Models;
using LibreriaDigital.Api.Dtos;
using BCrypt.Net;

namespace LibreriaDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config;

        public AuthController(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var exists = await _db.Users.AnyAsync(u => u.Email == req.Email);
            if (exists) return BadRequest(new { message = "Email already registered" });

            var user = new User
            {
                FirstName = req.FirstName,
                LastName = req.LastName,
                Email = req.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password)
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();

            var token = GenerateToken(user);
            return Ok(new AuthResponse(token, user.Email, user.FirstName, user.LastName));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == req.Email);
            if (user == null) return Unauthorized();

            if (!BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash)) return Unauthorized();
            var token = GenerateToken(user);
            return Ok(new AuthResponse(token, user.Email, user.FirstName, user.LastName));
        }

        private string GenerateToken(User user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["DurationInMinutes"] ?? "1440"));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
