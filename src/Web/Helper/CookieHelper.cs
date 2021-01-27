using Microsoft.AspNetCore.Http;
using Web.Models;
using Web.Pages.Cart;
using Web.DTO;
using System.Collections.Generic;
using System.Text.Json;
using System;

namespace Web.Helper
{
    public static class CookieHelper
    {
        public static string KEY_CART = "basketshopping";
        public static string KEY_CACHE = "key-cache";

        public static void AddCookie(HttpContext context, string key, string data)
        {
            CookieOptions options = new CookieOptions()
            {
                HttpOnly = false
            };
            context.Response.Cookies.Append(key, data, options);
        }

        public static T GetCookie<T>(HttpContext context, string key)
        {
            var obj = context.Request.Cookies[key];
            try
            {
                var model = JsonSerializer.Deserialize<T>(obj);
                if (model != null) return model;
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        public static string GetKeyCache(HttpContext context)
        {
            return GetCookie<string>(context, KEY_CACHE);
        }

        public static void AddKeyCache(HttpContext context, string keyCache)
        {
            AddCookie(context, KEY_CACHE, keyCache);
        }

        public static void AddCart(HttpContext context, List<CartDTO> cart = null)
        {
            if (cart == null) cart = new List<CartDTO>() { new CartDTO() };
            CookieOptions options = new CookieOptions()
            {
                HttpOnly = false,
                Path = "/gio-hang",
                IsEssential = true,
                Expires = DateTime.Now.AddMonths(1)
            };
            context.Response.Cookies.Append(KEY_CART, JsonSerializer.Serialize(cart), options);
        }

        public static List<CartDTO> GetCart(HttpContext context)
        {
            return GetCookie<List<CartDTO>>(context, KEY_CART);
        }
    }
}