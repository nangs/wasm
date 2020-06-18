using Microsoft.JSInterop;


namespace Shiny.Wasm.Core
{
    public class EnvironmentImpl : IEnvironment
    {
        readonly IJSInProcessRuntime interop;
        public EnvironmentImpl(IJSInProcessRuntime interop) => this.interop = interop;

        public string AppIdentifier { get; } = "WASM";
        public string AppVersion { get; } = "WASM";
        public string AppBuild { get; } = "WASM";
        public string MachineName { get; } = "WASM";
        public string Manufacturer { get; } = "Unknown";
        public string Model { get; } = "Unknown";
        public string OperatingSystem { get; } = "Unknown";
        public string OperatingSystemVersion { get; } = "Unknown";
    }
}
