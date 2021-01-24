using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Web.Helper
{
    public class RouteHelper
    {
        public static string CreateRouter(int cateId, int bandId, int wireId)
        {
            string route = "";
            switch (cateId)
            {
                case 1:
                    route += "dong-ho-nam";
                    break;
                case 2:
                    route += "dong-ho-nu";
                    break;
                case 3:
                    route += "dong-ho-doi";
                    break;
                case 4:
                    route += "phu-kien";
                    break;
                default:
                    route += "";
                    break;
            };
            if (bandId != 0 && wireId != 0) route += "?b=" + bandId + "&&w=" + wireId;
            else if (bandId != 0) route += "?b=" + bandId;
            else if (wireId != 0) route += "?w=" + wireId;
            return route;
        }
    }
}