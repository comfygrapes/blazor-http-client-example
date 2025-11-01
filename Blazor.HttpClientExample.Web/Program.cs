using Blazor.HttpClientExample.Web;
using Blazor.HttpClientExample.Web.Features.Home;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"] ?? "") });

builder.Services.AddSingleton<IHomePresenter, HomePresenter>();

await builder.Build().RunAsync();
