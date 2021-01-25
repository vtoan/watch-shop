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
    public class IndexModel : ProductPage
    {
        private readonly IInfoService _infoSer;
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

        public IndexModel(
            IProductService productSer,
            IMapper mapper,
            IPromotionService promotionSer,
            IInfoService infoSer) : base(productSer, mapper, promotionSer)
        {
            _infoSer = infoSer;
        }

        public void OnGet()
        {
            GetListNew();
            GetListFeatured();
            var info = _infoSer.GetItem(1);
            TitleSEO = info?.SeoTitle ?? "";
            DescriptionSEO = info?.SeoDescription ?? "";
            ImageSEO = info?.SeoImage ?? "";
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
                CheckProm(ListProductFeatured);
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
                CheckProm(ListProductNew);
            };
            Task task = new Task(action);
            task.Start();
            return task;
        }
    }
}
