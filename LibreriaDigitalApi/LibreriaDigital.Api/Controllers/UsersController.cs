using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Api.Data;
using LibreriaDigital.Api.Dtos;
using LibreriaDigital.Api.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BCrypt.Net;

namespace LibreriaDigital.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _db.Users.Select(u => new UserDto(u.Id, u.FirstName, u.LastName, u.Email)).ToListAsync());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user == null) return NotFound();
            return Ok(new UserDto(user.Id, user.FirstName, user.LastName, user.Email));
        }

        [Authorize]
        [HttpPut("me")]
        public async Task<IActionResult> UpdateMe([FromBody] UpdateUserDto dto)
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid == null) return Unauthorized();

            var userId = Guid.Parse(uid);
            var user = await _db.Users.FindAsync(userId);
            if (user == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(dto.FirstName)) user.FirstName = dto.FirstName;
            if (!string.IsNullOrWhiteSpace(dto.LastName)) user.LastName = dto.LastName;
            if (!string.IsNullOrWhiteSpace(dto.Email)) user.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.Password)) user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _db.SaveChangesAsync();
            return Ok(new UserDto(user.Id, user.FirstName, user.LastName, user.Email));
        }

        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> DeleteMe()
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid == null) return Unauthorized();

            var userId = Guid.Parse(uid);
            var user = await _db.Users.FindAsync(userId);
            if (user == null) return NotFound();

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
