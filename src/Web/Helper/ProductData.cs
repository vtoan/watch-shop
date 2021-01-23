using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Domains;
using Web.Models;

namespace Web.Helper
{
    public class ProductData
    {
        public static List<int> ListProductNewId = new List<int>();

        public static void CheckProm(List<ProductDTO> products, List<ProductProm> listProm)
        {
            foreach (var item in listProm)
                CheckProductAsync(products, item).Wait();
        }

        public static Task CheckProductAsync(List<ProductDTO> products, ProductProm prom)
        {
            Action act = () =>
                {
                    int[] arIds = JsonSerializer.Deserialize<int[]>(prom.ProductIds);
                    int cateId = (int)(prom.CategoryId ?? 0);
                    int bandId = (int)(prom.BandId ?? 0);
                    double discount = (double)(prom.Discount ?? 0);
                    foreach (var p in products)
                    {
                        if (cateId != 0 && p.CategoryId == cateId) p.Discount = discount;
                        if (bandId != 0 && p.BandId == bandId) p.Discount = discount;
                        if (arIds.Length > 0 && arIds.Contains(p.Id)) p.Discount = discount;
                    }
                };
            Task task = new Task(act);
            task.Start();
            return task;
        }
    }
}