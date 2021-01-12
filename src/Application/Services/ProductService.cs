using System;
using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;
using System.Linq;

namespace Application.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IProductDAO _db;

        private const string _CACHEKEY = "_PRODUCT";

        public ProductService(IProductDAO dao, ICache cache) : base(dao, cache, _CACHEKEY)
        {
            _db = dao;
        }

        public ICollection<Product> FindByQuery(string query)
        {
            if (String.IsNullOrEmpty(query)) return null;
            return _db.FindItem(query);
        }

        public ProductDetail GetDetail(int id)
        {
            if (id <= 0) return null;
            return _db.GetDetail(id);
        }

        public ICollection<Product> GetListItems(bool isAdmin = false)
        {
            if (isAdmin == true) return _db.GetList(true);
            else
            {
                var re = _cache.GetData<List<Product>>(_CACHEKEY);
                if (re == null || re?.Count <= 0)
                {
                    re = (List<Product>)_db.GetList();
                    if (re?.Count > 0) _cache.AddData(_CACHEKEY, re);
                }
                return re;
            };
        }

        public ICollection<Product> GetListByBand(int id)
        {
            if (id <= 0) return null;
            string CACHE_BAND = "_BAND_" + id;
            var re = _cache.GetData<List<Product>>(CACHE_BAND);
            if (re == null || re?.Count <= 0)
            {
                re = (List<Product>)_db.GetByBand(id);
                if (re?.Count > 0) _cache.AddData(CACHE_BAND, re);
            }
            return re;
        }

        public ICollection<Product> GetListById(int[] arrayId)
        {
            if (arrayId == null || arrayId?.Length <= 0) return null;
            return _db.GetListByIds(arrayId);
        }

        public bool UpdateStatus(int id, bool status)
        {
            if (id <= 0) return false;
            var propModified = new Dictionary<string, object>();
            propModified.Add("status", status);
            var execResult = _db.Update(id, propModified);
            if (execResult) _cache.MarkChanged(_CACHEKEY);
            return execResult;
        }

        //
        public ICollection<Product> FilterByCate(ICollection<Product> listItems, int cateId)
        {
            if (listItems == null || listItems?.Count == 0 || cateId <= 0) return null;
            return listItems.Where(item => item.CategoryId == cateId).ToList();
        }

        public ICollection<Product> FilterByWire(ICollection<Product> listItems, int wireId)
        {
            if (listItems == null || listItems?.Count == 0 || wireId <= 0) return null;
            return listItems.Where(item => item.WireId == wireId).ToList();
        }
    }
}