using System;
using System.Reactive.Subjects;
using Microsoft.JSInterop;
using Shiny.BluetoothLE.Central;

namespace Shiny.BluetoothLE
{
    public static class Callbacks
    {
        public static Subject<ScanResult> ScanResults { get; } = new Subject<ScanResult>();


        [JSInvokable]
        public static void OnScanResult(object device)
        {
            ScanResults.OnNext(null);
        }


        public static Subject<IGattService> Services = new Subject<IGattService>();

        [JSInvokable]
        public static void OnService()
        {

        }


        public static Subject<IGattCharacteristic> Characteristics { get; } = new Subject<IGattCharacteristic>();

        [JSInvokable]
        public static void OnCharacteristic()
        {

        }
    }
}
