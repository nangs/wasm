using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.JSInterop;


namespace Shiny.Wasm.Sensors
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Sensor_APIs
    public abstract class AbstractSensor<T>
    {
        readonly IJSInProcessRuntime interop;        
        readonly string sensorJsType;
        readonly string permission;
        readonly Subject<T> sensorSubj;


        protected AbstractSensor(IJSInProcessRuntime interop, string sensorJsType, string permission)
        {
            this.interop = interop;
            this.sensorJsType = sensorJsType;
            this.permission = permission;
        }


        protected virtual Task<AccessState> RequestPermission() => this.interop.RequestPermission(this.permission, this.sensorJsType);
        [JSInvokable] public void OnReading(T response) => this.sensorSubj.OnNext(response);
        [JSInvokable] public void OnError(string error) => this.sensorSubj.OnError(new Exception(error));


        public virtual bool IsAvailable => this.interop.IsFeatureAvailable(this.sensorJsType);
        public virtual IObservable<T> WhenReading() => Observable.Create<T>(async ob =>
        {
            var result = await this.RequestPermission();
            if (result != AccessState.Available)
                throw new Exception("Invalid Status - " + result);

            this.interop.InvokeVoid("Shiny.startSensor", DotNetObjectReference.Create(this));
            var sub = this.sensorSubj.Subscribe(
                ob.OnNext,
                ob.OnError
            );

            return () => 
            { 
                this.interop.InvokeVoid("Shiny.stopSensor");
                sub.Dispose();
            };
        });
    }
}
/*
window.WriteCSharpMessageToConsole = (dotnetHelper) => {
    dotnetHelper.invokeMethodAsync('GetHelloMessage')
        .then(message => console.log(message));
}

  private async Task WriteToConsole()
    {
        await jsRuntime.InvokeVoidAsync("WriteCSharpMessageToConsole", DotNetObjectRef.Create(this));
    }
            
    [JSInvokable]
    public Task<string> GetHelloMessage()
    {
        var message = "Hello from a C# instance";
        return Task.FromResult(message);
    }


navigator.permissions.query({ name: 'accelerometer' })
.then(result => {
  if (result.state === 'denied') {
    console.log('Permission to use accelerometer sensor is denied.');
    return;
  }
  // Use the sensor.
});

const sensor = new AbsoluteOrientationSensor();
sensor.start();
sensor.onerror = event => {
  if (event.error.name === 'SecurityError')
    console.log("No permissions to use AbsoluteOrientationSensor.");
};


let accelerometer = null;
try {
    accelerometer = new Accelerometer({ referenceFrame: 'device' });
    accelerometer.addEventListener('error', event => {
        // Handle runtime errors.
        if (event.error.name === 'NotAllowedError') {
            // Branch to code for requesting permission.
        } else if (event.error.name === 'NotReadableError' ) {
            console.log('Cannot connect to the sensor.');
        }
    });
    accelerometer.addEventListener('reading', () => reloadOnShake(accelerometer));
    accelerometer.start();
} catch (error) {
    // Handle construction errors.
    if (error.name === 'SecurityError') {
        // See the note above about feature policy.
        console.log('Sensor construction was blocked by a feature policy.');
    } else if (error.name === 'ReferenceError') {
        console.log('Sensor is not supported by the User Agent.');
    } else {
        throw error;
    }
}
 */
