using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using Shiny.Infrastructure;
using Shiny.Jobs;
using Shiny.Settings;
using Shiny.Wasm.Core;


namespace Shiny.Wasm
{
    public class WasmShinyHost : ShinyHost
    {
        public static void Init(IServiceCollection services)
        {
            services.AddSingleton(x => (IJSInProcessRuntime)x.Resolve<IJSRuntime>());
            services.AddSingleton<ISerializer, BlazorSerializer>();
            services.AddSingleton<IEnvironment, EnvironmentImpl>();
            services.AddSingleton<ISettings, SettingsImpl>();
            services.AddSingleton<IJobManager, JobManager>();
        }
    }
}
