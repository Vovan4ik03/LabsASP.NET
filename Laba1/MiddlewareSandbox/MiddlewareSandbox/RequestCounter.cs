namespace MiddlewareSandbox
{
    public class RequestCounter
    {
        private readonly RequestDelegate _next;
        private static int _requestCount = 0;

        public RequestCounter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _requestCount++;
            await _next(context);

            await context.Response.WriteAsync($"\nThe amount of processed requests is {_requestCount}.");
        }
    }


    public static class RequestCounterMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestCounter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestCounter>();
        }
    }

}
