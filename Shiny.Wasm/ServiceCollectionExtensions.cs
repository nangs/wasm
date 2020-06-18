using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shiny.Locations;
using Shiny.Wasm.Locations;


namespace Shiny.Wasm
{
    public static class ServiceCollectionExtensions
    {
        public static void UseGps(this IServiceCollection services)
        {
            services.TryAddSingleton<IGpsManager, GpsManagerImpl>();
        }


        public static void UseGeofencing<TDelegate>(this IServiceCollection services)
        {
            services.UseGps();
            services.AddSingleton<IGeofenceManager, GpsGeofenceManagerImpl>();
        }
    }
}
