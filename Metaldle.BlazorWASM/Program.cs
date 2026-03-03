using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Metaldle.BlazorWASM;
using Metaldle.BlazorWASM.Services;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5251") });
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<MetaldleApiService>();
builder.Services.AddScoped<SessionService>();
await builder.Build().RunAsync();
