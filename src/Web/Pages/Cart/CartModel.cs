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
using Microsoft.AspNetCore.Http;

namespace Web.Pages.Cart
{
    public class CartModel : ProductPage
    {
        public ICollection<Fee> ListFee { get; set; }
        private readonly IFeeService _feeSer;

        public CartModel(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            IFeeService feeSer,
            ICache cache) : base(productSer, mapper, promotionSer)
        {
            _feeSer = feeSer;
            ListFee = _feeSer.GetListItems();
        }

        public void OnGet() { }

        public IActionResult OnGetCartItem(string ids)
        {
            return Partial("_CartItemPartical", FindProductInCart(ids));
        }

        public IActionResult OnGetCheckProm(string code)
        {
            var result = _promotionSer.GetCodeProm(code);
            if (result == null) return NotFound();
            HttpContext.Session.SetString(PageHelper.KEY_PROM_SESSION, result.CodeCoupon);
            return new JsonResult(new { code = result.CodeCoupon, discount = result.Discount });
        }

        public IActionResult OnPost(string listItem)
        {
            if (
                String.IsNullOrWhiteSpace(listItem)
                || listItem == "") return Page();
            var val = JsonSerializer.Deserialize<ICollection<CartDTO>>(listItem);
            if (val == null || val.Count == 0) return Page();
            var feeJson = JsonSerializer.Serialize(ListFee);
            var listItemJson = JsonSerializer.Serialize(FindProductInCart(listItem));
            HttpContext.Session.SetString(PageHelper.KEY_CART_SESSION, listItemJson);
            HttpContext.Session.SetString(PageHelper.KEY_FEE_SESSION, feeJson);
            return RedirectToPage("/Checkout/Index");
        }

        private List<ProductInCart> FindProductInCart(string arProdId)
        {
            var listCartItem = JsonSerializer.Deserialize<List<CartDTO>>(arProdId);
            int[] productIds = listCartItem.Select(item => item.ProductId).ToArray();
            if (productIds.Length == 0) return null;
            MapProductDTO(_productSer.GetListById(productIds));
            var listProductCart = new List<ProductInCart>();
            foreach (var item in listCartItem)
            {
                var product = ListProducts.Find(p => p.Id == item.ProductId);
                listProductCart.Add(new ProductInCart()
                {
                    ProductId = item.ProductId,
                    ProductName = $"{product.Name} {product.BandName} {product.WireName}",
                    ProductImage = product.Image,
                    Quantity = item.Quantity,
                    Price = product.Price,
                    PricePromotion = (product.Discount % 1 == 0) ?
                            (product.Price - product.Discount) :
                            (product.Price - (product.Price * product.Discount))
                });
            }
            return listProductCart;
        }

        public class ProductInCart
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductImage { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
            public double PricePromotion { get; set; }
        }

    }
}