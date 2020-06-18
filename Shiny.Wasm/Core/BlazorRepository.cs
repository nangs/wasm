using Shiny.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Shiny.Wasm.Core
{
    // local storage - sqlite?
    public class BlazorRepository : IRepository
    {
        public Task Clear<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, T>> GetAllWithKeys<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove<T>(string key) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> Set(string key, object entity)
        {
            throw new NotImplementedException();
        }
    }
}
