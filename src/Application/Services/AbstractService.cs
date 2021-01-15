using System.Collections.Generic;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using System.Linq;

namespace Application.Services
{
    public class AbstractService<T> : BaseService, IGetItem<T>, IAddItem<T>, IDeleteItem<T>, IUpdateItem<T>, IGetListItem<T>
    {
        private readonly IBaseDAO<T> _db;
        protected readonly ICache _cache;
        private readonly string _CACHEKEY;

        public AbstractService(IBaseDAO<T> db, ICache cache = null, string cacheKey = null)
        {
            _db = db;
            _cache = cache ?? null;
            _CACHEKEY = cacheKey ?? null;
        }

        public T AddItem(T newObject)
        {
            var re = newObject == null ? default(T) : _db.Add(newObject);
            if (_cache != null && _CACHEKEY != null && re != null) _cache.MarkChanged(_CACHEKEY);
            return re;
        }

        public bool DeleteItem(int id)
        {
            bool re = id <= 0 ? false : _db.Delete(id);
            if (_cache != null && _CACHEKEY != null && re) _cache.MarkChanged(_CACHEKEY);
            return re;
        }

        public bool UpdateItem(int id, T modifiedObject)
        {
            if (id <= 0 || modifiedObject == null) return false;
            var modified = GetPropChangedOf(modifiedObject);
            if (modified.Count <= 0) return true;
            bool re = _db.Update(id, modified);
            if (_cache != null && _CACHEKEY != null && re) _cache.MarkChanged(_CACHEKEY);
            return re;
        }

        public T GetItem(int id)
        {
            if (id <= 0) return default(T);
            return _db.Get(id);
        }

        public ICollection<T> GetListItems()
        {
            if (_cache == null && _CACHEKEY == null) return _db.GetList();
            else
            {
                var re = _cache.GetData<List<T>>(_CACHEKEY);
                if (re == null || re?.Count <= 0)
                {
                    re = (List<T>)_db.GetList();
                    if (re == null || re?.Count > 0) _cache.AddData(_CACHEKEY, re);
                }
                return re;
            };
        }

    }
}