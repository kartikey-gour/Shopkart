using Backend.DTOs;
using Backend.Exceptions;
using System.Net;
using System.Text.Json;

namespace Backend.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "Business exception occurred.");

                await HandleExceptionAsync(
                    context,
                    ex.StatusCode,
                    ex.ErrorCode,
                    ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred.");

                await HandleExceptionAsync(
                    context,
                    HttpStatusCode.InternalServerError,
                    "INTERNAL_SERVER_ERROR",
                    "Something went wrong.");
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string errorCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            ErrorResponseDto response = new ErrorResponseDto(
                message,
                errorCode,
                context.TraceIdentifier
            );

            string json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}
