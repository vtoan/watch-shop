using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Web.Helper
{
    public enum SeoType
    {
        Home, Discount, Category, Search, Detail
    }
    public class RouteHelper
    {
        public static List<RouteModel> SeoRoute = new List<RouteModel>()
        {
            new RouteModel() { Id=1,Path="dong-ho-nam",Name="Đồng hồ nam"},
            new RouteModel() { Id=2,Path="dong-ho-nu",Name="Đồng hồ nữ"},
            new RouteModel() { Id=3,Path="dong-ho-doi",Name="Đồng hồ  đôi"},
            new RouteModel() { Id=4,Path="phu-kien",Name="Phụ kiện"},
            new RouteModel() { Id=5,Path="tim-kiem",Name="Kết quả tìm kiếm cho",Hander="search"},
            new RouteModel() { Id=6,Path="khuyen-mai",Name="Khuyễn mãi",Hander="discount"},

        };
        public static string CurrentRouter(string path, int bandId, int wireId)
        {
            string route = "";
            if (bandId != 0) route += (path.Contains('?') ? "&&" : "?") + "b=" + bandId;
            if (wireId != 0) route += (path.Contains('?') ? "&&" : "?") + "w=" + wireId;
            route += (path.Contains('?') || route.Contains("?")) ? "&&" : "?";
            return path + route;
        }
    }
    public class RouteModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string PathRoot { get; set; }
        public string Hander { get; set; } = "";
    }
}