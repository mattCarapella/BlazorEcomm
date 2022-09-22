using BlazorEcomm_WASMCLIENT;
using BlazorEcomm_WASMCLIENT.Service;
using BlazorEcomm_WASMCLIENT.Service.IService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Default component
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Used to retrieve data from server. BaseAPIUrl is stored in appsettings.json
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();