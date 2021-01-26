using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Helper;

namespace Web.Pages
{
    public class ErrorModel : PageModel
    {
        public void OnGet(int code)
        {
            string msg = "";
            if (code != 0) msg = ErrorHelper.GetMsg(code);
            ViewData["message"] = msg;
        }
    }
}
