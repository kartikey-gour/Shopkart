using System.Net;

namespace Backend.Exceptions
{
    [Serializable]
    internal class UserAlreadyExistsException : AppException
    {
        public UserAlreadyExistsException() : base(HttpStatusCode.Conflict, "USER_ALREADY_EXISTS", "User with this email already exists.") {}
    }
}