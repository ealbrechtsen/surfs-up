using System.Diagnostics;

namespace surfs_up_api.Controllers
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware (RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"{context.Request.Method}{context.Request.Path}");
            await _next(context);
            stopwatch.Stop();
            Console.WriteLine($"{stopwatch.Elapsed.TotalMilliseconds} ms");
        }
    }
}
