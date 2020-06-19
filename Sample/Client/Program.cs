using System;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
using Shiny.Wasm;


namespace Sample.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // passing webassembly host builder would require taking dependency on blazor
            WasmShinyHost.Init(builder.Services);
            builder.Services.UseNotifications();
            builder.Services.UseSensors();
            builder.Services.UseGps();
            //builder.Services.UseGeofencing<>

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder
                .Services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            var host = builder.Build();
            host
                .Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
