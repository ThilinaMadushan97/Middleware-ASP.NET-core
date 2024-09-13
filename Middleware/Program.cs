using Middleware.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<MyMiddleware>();

var app = builder.Build();

app.Use(async(HttpContext context, RequestDelegate next) => 
{

    await context.Response.WriteAsync("Wellcome Middleware 1\n\n");
    await next(context);  
});

app.Use(async (HttpContext context, RequestDelegate next) => 
{

    await context.Response.WriteAsync("Wellcome Middleware 2\n\n");
    await next(context);
});

//app.UseMiddleware<MyMiddleware>();
//app.MyMiddleware();
app.UseAnothorCustomMiddleware();

app.UseWhen(context => context.Request.Query.ContainsKey("IsAuthorizde") 
    && context.Request.Query["IsAuthorizde"] == "true",
    
    app =>
    {
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Middleware 4 called");
            await next(context);
        });
    }
    );

app.Run(async (HttpContext context) => 
{

    await context.Response.WriteAsync("Wellcome Middleware 5\n\n");
});


app.Run();
