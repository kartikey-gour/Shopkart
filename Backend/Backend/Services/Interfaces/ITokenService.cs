using Backend.Model;

namespace Backend.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
