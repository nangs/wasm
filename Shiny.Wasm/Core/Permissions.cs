using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;


namespace Shiny.Wasm
{
    public static class Permissions
    {
        public static bool IsFeatureAvailable(this IJSInProcessRuntime interop, string windowType) => interop.Invoke<bool>("Shiny.isFeatureAvailable", windowType);


        public static async Task<AccessState> RequestPermission(this IJSInProcessRuntime interop, string permission, string windowType)
        {
            if (!interop.IsFeatureAvailable(windowType))
                return AccessState.NotSupported;

            var result = await interop.Promise<string>("Shiny.requestPermission", permission);
            if (result == null)
                return AccessState.Unknown;

            switch (result.ToLower())
            {
                case "granted":
                    return AccessState.Available;

                case "denied":
                    return AccessState.Denied;

                default:
                    return AccessState.Unknown;
            }
        }
    }
}
