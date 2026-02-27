namespace Backend.DTOs
{
    public class ErrorResponseDto
    {
        public ErrorResponseDto(string message, string errorCode, string traceIdentifier)
        {
            Code = errorCode;
            Message = message;
            TraceId = traceIdentifier;
        }

        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string Code { get; set; }
        public string TraceId { get; set; }
    }
}
