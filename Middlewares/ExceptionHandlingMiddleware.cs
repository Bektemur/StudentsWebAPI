using System.Text.Json;
using WebAPI.Service;

namespace WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                var (statusCode, message) = ex switch
                {
                    IServiceException serviceException => ((int)serviceException.StatusCode,
                    serviceException.Message),
                    _ => (StatusCodes.Status500InternalServerError, ex.Message ),
                };
                context.Response.StatusCode = statusCode;
                Microsoft.AspNetCore.Mvc.ProblemDetails problems = new()
                {
                    Title = "Error",
                    Status = statusCode,
                    Detail = message,
                };
                var json = JsonSerializer.Serialize(problems);
                await context.Response.WriteAsync(json);
            }

        }
    }
}
