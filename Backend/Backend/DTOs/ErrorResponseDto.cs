namespace Backend.DTOs
{
    public class ErrorResponseDto
    {
        public ErrorResponseDto(string message, string errorCode, string traceIdentifier)
        {
            Message = message;
            Code = errorCode;
            TraceId = traceIdentifier;
        }

        public bool Success { get; set; } = false;
        public string Message { get; set; }
        public string Code { get; set; }
        public string TraceId { get; set; }
    }
}
