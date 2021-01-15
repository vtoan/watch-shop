using System;
using System.Threading.Tasks;
using Application.Helper;
using Application.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;

namespace Web.Services
{
    public class CacheHelper : AbstractCache
    {
        private IMemoryCache _cache;

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public override bool AddData(string key, object data, TimeSpan? span = null)
        {
            if (data == null) return false;
            if (!DataChanged.ContainsKey(key)) DataChanged.Add(key, false);
            else DataChanged[key] = false;
            //
            Action act;
            if (span == null) act = () => _cache.Set(key, data);
            else act = () => _cache.Set(key, data, (System.TimeSpan)span);
            Task task = new Task(act);
            task.Start();
            return true;
        }

        public override T GetData<T>(string key)
        {
            if (!DataChanged.ContainsKey(key)) return default(T);
            if (DataChanged[key] == false) return default(T);
            var result = _cache.Get(key);
            return result == null ? default(T) : (T)result;
        }

        public override bool MarkChanged(string key)
        {
            bool status;
            if (DataChanged.TryGetValue(key, out status))
            {
                DataChanged[key] = true;
                return true;
            }
            return false;
        }

        public override bool MarkManyChanged(string[] keys)
        {
            bool status;
            if (keys.Length == 0) return false;
            foreach (var item in keys)
            {
                if (DataChanged.TryGetValue(item, out status))
                    DataChanged[item] = true;
                else return false;
            }
            return true;
        }
    }
}