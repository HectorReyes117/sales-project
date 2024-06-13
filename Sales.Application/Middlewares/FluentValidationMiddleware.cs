using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Sales.Application.Middlewares;

public class FluentValidationMiddleware
{
    private readonly RequestDelegate _next;

    public FluentValidationMiddleware(RequestDelegate next)
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
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors
                .Select(failure => new
                {
                    failure.PropertyName,
                    failure.ErrorMessage
                });

            var response = new { errors = errors };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}