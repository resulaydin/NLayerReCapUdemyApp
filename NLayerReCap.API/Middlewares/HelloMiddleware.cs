namespace NLayerReCap.API.Middlewares
{
    public class HelloMiddleware
    {
        private readonly RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Mv tetiklendi.");
            await _next.Invoke(context);
            Console.WriteLine("After Mv tetiklendi.");

        }
    }

    public static class HelloMiddleWareExtention
    {
        public static IApplicationBuilder UseHello(this IApplicationBuilder app)
        {
           return app.UseMiddleware<HelloMiddleware>();
        }
    }
}
