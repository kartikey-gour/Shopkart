namespace Backend.Exceptions
{
    [Serializable]
    public class InvalidCredentialsException : AppException
    {
        public InvalidCredentialsException(string? message) : base(message){}
    }
}