using System.Net;
using System.Text.Json;
using CricBazaar.Application.Common;
using FluentValidation;

namespace CricBazaar.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(context,HttpStatusCode.BadRequest,ex.Message);
            }
            catch (ArgumentException ex)
            {
                await HandleExceptionAsync(context,HttpStatusCode.BadRequest,ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(context,HttpStatusCode.Unauthorized,ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                await HandleExceptionAsync(context,HttpStatusCode.Forbidden,ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(context,HttpStatusCode.NotFound,ex.Message);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context,HttpStatusCode.InternalServerError,"An unexpected error occurred.");
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context,HttpStatusCode statusCode,string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new ApiResponse<object>
            {
                Success = false,
                Message = message,
                Data = null
            };

            var json = JsonSerializer.Serialize(response);

            await context.Response.WriteAsync(json);
        }
    }
}