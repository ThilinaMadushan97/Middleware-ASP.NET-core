
namespace Middleware.CustomMiddleware
{
    public class MyMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Middleware started!\n\n");
            await next(context);
            await context.Response.WriteAsync("Middleware end!\n\n");

        }
    }

    public static class CustomMiddlewareExtention
    {
        public static IApplicationBuilder MyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();
        }
    }
}
