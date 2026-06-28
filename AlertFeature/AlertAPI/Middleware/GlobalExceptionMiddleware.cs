using Domain;
using System.Text.Json;

namespace AlertAPI.Middleware
{
    public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError("Unhandled exception occured");
                await HandleExceptionAsync(ex, context);
            }

        }

        private static async Task HandleExceptionAsync(Exception ex, HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var response = new ErrorResponse
            {
                StatusCode = GetStatusCode(ex),
                Message = "Something went wrong",
                Details = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "prod") ? ex.Message : null //for production we will set this to null as we do not want to expose sensitive information
            };
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }

        private static int GetStatusCode(Exception ex)
        {
            return ex switch
            {
                ArgumentException => StatusCodes.Status400BadRequest,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                KeyNotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
        }
    }
}