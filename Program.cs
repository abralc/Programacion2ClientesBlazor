using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Programacion2ClientesBlazor;
using Programacion2ClientesBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient apuntando a la API .NET
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5169/")
});

// Servicio de clientes
builder.Services.AddScoped<ClienteService>();

await builder.Build().RunAsync();