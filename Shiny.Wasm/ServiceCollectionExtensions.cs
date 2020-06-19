using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shiny.Locations;
using Shiny.Notifications;
using Shiny.Sensors;
using Shiny.Wasm.Locations;
using Shiny.Wasm.Notifications;
using Shiny.Wasm.Sensors;

namespace Shiny.Wasm
{
    public static class ServiceCollectionExtensions
    {
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
            services.AddSingleton<IGeofenceManager, GpsGeofenceManagerImpl>();
        }


        public static void UseSensors(this IServiceCollection services)
        {
            services.AddSingleton<IAccelerometer, AccelerometerImpl>();
            services.AddSingleton<IGyroscope, GyroscopeImpl>();
            services.AddSingleton<IMagnetometer, MagnetometerImpl>();
            services.AddSingleton<IAmbientLight, AmbientLightImpl>();
            services.AddSingleton<ICompass, SharedCompassImpl>();
        }
    }
}
