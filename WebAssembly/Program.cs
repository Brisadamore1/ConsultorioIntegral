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


var host = builder.HostEnvironment;

var remotoStr = Service.Properties.Resources.Remoto?.ToLowerInvariant();
bool remoto = remotoStr == "true";
string apiBaseUrl = remoto
    ? Service.Properties.Resources.UrlApi
    : Service.Properties.Resources.UrlApiLocal;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseUrl) });

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProfesionalService, ProfesionalService>();
builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
