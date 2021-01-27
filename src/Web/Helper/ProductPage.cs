using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Application.Domains;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.DTO;
using Web.Models;

namespace Web.Helper
{
    public class ProductPage : PageModel
    {
        protected readonly string KEY_CACHE_DISCOUNT = "prod-discount";
        protected readonly IProductService _productSer;
        protected readonly IPromotionService _promotionSer;
        protected readonly IMapper _mapper;
        protected readonly int _pageItems = 8;
        //
        public List<ProductDTO> ListProducts { get; set; }
        protected List<ProductProm> _lsProm;

        public ProductPage(IProductService productSer, IMapper mapper, IPromotionService promotionSer)
        {
            _productSer = productSer;
            _mapper = mapper;
            _promotionSer = promotionSer;
            ListProducts = new List<ProductDTO>();
            //
            _lsProm = new List<ProductProm>();
            _lsProm = (List<ProductProm>)_promotionSer.GetListProductProm();
        }
        // ================= method =================
        protected string GetPathRequest(HttpContext context, int c = 0)
        {
            if (c != 0) return RouteHelper.SeoRoute.Find(item => item.Id == c).Path;
            else
            {
                if (context.Request.Query.ContainsKey("query"))
                {
                    string query = context.Request.Query["query"];
                    return "tim-kiem?query=" + query;
                }
                if (context.Request.Query["handler"] == "discount")
                {
                    return "khuyen-mai";
                }
                return context.Request.Path;
            }
        }

        protected void MapProductDTO(ICollection<Product> asset, ref int pageNumner)
        {
            if (asset == null || asset.Count == 0) return;
            if (pageNumner == 0) pageNumner = CalcPage(asset.Count);
            MapProductDTO(asset);
        }

        protected void MapProductDTO(ICollection<Product> asset)
        {
            if (ListProducts == null) ListProducts = new List<ProductDTO>();
            if (asset == null || asset.Count == 0) return;
            foreach (var item in asset)
            {
                var product = _mapper.Map<ProductDTO>(item);
                ListProducts.Add(product);
            }
            CheckProm(ListProducts);
        }

        protected int GetProductId(string nameInter)
        {
            var val = nameInter.Split("-").Last();
            return Int32.Parse(val);
        }

        protected List<ProductDTO> GetPage(List<ProductDTO> list, int p = 1)
        {
            if (p == 0) return list;
            return list.Skip((p - 1) * _pageItems).Take((_pageItems)).ToList();
        }

        protected List<ProductDTO> OrderBy(List<ProductDTO> list, int o)
        {
            switch (o)
            {
                case 1:
                    return list.OrderByDescending(item => item.SaleCount).ToList();
                case 2:
                    return list.OrderBy(item => item.Price).ToList();
                case 3:
                    return list.OrderByDescending(item => item.Price).ToList();
                default:
                    return null;
            }
        }

        protected double CalcPrice(ProductDTO item)
        {
            var re = item.Price - (item.Discount % 1 == 0 ? item.Discount : (item.Price * item.Discount));
            return re;
        }

        protected int CalcPage(int countList)
        {
            double pageNum = countList / _pageItems;
            if (countList % _pageItems == 0)
                return (int)pageNum;
            else
                return (int)Math.Floor(pageNum) + 1;
        }

        protected void CheckProm(List<ProductDTO> products)
        {
            foreach (var prom in _lsProm)
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
            }
        }
    }
}