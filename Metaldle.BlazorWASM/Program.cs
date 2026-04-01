using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Metaldle.BlazorWASM;
using Metaldle.BlazorWASM.Services;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiUrl = builder.Configuration["ApiBaseUrl"];
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<MetaldleApiService>();
builder.Services.AddScoped<SessionService>();

builder.Services.AddHttpClient("spotify", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddScoped<SpotifyService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var http = factory.CreateClient("spotify");
    return new SpotifyService(http);
});

await builder.Build().RunAsync();