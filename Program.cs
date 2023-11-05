using Arkanium;
using Arkanium.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var services = builder.Services;
services.AddScoped<IClipboardService, ClipboardService>();
services.AddHttpClient("Arkanium.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Arkanium.ServerAPI"));
services.AddRadzenComponents();

await builder.Build().RunAsync();
