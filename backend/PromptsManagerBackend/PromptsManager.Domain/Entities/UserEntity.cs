using System.ComponentModel.DataAnnotations;

namespace PromptsManager.Domain.Entities
{
    public class UserEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(256)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string EmailNormalized { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        // Lockout and brute-force protection
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }

    }
}
