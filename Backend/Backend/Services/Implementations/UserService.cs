using Backend.Data;
using Backend.DTOs;
using Backend.Enums;
using Backend.Exceptions;
using Backend.Model;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Authentication;

namespace Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _dbContext;
        public IPasswordHasher _passwordHasher;
        public ITokenService _tokenService;

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
            string normalizedEmail = dto.Email.Trim().ToLower();
            User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == normalizedEmail);

            if (user == null)
            {
                throw new InvalidCredentialsException("Invalid creadential");
            }

            bool isValid = _passwordHasher.Verify(dto.Password, user.HashedPassword);

            if (!isValid)
                throw new InvalidCredentialsException("Invalid creadential");

            string token = _tokenService.GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
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
