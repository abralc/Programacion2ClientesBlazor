var builder = WebApplication.CreateBuilder(args);

// Evita mostrar "Server: Kestrel" en las respuestas HTTP.
builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

var app = builder.Build();

// Cabeceras de seguridad aplicadas a todas las respuestas.
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        context.Response.Headers["X-Frame-Options"] = "DENY";

        context.Response.Headers["Referrer-Policy"] =
            "strict-origin-when-cross-origin";

        context.Response.Headers["Permissions-Policy"] =
            "camera=(), microphone=(), geolocation=()";

        context.Response.Headers["Content-Security-Policy"] =
            "default-src 'self'; " +
            "base-uri 'self'; " +
            "object-src 'none'; " +
            "frame-ancestors 'none'; " +
            "img-src 'self' data:; " +
            "font-src 'self' data:; " +
            "style-src 'self' 'unsafe-inline'; " +
            "script-src 'self' 'unsafe-inline' 'wasm-unsafe-eval'; " +
            "connect-src 'self' http://localhost:5169 ws://localhost:*; " +
            "form-action 'self';";

        return Task.CompletedTask;
    });

    await next();
});

// Sirve los archivos generados por Blazor WebAssembly.
app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

// Soporte para rutas como /clientes.
app.MapFallbackToFile("index.html");

app.Run();