using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Domains;
using Application.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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

        private readonly int _pageItems = 8;

        public int PageNumber = 1;
        public List<ProductDTO> ListProducts { get; set; }
        private List<ProductProm> _lsProm { get; set; }
        public ProductModel(IProductService productSer, ICateService cateSer, IPromotionService promotionService, IMapper mapper)
        {
            _productSer = productSer;
            _cateSer = cateSer;
            _mapper = mapper;
            _promotionSer = promotionService;
        }

        public void OnGet(int category, int b, int w, int p = 1)
        {
            GetProm();
            GetProduct(category, b, w, p);
            ProductData.CheckProm(ListProducts, _lsProm);
        }

        public IActionResult OnGetAjax(int category, int b, int w, int p = 1)
        {
            GetProm();
            GetProduct(category, b, w, p);
            ProductData.CheckProm(ListProducts, _lsProm);
            return Partial("_ProductPartical", ListProducts);
        }

        //
        private void GetProm()
        {
            _lsProm = new List<ProductProm>();
            _lsProm = (List<ProductProm>)_promotionSer.GetListProductProm();
        }

        private void GetProduct(int category, int b, int w, int p)
        {
            ListProducts = new List<ProductDTO>();
            var asset = _productSer.GetListByCate(category, b, w);
            if (asset == null || asset.Count == 0) return;
            CalcPage(asset.Count);
            if (p == PageNumber) asset = asset.Skip((p - 1) * _pageItems).ToList();
            else asset = asset.Skip((p - 1) * _pageItems).Take((p * _pageItems)).ToList();
            foreach (var item in asset)
                ListProducts.Add(_mapper.Map<ProductDTO>(item));

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
