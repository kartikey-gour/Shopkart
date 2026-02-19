using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class RegisterRequestDto
    {
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

    }
}
