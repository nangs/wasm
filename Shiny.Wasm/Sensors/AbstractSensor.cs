using Microsoft.JSInterop;

using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Shiny.Wasm.Sensors
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Sensor_APIs
    public abstract class AbstractSensor<T>
    {
        readonly IJSInProcessRuntime interop;
        protected AbstractSensor(IJSInProcessRuntime interop) => this.interop = interop;


        protected Task<AccessState> RequestPermission()
        {
            return null;
        }

        public IObservable<T> WhenReading() => Observable.Create<T>(ob =>
        {
            return () => { };
        });
    }
}
