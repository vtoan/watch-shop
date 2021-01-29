using System;
using System.Globalization;
using Microsoft.AspNetCore.Html;
using Web.DTO;

namespace Web.Helper
{
    public static class PageHelper
    {

        public static readonly string KEY_CART_SESSION = "cart";
        public static readonly string KEY_FEE_SESSION = "fees";
        public static readonly string KEY_PROM_SESSION = "coupon";

        public static string _renderCurrency(double num)
        {
            int val = (int)num;
            return val.ToString("C", CultureInfo.GetCultureInfo("vi-VN"));
        }

        public static string _renderDiscount(double discount) =>
            (discount % 1 == 0) ? _renderCurrency(discount) : (discount * 100).ToString() + " %";


        public static IHtmlContent _checkDiscount(double discount, object product, Func<object, IHtmlContent> template)
        {
            if (discount > 0) return template(product);
            return null;
        }

    }
}