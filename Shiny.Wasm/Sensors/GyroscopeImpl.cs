using Shiny.Sensors;
using System;


namespace Shiny.Wasm.Sensors
{
    public class GyroscopeImpl : IGyroscope
    {
        public bool IsAvailable => throw new NotImplementedException();

        public IObservable<MotionReading> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
