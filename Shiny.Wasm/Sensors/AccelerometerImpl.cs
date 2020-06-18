using Shiny.Sensors;
using System;


namespace Shiny.Wasm.Sensors
{
    //https://developer.mozilla.org/en-US/docs/Web/API/Sensor_APIs
    public class AccelerometerImpl : IAccelerometer
    {
        public bool IsAvailable => throw new NotImplementedException();

        public IObservable<MotionReading> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
