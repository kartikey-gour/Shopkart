using System.Net;

namespace Backend.Exceptions
{
    [Serializable]
    internal class PasswordMismatchException : AppException
    {

        public PasswordMismatchException() : base(HttpStatusCode.BadRequest, "PASSWORD_MISMATCH", "Password and Confirm Password do not match."){}

    }
}