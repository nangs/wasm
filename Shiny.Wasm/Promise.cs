using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Shiny.Wasm
{
    public static class PromiseExtensions
    {
        public static async Task Promise(this IJSRuntime runtime, string identifier, params object[] args)
        {
            var promise = new Promise();
            var list = new List<object>(args);

            list.Add(DotNetObjectReference.Create(promise));
            await runtime.InvokeVoidAsync(identifier, list.ToArray());
            await promise.Task;
        }


        public static async Task<T> Promise<T>(this IJSRuntime runtime, string identifier, params object[] args)
        {
            var promise = new Promise<T>();
            var list = new List<object>(args);

            list.Add(DotNetObjectReference.Create(promise));
            await runtime.InvokeVoidAsync(identifier, list.ToArray());
            return await promise.Task;
        }
    }


    public class Promise<T>
    {
        readonly TaskCompletionSource<T> source = new TaskCompletionSource<T>();

        public Task<T> Task => this.source.Task;
        [JSInvokable] public void Accept(T obj) => this.source.SetResult(obj);
        [JSInvokable] public void Reject(string errorMessage) => this.source.SetException(new Exception(errorMessage));
    }


    public class Promise : Promise<object>
    {
    }
}
