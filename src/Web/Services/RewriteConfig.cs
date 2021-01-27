using Microsoft.AspNetCore.Rewrite;

namespace Web.Services
{
    public class RewriteConfig
    {
        public static RewriteOptions options = new RewriteOptions()
                .AddRewrite("dong-ho-nam", "listproduct/1", skipRemainingRules: true)
                .AddRewrite("dong-ho-nu", "listproduct/2", skipRemainingRules: true)
                .AddRewrite("dong-ho-doi", "listproduct/3", skipRemainingRules: true)
                .AddRewrite("phu-kien", "listproduct/4", skipRemainingRules: true)
                .AddRewrite("khuyen-mai", "listproduct?handler=discount", skipRemainingRules: true)
                .AddRewrite("tim-kiem", "listproduct?handler=search", skipRemainingRules: true);
        // .AddRewrite("gio-hang", "cart", skipRemainingRules: true);
        // .AddRewrite("san-pham", "productdetail", skipRemainingRules: true);

    }
}