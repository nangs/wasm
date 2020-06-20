using System;
using Microsoft.JSInterop;
using Shiny.Sensors;


namespace Shiny.Wasm.Sensors
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Sensor_APIs
    public class AccelerometerImpl : AbstractSensor<MotionReading>, IAccelerometer
    {
        public AccelerometerImpl(IJSInProcessRuntime interop) : base(interop, "Accelerometer", "accelerometer") {}
        public IObservable<MotionReading> WhenReadingTaken() => base.WhenReading();
    }
}
