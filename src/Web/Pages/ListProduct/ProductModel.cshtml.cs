using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Application.Domains;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Enums;
using Web.Helper;
using Web.Models;

namespace Web.Pages
{
    public class ProductModel : ProductPage
    {
        private readonly ICache _cache;
        //SEO
        public SeoType TypeSeo { get; set; }
        public int ItemSeoId { get; set; } = 1;
        //paging
        public int PageNumber = 0;
        //route
        [BindProperty(Name = "w", SupportsGet = true)]
        public int WireId { get; set; }
        [BindProperty(Name = "b", SupportsGet = true)]
        public int BandId { get; set; }
        public string PathRequest { get; set; } = "";

        public bool isSearchResult { get; set; }

        public ProductModel(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            ICache cache) : base(productSer, mapper, promotionSer)
        {

            _cache = cache;
        }

        public void OnGet(int category, int b, int w, int p = 1)
        {
            GetProductByCate(HttpContext, category, b, w, p);
            PathRequest = GetPathRequest(HttpContext, category);
            //
            TypeSeo = SeoType.Category;
            ItemSeoId = category;
        }

        public void OnGetDiscount(int b, int w, int p = 1)
        {
            GetProductDiscount(HttpContext, b, w, p);
            PathRequest = GetPathRequest(HttpContext);
            //
            TypeSeo = SeoType.Discount;
        }

        public void OnGetSearch(string query, int b, int w, int p = 1)
        {
            GetProductByQuery(HttpContext, query, b, w, p);
            PathRequest = GetPathRequest(HttpContext);
            //
            TypeSeo = SeoType.Search;
        }

        public PartialViewResult OnGetAjax(string query, int category, int b, int w, int o, int p = 1)
        {
            string keyCache = CookieHelper.GetKey(HttpContext);
            if (keyCache != null) ListProducts = _cache.GetData<List<ProductDTO>>(keyCache);
            if (ListProducts == null || ListProducts?.Count == 0)
            {
                if (query != null) GetProductByQuery(HttpContext, query, b, w, 0);
                else if (category != 0) GetProductByCate(HttpContext, category, b, w, 0);
                else GetProductDiscount(HttpContext, b, w, 0);
            }
            if (o != 0) ListProducts = OrderBy(ListProducts, o);
            return Partial("_ProductPartical", GetPage(ListProducts, p));
        }

        #region "method"
        private void GetProductByCate(HttpContext context, int category, int b, int w, int p = 1)
        {
            MapProductDTO(_productSer.GetListByCate(category, b, w), ref PageNumber);
            CheckProm(ListProducts);
            if (ListProducts.Count > 0)
            {
                string keyCache = $"c{category},b{b},w{w}";
                _cache.AddData(keyCache, ListProducts, TimeSpan.FromMinutes(3));
                //
                CookieHelper.AddKey(context, keyCache);
                ListProducts = GetPage(ListProducts, p);
            }
        }

        private void GetProductDiscount(HttpContext context, int b, int w, int p = 1)
        {
            if (_lsProm?.Count == 0) return;
            string keyCache = "prod-discount";
            GetProductDiscount(keyCache);
            //
            if (ListProducts.Count > 0)
            {
                CookieHelper.AddKey(context, keyCache);
                if (b != 0)
                    ListProducts = ListProducts.Where(item => item.BandId == b).ToList();
                if (w != 0)
                    ListProducts = ListProducts.Where(item => item.WireId == w).ToList();
                PageNumber = CalcPage(ListProducts.Count);
                ListProducts = GetPage(ListProducts, p);
            }
        }

        private void GetProductByQuery(HttpContext context, string query, int b, int w, int p = 1)
        {
            isSearchResult = true;
            string keyCacheNew = $"query-{query}";
            string keyCache = CookieHelper.GetKey(context);
            if (keyCache == keyCacheNew) ListProducts = _cache.GetData<List<ProductDTO>>(keyCache);
            if (ListProducts == null || ListProducts?.Count == 0)
            {
                MapProductDTO(_productSer.FindByQuery(query), ref PageNumber);
                CheckProm(ListProducts);
                if (ListProducts.Count == 0) return;
                _cache.AddData(keyCache, ListProducts, TimeSpan.FromMinutes(3));
                CookieHelper.AddKey(context, keyCacheNew);
            }
            if (ListProducts?.Count > 0)
            {
                if (b != 0)
                    ListProducts = ListProducts.Where(item => item.BandId == b).ToList();
                if (w != 0)
                    ListProducts = ListProducts.Where(item => item.WireId == w).ToList();
                PageNumber = CalcPage(ListProducts.Count);
                ListProducts = GetPage(ListProducts, 1);
            }
        }

        private void GetProductDiscount(string key)
        {
            ListProducts = _cache.GetData<List<ProductDTO>>(key);
            if (ListProducts == null)
            {
                ListProducts = new List<ProductDTO>();
                foreach (var prom in _lsProm)
                {
                    HashSet<Product> products = new HashSet<Product>();
                    if (prom.CategoryId != null)
                    {
                        var re = _productSer.GetListByCate((int)prom.CategoryId);
                        if (re?.Count > 0)
                        {
                            foreach (var product in re)
                                products.Add(product);
                        }

                    }
                    if (prom.BandId != null)
                    {
                        var re = _productSer.GetListByBand((int)prom.BandId);
                        if (re?.Count > 0)
                        {
                            foreach (var product in re)
                                products.Add(product);
                        };

                    }
                    if (prom.ProductIds != null)
                    {
                        int[] arIds = JsonSerializer.Deserialize<int[]>(prom.ProductIds);
                        if (arIds.Length > 0)
                        {
                            var re = _productSer.GetListById(arIds);
                            if (re?.Count == 0) return;
                            foreach (var product in re)
                                products.Add(product);
                        }
                    }
                    if (products.Count > 0)
                    {
                        foreach (var item in products)
                        {
                            var prod = _mapper.Map<ProductDTO>(item);
                            prod.Discount = (double)prom.Discount;
                            ListProducts.Add(prod);
                        }
                    }

                }

            }
            if (ListProducts.Count > 0)
            {
                _cache.AddData(key, ListProducts, TimeSpan.FromDays(1));
                PageNumber = CalcPage(ListProducts.Count);
            }
        }

        #endregion

    }

}
