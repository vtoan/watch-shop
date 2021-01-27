using System.Collections.Generic;
using Application.Interfaces.Services;
using AutoMapper;
using Web.Helper;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Application.Domains;
using System;
using System.Text.Json;
using Web.DTO;

namespace Web.Pages.Cart
{
    public class CartModel : ProductPage
    {
        public ICollection<Fee> ListFee { get; set; }

        private readonly ICache _cache;
        private readonly IFeeService _feeSer;

        public CartModel(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            IFeeService feeSer,
            ICache cache) : base(productSer, mapper, promotionSer)
        {
            _cache = cache;
            _feeSer = feeSer;
        }

        public void OnGet()
        {
            ListFee = _feeSer.GetListItems();
        }

        public IActionResult OnGetCartItem(string ids)
        {
            var val = JsonSerializer.Deserialize<List<CartDTO>>(ids);
            int[] productIds = val.Select(item => item.ProductId).ToArray();
            if (productIds.Length == 0) return BadRequest();
            MapProductDTO(_productSer.GetListById(productIds));
            var result = new ProductInCart() { ListItem = val, ListProduct = ListProducts };
            return Partial("_CartItemPartical", result);
        }

        public IActionResult OnGetCheckProm(string code)
        {
            var result = _promotionSer.GetCodeProm(code);
            if (result == null) return NotFound();
            return new JsonResult(new { code = result.CodeCoupon, discount = result.Discount });
        }

        public void OnPost(string listItem)
        {
            if (
                String.IsNullOrWhiteSpace(listItem)
                || listItem == "") return;
            var val = JsonSerializer.Deserialize<ICollection<CartDTO>>(listItem);
            if (val == null || val.Count == 0) return;
        }

        public class ProductInCart
        {
            public List<CartDTO> ListItem { get; set; }
            public List<ProductDTO> ListProduct { get; set; }
        }

    }
}