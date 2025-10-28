using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaDigital.Api.Models
{
    public class Book
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Title { get; set; } = null!;

        public string? Author { get; set; }

        public int? PublishedYear { get; set; }

        public string? CoverImageUrl { get; set; }

        // Owner
        [Required]
        public Guid OwnerId { get; set; }
        public User? Owner { get; set; }

        public ICollection<Review>? Reviews { get; set; }
    }
}
