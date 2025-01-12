using System.Diagnostics;

namespace surfs_up_api.Infrastructure
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Start 
            var stopwatch = Stopwatch.StartNew();

            // Log HTTP-metode og URL
            Console.WriteLine($"HTTP {context.Request.Method} {context.Request.Path}");

            // Kør næste middleware
            await _next(context);

            // Stop timer og log varighed
            stopwatch.Stop();
            Console.WriteLine($"Request took {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
