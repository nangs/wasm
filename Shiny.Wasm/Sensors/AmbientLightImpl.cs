using System;
using Shiny.Sensors;


namespace Shiny.Wasm.Sensors
{
    public class AmbientLightImpl : IAmbientLight
    {
        public bool IsAvailable => throw new NotImplementedException();

        public IObservable<double> WhenReadingTaken()
        {
            throw new NotImplementedException();
        }
    }
}
