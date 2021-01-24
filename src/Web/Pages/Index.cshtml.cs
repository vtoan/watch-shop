using System;
using System.Collections.Generic;
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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productSer;
        private readonly IPromotionService _promotionSer;
        private readonly IMapper _mapper;
        //SEO
        [ViewData]
        public string TitleSEO { get; set; }
        [ViewData]
        public string DescriptionSEO { get; set; }
        [ViewData]
        public string ImageSEO { get; set; }
        //Property
        public List<ProductDTO> ListProductFeatured { get; set; }
        public List<ProductDTO> ListProductNew { get; set; }

        private List<ProductProm> _lsProm = new List<ProductProm>();

        public IndexModel(ILogger<IndexModel> logger, IProductService productSer, IMapper mapper, IPromotionService promotionSer)
        {
            _logger = logger;
            _productSer = productSer;
            _mapper = mapper;
            _promotionSer = promotionSer;
        }

        public void OnGet()
        {
            _lsProm = (List<ProductProm>)_promotionSer.GetListProductProm();
            GetListNew();
            GetListFeatured();
        }

        private Task GetListFeatured()
        {
            ListProductFeatured = new List<ProductDTO>();
            var asset = _productSer.GetListSeller(8);
            Action action = () =>
            {
                if (asset == null || asset.Count == 0) return;
                foreach (var item in asset)
                    ListProductFeatured.Add(_mapper.Map<ProductDTO>(item));
                ProductData.CheckProm(ListProductFeatured, _lsProm);
            };
            Task task = new Task(action);
            task.Start();
            return task;
        }

        private Task GetListNew()
        {
            ListProductNew = new List<ProductDTO>();
            var asset = _productSer.GetListById(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            Action action = () =>
            {
                if (asset == null || asset.Count == 0) return;
                foreach (var item in asset)
                    ListProductNew.Add(_mapper.Map<ProductDTO>(item));
                ProductData.CheckProm(ListProductNew, _lsProm);
            };
            Task task = new Task(action);
            task.Start();
            return task;
        }
    }
}
