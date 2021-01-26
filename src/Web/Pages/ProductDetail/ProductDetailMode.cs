using System.Collections.Generic;
using Application.Interfaces.Services;
using AutoMapper;
using Web.Helper;
using Web.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Domains;

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
            ProductDetail = _productSer.GetDetail(id);
            ListProducts = _cache.GetData<List<ProductDTO>>(keyCacheDiscount);
            if (ListProducts != null)
            {
                Product = ListProducts.Find(item => item.Id == id);
            }
            else
            {
                var productAsset = (List<Product>)_productSer.GetListById(new int[] { id });
                if (productAsset == null || productAsset?.Count == 0)
                {
                    // TempData.Add("msg-err", "Sản phẩm không tồn tại");
                    return RedirectToPage("/Error/Index");
                }
                var prod = _mapper.Map<ProductDTO>(productAsset[0]);
                var ls = new List<ProductDTO>() { prod };
                CheckProm(ls);
                Product = ls[0];
            }
            return Page();
        }
    }
}