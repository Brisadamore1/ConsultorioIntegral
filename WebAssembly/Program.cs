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
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7214/")
});

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProfesionalService, ProfesionalService>();
builder.Services.AddScoped<FirebaseAuthService>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
