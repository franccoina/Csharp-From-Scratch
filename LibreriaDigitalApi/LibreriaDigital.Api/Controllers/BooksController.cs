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
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _db;
        public BooksController(AppDbContext db) { _db = db; }

        // List all books (public)
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _db.Books
                .Select(b => new BookDto(b.Id, b.Title, b.Author, b.PublishedYear, b.CoverImageUrl, b.OwnerId))
                .ToListAsync();
            return Ok(books);
        }

        // Get a single book with reviews
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await _db.Books
                .Include(b => b.Reviews)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return NotFound();

            var bookDto = new
            {
                book.Id,
                book.Title,
                book.Author,
                book.PublishedYear,
                book.CoverImageUrl,
                book.OwnerId,
                Reviews = book.Reviews?.Select(r => new { r.Id, r.Rating, r.Text, r.UserId, r.CreatedAt })
            };
            return Ok(bookDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine($"--------------------------------------------------------------------");
            Console.WriteLine($"UID from token: {uid}");
            Console.WriteLine($"UID from token: {ClaimTypes.NameIdentifier}");
            if (uid == null) return Unauthorized();

            var ownerId = Guid.Parse(uid);
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                PublishedYear = dto.PublishedYear,
                CoverImageUrl = dto.CoverImageUrl,
                OwnerId = ownerId
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = book.Id }, new BookDto(book.Id, book.Title, book.Author, book.PublishedYear, book.CoverImageUrl, book.OwnerId));
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto dto)
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid == null) return Unauthorized();

            var ownerId = Guid.Parse(uid);
            var book = await _db.Books.FindAsync(id);
            if (book == null) return NotFound();
            if (book.OwnerId != ownerId) return Forbid();

            if (!string.IsNullOrWhiteSpace(dto.Title)) book.Title = dto.Title;
            if (dto.Author != null) book.Author = dto.Author;
            if (dto.PublishedYear.HasValue) book.PublishedYear = dto.PublishedYear;
            if (dto.CoverImageUrl != null) book.CoverImageUrl = dto.CoverImageUrl;

            await _db.SaveChangesAsync();
            return Ok(new BookDto(book.Id, book.Title, book.Author, book.PublishedYear, book.CoverImageUrl, book.OwnerId));
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (uid == null) return Unauthorized();

            var ownerId = Guid.Parse(uid);
            var book = await _db.Books.FindAsync(id);
            if (book == null) return NotFound();
            if (book.OwnerId != ownerId) return Forbid();

            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
