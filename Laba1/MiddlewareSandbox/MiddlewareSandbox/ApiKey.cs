namespace MiddlewareSandbox
{
    public class ApiKey
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "my-secret-key"; 

        public ApiKey(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("403 Forbidden: Missing API Key");
                return;
            }

            if (!API_KEY.Equals(extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("403 Forbidden: Invalid API Key");
                return;
            }

            await _next(context);
        }
    }

    public static class ApiKeyExtensions
    {
        public static IApplicationBuilder UseApiKeyCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKey>();
        }
    }
}
