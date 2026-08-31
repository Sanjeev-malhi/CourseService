using CourseService.Application.Common.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text.Json;

namespace CourseService.API.Middleware
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
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Resource Not Found");
                await WriteResponse(context, HttpStatusCode.NotFound, ex.Message);
            }

            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An unexpected error occurred");
                await WriteResponse(context, HttpStatusCode.InternalServerError, "An unexpected error occur");
            }
        }

            private static Task WriteResponse(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var response = new
            {
                StatusCode = context.Response.StatusCode,
                Message = message
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
