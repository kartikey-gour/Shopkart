using Backend.Enums;

namespace Backend.DTOs
{
    public class AuthResponseDto
    {
        public string? Token { get; set; }
        public string? Email { get; set; }
        public UserRole? Role { get; set; }
    }
}