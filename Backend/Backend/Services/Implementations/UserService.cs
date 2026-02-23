using Backend.Data;
using Backend.DTOs;
using Backend.Enums;
using Backend.Model;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _dbContext;
        public IPasswordHasher _passwordHasher;
        public ITokenService _tokenService;

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            string normalizedEmail = dto.ema;
            User user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == normalizedEmail);
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
            if (dto.Password != dto.ConfirmPassword) { }
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

            return new AuthResponseDto { Token = _tokenService.GenerateToken(user), Role = user.Role, Email = user.Email };
        }
    }
}
