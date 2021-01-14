using System;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class CacheService : ICache
    {
        public bool AddData(string key, object data, TimeSpan? span = null)
        {
            return false;
        }

        public T GetData<T>(string key)
        {
            return default(T);
        }

        public bool IsChanged(string key)
        {
            return false;
        }

        public bool MarkChanged(string key, TimeSpan? span = null)
        {
            return false;
        }

        public bool MarkManyChanged(string[] keys, TimeSpan? span = null)
        {
            throw new NotImplementedException();
        }

        public bool RemoveData(string key)
        {
            return false;
        }
    }
}