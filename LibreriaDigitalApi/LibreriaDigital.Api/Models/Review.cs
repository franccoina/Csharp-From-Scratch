using System.ComponentModel.DataAnnotations;

namespace LibreriaDigital.Api.Models
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Range(1,5)]
        public int Rating { get; set; }

        public string? Text { get; set; }

        // Owner
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
