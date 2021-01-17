using System;
using System.Collections.Generic;
using Application.Interfaces.Services;

namespace Application.Helper
{
    public abstract class AbstractCache : ICache
    {
        protected static Dictionary<string, bool> DataChanged = new Dictionary<string, bool>();

        public abstract bool AddData(string key, object data, TimeSpan? span = null);

        public abstract T GetData<T>(string key);

        public abstract bool MarkChanged(string key);

        public abstract bool MarkManyChanged(string[] keys);
    }
}