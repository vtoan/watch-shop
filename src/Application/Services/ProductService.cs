using System;
using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class ProductService : AbstractService<Product>, IProductService
    {
        private readonly IProductDAO _db;
        private const string _CACHE_PROP = "_PRODUCT";
        private const string _CACHE_CATE = "_CATE_";
        private const string _CACHE_BAND = "_BAND_";
        private const string _CACHE_FEATURED = "_PROP_FEATURED";

        public ProductService(IProductDAO dao, ICache cache) : base(dao, cache, _CACHE_PROP)
        {
            _db = dao;
        }

        public ICollection<Product> FindByQuery(string query)
        {
            if (String.IsNullOrEmpty(query)) return null;
            return _db.FindItem(query);
        }

        public ICollection<Product> GetListById(int[] arrayId)
        {
            if (arrayId == null || arrayId?.Length <= 0) return null;
            return _db.GetListByIds(arrayId);
        }

        // public ICollection<Product> GetListFeatured()
        // {
        //     var re = _cache.GetData<List<Product>>(_CACHE_FEATURED);
        //     if (re == null || re?.Count <= 0)
        //     {
        //         re = (List<Product>)_db.GetListFeatured();
        //         if (re?.Count > 0) _cache.AddData(_CACHE_FEATURED, re, TimeSpan.FromDays(1));
        //     }
        //     return re;
        // }

        public ICollection<Product> GetListItems(bool isAdmin = false)
        {
            if (isAdmin == true) return _db.GetList(isAdmin);
            else
            {
                var re = _cache.GetData<List<Product>>(_CACHE_PROP);
                if (re == null || re?.Count <= 0)
                {
                    re = (List<Product>)_db.GetList();
                    if (re?.Count > 0) _cache.AddData(_CACHE_PROP, re);
                }
                return re;
            };
        }

        public ICollection<Product> GetListByCate(int cateId, int bandId = 0, int wireId = 0, bool isAdmin = false)
        {
            if (bandId > 0 || wireId > 0 || isAdmin) return _db.GetByCate(cateId, bandId, wireId, isAdmin);
            if (cateId <= 0) return null;
            string keyCache = _CACHE_CATE + cateId;
            var re = _cache.GetData<List<Product>>(keyCache);
            if (re == null || re?.Count <= 0)
            {
                re = (List<Product>)_db.GetByCate(cateId, bandId, wireId, isAdmin);
                if (re?.Count > 0) _cache.AddData(keyCache, re);
            }
            return re;
        }

        public ICollection<Product> GetListByBand(int bandId, int cateId = 0, int wireId = 0, bool isAdmin = false)
        {
            if (cateId > 0 || wireId > 0 || isAdmin) return _db.GetByBand(cateId, bandId, wireId, isAdmin);
            if (bandId <= 0) return null;
            string keyCache = _CACHE_BAND + bandId;
            var re = _cache.GetData<List<Product>>(keyCache);
            if (re == null || re?.Count <= 0)
            {
                re = (List<Product>)_db.GetByBand(bandId, cateId, wireId, isAdmin);
                if (re?.Count > 0) _cache.AddData(keyCache, re);
            }
            return re;
        }

        public new Product AddItem(Product newObject)
        {
            var execResult = base.AddItem(newObject);
            if (execResult == null) return null;
            _cache.MarkManyChanged(new string[] { _CACHE_BAND, _CACHE_CATE, _CACHE_FEATURED });
            return execResult;
        }

        public new bool UpdateItem(int id, Product modifiedObject)
        {
            var execResult = base.UpdateItem(id, modifiedObject);
            if (execResult == false) return false;
            _cache.MarkManyChanged(new string[] { _CACHE_BAND, _CACHE_CATE, _CACHE_FEATURED });
            return execResult;
        }

        public bool UpdateStatus(int id, bool status)
        {
            if (id <= 0) return false;
            var propModified = CreatePropChanged("status", status);
            var execResult = _db.Update(id, propModified);
            if (execResult) _cache.MarkManyChanged(new string[] { _CACHE_PROP, _CACHE_BAND, _CACHE_CATE, _CACHE_FEATURED });
            return execResult;
        }

        public new bool DeleteItem(int id)
        {
            var execResult = base.DeleteItem(id);
            if (execResult == false) return false;
            _cache.MarkManyChanged(new string[] { _CACHE_BAND, _CACHE_CATE, _CACHE_FEATURED });
            return execResult;
        }

        //Product Detail

        public ProductDetail GetDetail(int id)
        {
            if (id <= 0) return null;
            return _db.Get<ProductDetail>(id);
        }

        public bool UpdateDetail(int id, ProductDetail modifiedObject)
        {
            if (id <= 0) return false;
            var propModified = base.GetPropChangedOf(modifiedObject);
            if (propModified.Count < 0) return true;
            return _db.Update<ProductDetail>(id, propModified);
        }
    }
}