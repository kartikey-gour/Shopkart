using Backend.Data;
using Backend.DTOs;
using Backend.Enums;
using Backend.Model;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _dbContext;
        public IPasswordHasher _passwordHasher;
        public Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            if(dto.Password != dto.ConfirmPassword) { }
            string normalizedEmail = dto.Email.Trim().ToLower();
            bool isExist = await _dbContext.Users.AnyAsync(u => u.Email == normalizedEmail);

            if (isExist) { }

            string hashedPassword = _passwordHasher.Hash(dto.Password);

            User user = new User
            {
                Email = normalizedEmail,
                Name = dto.Name,
                HashedPassword = hashedPassword,
                Role = UserRole.User,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Add(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
