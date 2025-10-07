namespace MiddlewareSandbox
{
    public class CustomQuery
    {
        private readonly RequestDelegate _next;

        public CustomQuery(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("custom"))
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("You've hit a custom middleware!");
                return; 
            }

            await _next(context);
        }
    }

    public static class CustomQueryMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomQuery(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomQuery>();
        }
    }
}
