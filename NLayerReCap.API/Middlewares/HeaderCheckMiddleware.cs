namespace NLayerReCap.API.Middlewares
{

    //  Bu Middleware kullanıcıdan gelen Device-Id ve Client-Key verileriini kontrol etmektedir.
    public class HeaderCheckMiddleware
    {
        private readonly RequestDelegate _next;
        public HeaderCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var key1 = httpContext.Request.Headers.Keys.Contains("Client-Key");
            var key2 = httpContext.Request.Headers.Keys.Contains("Device-Id");

            if (!key1 || !key2)
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("Missing requeired keys !");
                return;
            }
            else
            {
                //todo
            }
            await _next.Invoke(httpContext);
        }
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseHeaderCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HeaderCheckMiddleware>();
        }
    }
}
