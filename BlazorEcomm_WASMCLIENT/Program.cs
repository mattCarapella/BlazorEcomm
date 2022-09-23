using BlazorEcomm_WASMCLIENT;
using BlazorEcomm_WASMCLIENT.Service;
using BlazorEcomm_WASMCLIENT.Service.IService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

/* Default Component */
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/* Used to make API call to retrieve data from SERVER  (BaseAPIUrl is stored in CLIENT/wwwroot/appsettings.json) */
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();