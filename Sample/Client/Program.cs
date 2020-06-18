using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.UseGps();
            //builder.Services.UseGeofencing<>
            await builder.Build().RunAsync();
        }
    }
}
