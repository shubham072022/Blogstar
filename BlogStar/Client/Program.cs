using BlogStar.Client;
using BlogStar.Client.Services;
using BlogStar.Client.Services.BaseService;
using BlogStar.Client.Services.IServices;
using BlogStar.Client.Services.IServices.IBaseService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddTransient<IBaseApiService, BaseApiService>();
builder.Services.AddTransient<IAuthService, AuthService>();

await builder.Build().RunAsync();
