using System;
using System.Collections.Generic;

namespace Application.Interfaces.Services
{
    public interface ICache
    {
        bool MarkChanged(string key);
        bool MarkManyChanged(string[] keys);
        bool AddData(string key, object data, TimeSpan? span = null);
        T GetData<T>(string key);
    }
}