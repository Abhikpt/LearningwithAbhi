
using LearningwithAbhi.Client;
using LearningwithAbhi.Client.Services;
using LearningwithAbhi.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<CartService>();
builder.Services.AddSingleton<PdfService>();
builder.Services.AddSingleton<ImageProcessingService>();
builder.Services.AddScoped<EmployeeService>();


await builder.Build().RunAsync();
