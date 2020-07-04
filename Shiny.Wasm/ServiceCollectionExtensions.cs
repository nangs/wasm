using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
using Shiny.Infrastructure;
using Shiny.Jobs;
using Shiny.Locations;
using Shiny.Notifications;
using Shiny.Sensors;
using Shiny.Settings;
using Shiny.Wasm.Core;
using Shiny.Wasm.Locations;
using Shiny.Wasm.Notifications;
using Shiny.Wasm.Sensors;


namespace Shiny.Wasm
{
    public static class ServiceCollectionExtensions
    {
        public static void UseShiny(this IServiceCollection services)
        {
            // TODO: figure out startup and bindable services
            services.AddSingleton(x => (IJSInProcessRuntime)x.Resolve<IJSRuntime>());
            services.AddSingleton<ISerializer, BlazorSerializer>();
            services.AddSingleton<IEnvironment, EnvironmentImpl>();
            services.AddSingleton<ISettings, SettingsImpl>();
            services.AddSingleton<AppStateManagerImpl>();
            services.AddSingleton<IJobManager, JobManager>();
        }


        public static void UseGps(this IServiceCollection services)
        {
            services.TryAddSingleton<IGpsManager, GpsManagerImpl>();
        }


        public static void UseNotifications(this IServiceCollection services)
        {
            services.AddSingleton<INotificationManager, NotificationManagerImpl>();
        }


        public static void UseGeofencing<TDelegate>(this IServiceCollection services)
        {
            services.UseGps();
            //services.AddSingleton<IGeofenceManager, GpsGeofenceManagerImpl>();
        }


        public static void UseSensors(this IServiceCollection services)
        {
            services.AddSingleton<IAccelerometer, AccelerometerImpl>();
            services.AddSingleton<IGyroscope, GyroscopeImpl>();
            services.AddSingleton<IMagnetometer, MagnetometerImpl>();
            services.AddSingleton<IAmbientLight, AmbientLightImpl>();
            //services.AddSingleton<ICompass, SharedCompassImpl>();
        }


        // TODO: figure out startup and bindable services
        //services.AddSingleton(x => (IJSInProcessRuntime) x.Resolve<IJSRuntime>());
        //    services.AddSingleton<ISerializer, BlazorSerializer>();
        //    services.AddSingleton<IEnvironment, EnvironmentImpl>();
        //    services.AddSingleton<ISettings, SettingsImpl>();
        //    services.AddSingleton<AppStateManagerImpl>();
        //    services.AddSingleton<IJobManager, JobManager>();
    }
}
