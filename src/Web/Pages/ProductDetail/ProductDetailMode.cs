using System.Collections.Generic;
using Application.Interfaces.Services;
using AutoMapper;
using Web.Helper;
using Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Domains;
using System;

namespace Web.Pages.ProductDetail
{
    public class ProductDetailMode : ProductPage
    {
        private string keyCacheDiscount = "prod-discount";
        private readonly ICache _cache;
        public ProductDTO Product { get; set; }

        public Application.Domains.ProductDetail ProductDetail { get; set; }
        public ProductDetailMode(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            ICache cache) : base(productSer, mapper, promotionSer)
        { _cache = cache; }

        public IActionResult OnGet([FromQuery] int id)
        {
            ListProducts = _cache.GetData<List<ProductDTO>>(keyCacheDiscount);
            if (ListProducts != null) Product = ListProducts.Find(item => item.Id == id);
            else
            {
                var productAsset = (List<Product>)_productSer.GetListById(new int[] { id });
                if (productAsset == null || productAsset?.Count == 0)
                {
                    return RedirectToPage("/error/" + ErrorType.ProductNotFound);
                }
                var prod = _mapper.Map<ProductDTO>(productAsset[0]);
                var ls = new List<ProductDTO>() { prod };
                CheckProm(ls);
                Product = ls[0];
            }
            ProductDetail = _productSer.GetDetail(id);
            return Page();
        }

        public IActionResult OnGetRelated(string query)
        {
            if (String.IsNullOrEmpty(query)) return null;
            var asset = _productSer.FindByQuery(query, 4);
            if (asset == null || asset.Count == 0) return null;
            var result = new List<ProductDTO>();
            foreach (var item in asset)
                result.Add(_mapper.Map<ProductDTO>(item));
            return Partial("_ProductPartical", result);
        }
    }
}