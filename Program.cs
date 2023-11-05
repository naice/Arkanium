using Arkanium;
using Arkanium.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseUri = new Uri("https://naice.github.io/Arkanium/");
//baseUri = new Uri("https://localhost:5001");

var services = builder.Services;
services.AddScoped<IClipboardService, ClipboardService>();
services.AddHttpClient("Arkanium.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
services.AddScoped(sp => {
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Arkanium.ServerAPI");
    client.BaseAddress = baseUri;
    return client;
});

services.AddRadzenComponents();

var host = builder.Build();

// var navMan = host.Services.GetRequiredService<NavigationManager>();
// navMan.BaseUri = baseUri;

await host.RunAsync();
