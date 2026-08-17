using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WfhTracker.Client;
using WfhTracker.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions);

    var scopes = builder.Configuration.GetSection("Api:Scopes").Get<string[]>();

    if (scopes != null)
    {
        foreach (var scope in scopes)
        {
            options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
        }
    }
});

builder.Services.AddHttpClient("WfhTracker.Api", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["Api:BaseUrl"]!);
})
.AddHttpMessageHandler(sp =>
{
    var handler = sp.GetRequiredService<AuthorizationMessageHandler>()
        .ConfigureHandler(
            authorizedUrls:
            [
                 builder.Configuration["Api:BaseUrl"]!
            ],
            scopes: builder.Configuration
                .GetSection("Api:Scopes")
                .Get<string[]>()!);

    return handler;
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>()
        .CreateClient("WfhTracker.Api"));

builder.Services.AddScoped<IHttpService, HttpService>();

// Add HttpClient for static assets (no authentication)
builder.Services.AddHttpClient("WfhTracker.StaticAssets", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

await builder.Build().RunAsync();
