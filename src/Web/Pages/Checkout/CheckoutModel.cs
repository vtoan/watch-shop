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
using static Web.Pages.Cart.CartModel;
using Microsoft.AspNetCore.Http;

namespace Web.Pages.Checkout
{
    public class CheckoutModel : ProductPage
    {
        public ICollection<Fee> ListFees { get; set; }
        public ICollection<ProductInCart> ListItems { get; set; }
        public ICollection<BillProm> ListBillProms { get; set; }
        public double Discount { get; set; } = 0;
        public double TotalAmount { get; set; } = 0;
        public double TotalItem { get; set; } = 0;
        public double Amount { get; set; } = 0;

        public CheckoutModel(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            IFeeService feeSer) : base(productSer, mapper, promotionSer)
        {

        }

        public IActionResult OnGet()
        {
            var items = HttpContext.Session.GetString(PageHelper.KEY_CART_SESSION);
            var fees = HttpContext.Session.GetString(PageHelper.KEY_FEE_SESSION);
            var coupon = HttpContext.Session.GetString(PageHelper.KEY_PROM_SESSION);
            if (items == null || fees == null) return RedirectToPage("/Cart/Index");
            ListFees = JsonSerializer.Deserialize<List<Fee>>(fees);
            ListItems = JsonSerializer.Deserialize<List<ProductInCart>>(items);
            ListBillProms = _promotionSer.GetListBillProm();
            CalcTotal();
            CheckProm(coupon);
            CalcAmount();
            return Page();
        }

        public IActionResult OnPost(OrderDTO order)
        {
            return RedirectToPage("/Status/OrderSussess", new { orderId = 121 });
        }

        private void CheckProm(string coupon)
        {
            if (coupon != null) Discount = _promotionSer.GetCodeProm(coupon)?.Discount ?? 0;
            else
            {
                if (!(ListBillProms?.Any() == false))
                {
                    foreach (var prom in ListBillProms)
                    {
                        if ((prom.ConditionAmount != null && prom.ConditionAmount > 0 && TotalAmount >= prom.ConditionAmount)
                            && (prom.ConditionItem != null && prom.ConditionItem > 0 && TotalItem >= prom.ConditionItem))
                        {
                            Discount = (double)prom.Discount;
                            return;
                        }
                        if ((prom.ConditionAmount != null && prom.ConditionAmount > 0 && TotalAmount >= prom.ConditionAmount))
                        {
                            Discount = (double)prom.Discount;
                            return;
                        }
                        if ((prom.ConditionItem != null && prom.ConditionItem > 0 && TotalItem >= prom.ConditionItem))
                        {
                            Discount = (double)prom.Discount;
                            return;
                        }
                    }
                }
            }
        }

        private void CalcTotal()
        {
            foreach (var item in ListItems)
            {
                TotalAmount += (item.PricePromotion * item.Quantity);
                TotalItem += item.Quantity;
            }
        }

        private void CalcAmount()
        {
            Amount = TotalAmount;
            if (Discount > 0)
            {
                Amount -= Discount % 1 == 0 ? Discount : (TotalAmount * Discount);
            }
            if (ListFees.Count > 0)
            {
                foreach (var item in ListFees)
                {
                    Amount += item.Cost % 1 == 0 ? (double)item.Cost : (Amount * (double)item.Cost);
                }
            }
        }

        public class OrderDTO
        {
            public string CustomerName { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerProvince { get; set; }
            public string CustomerDistrict { get; set; }
            public string CustomerEmail { get; set; }
            public string CustomerAddress { get; set; }
            public string Note { get; set; }
        }

    }
}