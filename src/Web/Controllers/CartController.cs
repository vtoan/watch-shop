using System.Diagnostics;
using System.Collections.Generic;
using Application.Domains;
using Microsoft.AspNetCore.Mvc;
using static Web.Pages.Cart.CartModel;
using System.Text.Json;
using Web.Helper;
using Web.DTO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {

        public CartController()
        {
        }

        // [HttpPost("/additem")]
        // public IActionResult OnGetAddItem(int id)
        // {
        //     string raw;
        //     var cart = new List<CartDTO>();
        //     if (HttpContext.Request.Cookies.TryGetValue(CookieHelper.keyCartCookie, out raw))
        //         cart = JsonSerializer.Deserialize<List<CartDTO>>(raw);
        //     cart.Add(new CartDTO() { ProductId = id, Quantity = 1 });
        //     HttpContext.Response.Cookies.Append(CookieHelper.keyCartCookie, JsonSerializer.Serialize(cart));
        //     return new OkResult();
        // }
    }
}