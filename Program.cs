using Arkanium;
using Arkanium.Controls.Overlay;
using Arkanium.Navigation;
using Arkanium.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
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
services.AddScoped(sp => {
    var client = sp.GetRequiredService<IHttpClientFactory>().CreateClient("Arkanium.ServerAPI");
    return client;
});

// 3rd party
services.AddBlazoredLocalStorage();
services.AddRadzenComponents();

// My
services.AddScoped<IItemSetService, ItemSetService>();
services.AddScoped<IOverlayService, OverlayService>();
services.AddScoped<INavigationPanelService, NavigationPanelService>();

var host = builder.Build();

await host.RunAsync();
