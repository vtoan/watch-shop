using System;
using System.Collections.Generic;
using System.Linq;
using Application.Domains;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Helper;
using Web.Models;

namespace Web.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductService _productSer;
        private readonly IPromotionService _promotionSer;
        private readonly IMapper _mapper;
        private readonly ICateService _cateSer;
        private readonly ICache _cache;
        //paging
        private readonly int _pageItems = 8;
        public int PageNumber = 1;
        //route
        [BindProperty(Name = "category", SupportsGet = true)]
        public int cateId { get; set; }
        [BindProperty(Name = "b", SupportsGet = true)]
        public int bandId { get; set; }
        [BindProperty(Name = "w", SupportsGet = true)]
        public int wireId { get; set; }
        //
        public List<ProductDTO> ListProducts { get; set; }
        private List<ProductProm> _lsProm { get; set; }
        public ProductModel(
            IProductService productSer,
            ICateService cateSer,
            IPromotionService promotionSer,
            IMapper mapper,
            ICache cache)
        {
            _productSer = productSer;
            _cateSer = cateSer;
            _mapper = mapper;
            _promotionSer = promotionSer;
            _cache = cache;
        }

        public void OnGet(int category, int b, int w, int p = 1)
        {
            GetData(category, b, w);
            ListProducts = GetPage(ListProducts, 1);
        }

        public IActionResult OnGetAjax(int category, int b, int w, int o, int p = 1)
        {
            var re = _cache.GetData<List<ProductDTO>>(@"c{category},b{b},w{w}");
            if (re == null)
            {
                GetData(category, b, w);
                re = ListProducts;
            }
            if (o != 0) re = OrderBy(re, o);
            return Partial("_ProductPartical", GetPage(re, p));
        }

        private void GetData(int c, int b, int w)
        {
            GetProm();
            GetProduct(c, b, w);
            ProductData.CheckProm(ListProducts, _lsProm);
            _cache.AddData(@"c{c},b{b},w{w}", ListProducts);
        }

        private void GetProm()
        {
            _lsProm = new List<ProductProm>();
            _lsProm = (List<ProductProm>)_promotionSer.GetListProductProm();
        }

        private void GetProduct(int c, int b, int w)
        {
            ListProducts = new List<ProductDTO>();
            var asset = _productSer.GetListByCate(c, b, w);
            if (asset == null || asset.Count == 0) return;
            CalcPage(asset.Count);
            foreach (var item in asset)
                ListProducts.Add(_mapper.Map<ProductDTO>(item));
        }

        private List<ProductDTO> GetPage(List<ProductDTO> list, int p = 1)
        {
            if (p == PageNumber) return list.Skip((p - 1) * _pageItems).ToList();
            return list.Skip((p - 1) * _pageItems).Take((p * _pageItems)).ToList();
        }

        private List<ProductDTO> OrderBy(List<ProductDTO> list, int o)
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

        private double CalcPrice(ProductDTO item)
        {
            var re = item.Price - (item.Discount % 1 == 0 ? item.Discount : (item.Price * item.Discount));
            return re;
        }

        private void CalcPage(int countList)
        {
            if (countList % 8 != 0)
                PageNumber = countList / 8;
            else
                PageNumber = (int)Math.Round((decimal)(countList / 8));
        }

    }

}
