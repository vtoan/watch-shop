using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Web.DTO;
using Web.Helper;

namespace Web.Middlewares
{
    public static class CookieHandler
    {
        public static void UseCookieHandler(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                var re = CookieHelper.GetCart(context);
                if (re == null) CookieHelper.AddCart(context);
                await next.Invoke();
            });
        }
    }
}