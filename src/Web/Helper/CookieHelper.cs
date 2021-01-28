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
                HttpOnly = false,
                Expires = DateTime.Now.AddHours(1)
            };
            context.Response.Cookies.Append(key, data, options);
        }

        public static string GetKeyCache(HttpContext context)
        {
            var key = context.Request.Cookies[KEY_CACHE];
            if (key != null) return key;
            return null;
        }

        public static void AddKeyCache(HttpContext context, string keyCache)
        {
            AddCookie(context, KEY_CACHE, keyCache);
        }
    }
}