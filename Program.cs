using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MLApplication_frontend;
using Serilog;
using Serilog.Extensions.Logging;
using System.Diagnostics;
using Microsoft.JSInterop;
using System.Net.Http;
using MLApplication_frontend.Components.SideContentPanel.PanelContent.GenerationalLearning.Application;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.BrowserConsole()
                .WriteTo.File("log.txt")
                .CreateLogger();

Log.Information("**SYSTEM** :  Loging Started");

builder.Services.AddSingleton<InstanceAttributeStateContainer>();
builder.Services.AddSingleton<NeuralNetworkAttributes>();

builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
await builder.Build().RunAsync();