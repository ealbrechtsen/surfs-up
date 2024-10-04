using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace surfs_up_api.MiddelWare;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Hent brugeroplysninger fra konteksten (hvis tilgængelig)
        var userId = context.User.Identity.IsAuthenticated ? context.User.Identity.Name : "Anonymous";
        var requestPath = context.Request.Path;

        // Logning af API-kald
        _logger.LogInformation($"User {userId} called {requestPath} at {DateTime.UtcNow}");

        // Du kan logge det til databasen her (ekstra funktion)
        LogApiCallToDatabase(userId, requestPath);

        // Kalder næste middleware i pipeline
        await _next(context);
    }

    private void LogApiCallToDatabase(string userId, string requestPath)
    {
        // Her kan du implementere logningen til databasen
        // fx. indsætte brugerID, sti og tidsstempel i en logtabel
    }
}
