using System;
using System.Text.Json;
using Shiny.Infrastructure;


namespace Shiny.Wasm.Core
{
    public class BlazorSerializer : ISerializer
    {
        public T Deserialize<T>(string value) => JsonSerializer.Deserialize<T>(value);
        public object Deserialize(Type objectType, string value) => JsonSerializer.Deserialize(value, objectType);
        public string Serialize(object value) => JsonSerializer.Serialize(value);
    }
}
