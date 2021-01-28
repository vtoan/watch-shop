using System.Collections.Generic;
using Application.Interfaces.Services;
using AutoMapper;
using Web.Helper;
using Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Web.DTO;

namespace Web.Pages.ProductDetail
{
    public class ProductDetailMode : ProductPage
    {
        private readonly ICache _cache;
        public ProductDTO Product { get; set; }
        public List<string> ListImage { get; set; }
        public Application.Domains.ProductDetail ProductDetail { get; set; }

        public ProductDetailMode(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            ICache cache) : base(productSer, mapper, promotionSer)
        { _cache = cache; }

        public IActionResult OnGet([FromServices] IWebHostEnvironment env, string name)
        {
            ListProducts = _cache.GetData<List<ProductDTO>>(KEY_CACHE_DISCOUNT);
            int prodId = GetProductId(name);
            FindListImage(0, env.WebRootPath);
            if (ListProducts != null && ListProducts.Count > 0) Product = ListProducts.Find(item => item.Id == prodId);
            if (Product == null)
            {
                var productAsset = _productSer.GetListById(new int[] { prodId });
                if (productAsset == null || productAsset?.Count == 0) return RedirectToPage("/error/" + ErrorType.ProductNotFound);
                var prod = _mapper.Map<ProductDTO>(productAsset.First());
                var ls = new List<ProductDTO>() { prod };
                CheckProm(ls);
                Product = ls[0];
            }
            ProductDetail = _productSer.GetDetail(prodId);
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

        public void FindListImage(int id, string webRootPath)
        {
            ListImage = new List<string>();
            string folderPath = Path.Combine(webRootPath, "images/band-logo");
            if (!Directory.Exists(folderPath)) return;
            var re = Directory.GetFiles(folderPath);
            foreach (var item in re)
                ListImage.Add(item.Split("/").Last());
            return;
        }
    }
}