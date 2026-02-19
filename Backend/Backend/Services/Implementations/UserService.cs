using Backend.Data;
using Backend.DTOs;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _DbContext;
        public IPasswordHasher 
        public Task<AuthResponseDto> LoginAsync(LoginRequestDto dto)
        {
        }

        public Task<AuthResponseDto> RegisterAsync(RegisterRequestDto dto)
        {
        }
    }
}
