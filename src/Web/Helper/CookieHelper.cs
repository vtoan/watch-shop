using Microsoft.AspNetCore.Http;
using Web.Models;
using System.Text.Json;

namespace Web.Helper
{
    public static class CookieHelper
    {
        public static string KEY_CACHE = "key-cache";

        public static void AddKey(HttpContext context, string keyCache, CookieModel cookie = null)
        {
            if (cookie == null) cookie = new CookieModel();
            cookie.KeyCache = keyCache;
            cookie.SessionId = context.Session.Id;
            context.Response.Cookies.Append(KEY_CACHE, JsonSerializer.Serialize(cookie));
        }

        public static string GetKey(HttpContext context)
        {
            var obj = context.Request.Cookies[KEY_CACHE];
            try
            {
                var model = JsonSerializer.Deserialize<CookieModel>(obj);
                // string currentSesstion = context.Session.Id;
                if (model != null) return model.KeyCache;
                return null;
            }
            catch
            {
                return null;
            }


        }
    }
}