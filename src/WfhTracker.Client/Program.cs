using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WfhTracker.Client;
using WfhTracker.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7232") });
builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddScoped<HealthService>();
builder.Services.AddScoped<EntryService>();

await builder.Build().RunAsync();
