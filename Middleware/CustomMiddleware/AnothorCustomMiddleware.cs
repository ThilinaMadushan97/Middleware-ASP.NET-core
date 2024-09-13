using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware.CustomMiddleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AnothorCustomMiddleware
    {
        private readonly RequestDelegate _next;

        public AnothorCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Middleware started\n\n");
            await _next(httpContext);
            await httpContext.Response.WriteAsync("Middleware completed\n\n");

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class AnothorCustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAnothorCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AnothorCustomMiddleware>();
        }
    }
}
