using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class ApiLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public ApiLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var method = context.Request.Method;
        var stopwatch = Stopwatch.StartNew();

        await _next(context);

        stopwatch.Stop();
        Console.WriteLine($"Method: {method}, Duration: {stopwatch.ElapsedMilliseconds}ms");
    }
}
