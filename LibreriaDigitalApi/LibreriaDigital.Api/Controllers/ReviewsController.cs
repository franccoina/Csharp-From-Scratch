using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using LibreriaDigital.Api.Data;
using LibreriaDigital.Api.Dtos;
using LibreriaDigital.Api.Models;

namespace LibreriaDigital.Api.Controllers
{
    [ApiController]
    [Route("api/books/{bookId:guid}/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ReviewsController(AppDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid bookId)
        {
            var exists = await _db.Books.AnyAsync(b => b.Id == bookId);
            if (!exists) return NotFound();

            var reviews = await _db.Reviews
                .Where(r => r.BookId == bookId)
                .Select(r => new ReviewDto(r.Id, r.Rating, r.Text, r.UserId, r.BookId, r.CreatedAt))
                .ToListAsync();
            return Ok(reviews);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Guid bookId, [FromBody] CreateReviewDto dto)
        {
            if (dto.Rating < 1 || dto.Rating > 5) return BadRequest(new { message = "Rating must be 1-5" });

            var book = await _db.Books.FindAsync(bookId);
            if (book == null) return NotFound();

            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid == null) return Unauthorized();
            var userId = Guid.Parse(uid);

            var review = new Review
            {
                Rating = dto.Rating,
                Text = dto.Text,
                BookId = bookId,
                UserId = userId
            };

            _db.Reviews.Add(review);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { bookId = bookId }, new ReviewDto(review.Id, review.Rating, review.Text, review.UserId, review.BookId, review.CreatedAt));
        }
    }
}
