using System;
using Microsoft.JSInterop;
using Shiny.Infrastructure;


namespace Shiny.Settings
{
    public class SettingsImpl : AbstractSettings
    {
        readonly IJSInProcessRuntime interop;
        public SettingsImpl(IJSInProcessRuntime interop, ISerializer serializer) : base(serializer)
            => this.interop = interop;


        public override bool Contains(string key)
            => this.interop.Invoke<string>("localStorage.getItem", key) != null;


        protected override object NativeGet(Type type, string key)
        { 
            var value = this.interop.InvokeAsync<string>("localStorage.getItem", key);
            if (value == null)
                return null;

            return null;
        }


        protected override void NativeSet(Type type, string key, object value)
            => this.interop.InvokeVoid("localStorage.setItem", key, value.ToString());


        protected override void NativeRemove(string[] keys)
        {
            foreach (var key in keys)
                this.interop.InvokeAsync<bool>("localStorage.removeItem", key);
        }


        protected override void NativeClear() => this.interop.InvokeVoid("localStorage.clear");


        //protected override IDictionary<string, string> NativeValues()
        //{
        //    var items = this.interop.InvokeAsync<Dictionary<string, string>>("AcrSettings.list").Result;
        //    return items;
        //}
    }
}
