using Microsoft.AspNetCore.Rewrite;

namespace Web.Services
{
    public class RewriteConfig
    {
        public static RewriteOptions options = new RewriteOptions()
                .AddRewrite("dong-ho-nam", "product/1", skipRemainingRules: true)
                .AddRewrite("dong-ho-nu", "product/2", skipRemainingRules: true)
                .AddRewrite("dong-ho-doi", "product/3", skipRemainingRules: true)
                .AddRewrite("phu-kien", "product/4", skipRemainingRules: true);

    }
}