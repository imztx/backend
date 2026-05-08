using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vidrotec.Domain.Exceptions;

namespace Vidrotec.API
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException domainException)
            {
                await HandleExceptionAsync(context, HttpStatusCode.BadRequest, domainException.Message);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Ocorreu um erro interno.");
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            var result = JsonSerializer.Serialize(new { error = message });
            return context.Response.WriteAsync(result);
        }
    }
}
