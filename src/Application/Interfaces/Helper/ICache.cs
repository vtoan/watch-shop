using System;
using System.Collections.Generic;
using Application.Data;

namespace Application.Interfaces.Services
{
    public interface ICache
    {
        bool IsChanged(string key);
        bool MarkChanged(string key, TimeSpan? span = null);
        bool AddData(string key, object data, TimeSpan? span = null);
        bool RemoveData(string key);
        T GetData<T>(string key);
    }
}