using System.ComponentModel.DataAnnotations;

namespace LibreriaDigital.Api.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        // Navigation
        public ICollection<Book>? Books { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
