using System;


namespace Shiny.BluetoothLE.Central
{
    public class ScanResult : IScanResult
    {
        public int Rssi { get; }
        public IPeripheral Peripheral { get; }
        public IAdvertisementData AdvertisementData { get; }
    }
}
