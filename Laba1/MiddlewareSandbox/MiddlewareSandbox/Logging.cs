namespace MiddlewareSandbox
{
    public class Logging
    {
        private readonly RequestDelegate _next;

        public Logging(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {context.Request.Method} {context.Request.Path}");
            await _next(context);
        }
    }

    public static class LoggingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Logging>();
        }
    }
}
