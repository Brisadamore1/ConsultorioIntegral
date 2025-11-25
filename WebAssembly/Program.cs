using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Service.Interfaces;
using Service.Services;
using WebAssembly.Components;
using WebAssembly.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Cliente HTTP para comunicarse con el backend
//builder.Services.AddScoped(sp => new HttpClient
//{
//    BaseAddress = new Uri("https://backendconsultorio.azurewebsites.net/api/")
//});


var host = builder.HostEnvironment;

string apiBaseUrl;

if (host.BaseAddress.Contains("localhost"))
{
    apiBaseUrl = "https://localhost:7107/api"; // ← TU API LOCAL
}
else
{
    apiBaseUrl = "https://backendconsultorio.azurewebsites.net/api/"; // ← TU API EN AZURE
}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProfesionalService, ProfesionalService>();
builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
