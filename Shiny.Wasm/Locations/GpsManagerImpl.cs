using System;
using System.Threading.Tasks;

using Microsoft.JSInterop;

using Shiny.Locations;


namespace Shiny.Wasm.Locations
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Geolocation_API
    public class GpsManagerImpl : IGpsManager
    {
        readonly IJSInProcessRuntime interop;
        public GpsManagerImpl(IJSInProcessRuntime interop) => this.interop = interop;


        public bool IsListening => throw new NotImplementedException();

        public AccessState GetCurrentStatus(GpsRequest request)
        {
            throw new NotImplementedException();
        }

        public IObservable<IGpsReading?> GetLastReading()
        {
            throw new NotImplementedException();
        }

        public Task<AccessState> RequestAccess(GpsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task StartListener(GpsRequest request)
        {
            throw new NotImplementedException();
        }

        public Task StopListener()
        {
            throw new NotImplementedException();
        }

        public IObservable<AccessState> WhenAccessStatusChanged(GpsRequest request)
        {
            throw new NotImplementedException();
        }

        public IObservable<IGpsReading> WhenReading()
        {
            throw new NotImplementedException();
        }
    }
}
