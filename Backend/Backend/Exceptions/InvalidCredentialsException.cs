namespace Backend.Exceptions
{
    [Serializable]
    internal class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException(string? message) : base(message){}
    }
}