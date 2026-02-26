using System.Net;

namespace Backend.Exceptions
{
    [Serializable]
    public class InvalidCredentialsException : AppException
    {
        public InvalidCredentialsException() : base(HttpStatusCode.Unauthorized, "INVALID_CREDENTIALS", "Invalid email or password.") {}
    }
}