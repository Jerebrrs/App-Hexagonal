
using App_Hexagonal.Domain.Error;
using App_Hexagonal.Domain.student.exception;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace App_Hexagonal.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
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
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger logger)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string errorMessage = "Ocurrió un error inesperado.";

            // Mapear excepciones personalizadas
            if (exception is StudentNotFountException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                errorMessage = "Recurso no encontrado.";
            }
            // Aquí puedes agregar más mapeos de excepciones personalizadas

            response.StatusCode = statusCode;

            logger.LogError(exception, "[ErrorHandlingMiddleware] {Message}", exception.Message);

            var errorResponse = new ErrorResponse
            {
                Code = statusCode,
                ErrorMessage = errorMessage,
                Details = new List<string> { exception.Message }
            };

            var result = JsonSerializer.Serialize(errorResponse);
            return response.WriteAsync(result);
        }
    }
}
