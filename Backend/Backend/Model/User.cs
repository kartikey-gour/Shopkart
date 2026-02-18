using Backend.Enums;

namespace Backend.Model
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public string Email { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        
    }
}