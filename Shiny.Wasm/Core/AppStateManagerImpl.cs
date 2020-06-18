using System;
using System.Collections.Generic;
using Microsoft.JSInterop;
using Shiny.Logging;


namespace Shiny.Wasm.Core
{
    public class AppStateManagerImpl : IShinyStartupTask
    {
        readonly IJSInProcessRuntime interop;
        readonly IEnumerable<IAppStateDelegate> delegates;
        static AppStateManagerImpl instance;


        public AppStateManagerImpl(IJSInProcessRuntime interop, IEnumerable<IAppStateDelegate> delegates)
        {
            this.interop = interop;
            this.delegates = delegates;
            instance = this;
        }


        void Execute(Action<IAppStateDelegate> execute)
        {
            foreach (var del in this.delegates)
            {
                try
                {
                    execute(del);
                }
                catch (Exception ex)
                {
                    Log.Write(ex);
                }
            }
        }


        public void Start() => this.Execute(x => x.OnStart());
        [JSInvokable] public static void OnForeground() => instance.Execute(x => x.OnForeground());
        [JSInvokable] public static void OnBackground() => instance.Execute(x => x.OnBackground());
    }
}
