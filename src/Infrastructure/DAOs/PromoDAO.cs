using System;
using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Infrastructure.EF;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Infrastructure.DAOs
{
    public class PromoDAO : BaseDAO<Promotion>, IPromotionDAO
    {
        public PromoDAO(ILogger<string> logger, WatchContext context) : base(logger, context)
        {
        }

        public CodeProm GetCodeProm(string coupon)
        {
            var dNow = DateTime.Now;
            var re = _context.CodeProms
                .Where(item => item.CodeCoupon == coupon && item.Promotion.isShow == true && item.Promotion.FromDate >= dNow && dNow <= item.Promotion.ToDate);
            return re.FirstOrDefault();
        }

        public ICollection<BillProm> GetListBillProm(bool isAvailable)
        {
            if (!isAvailable) return _context.BillProms.ToList();
            var dNow = DateTime.Now;
            var re = _context.BillProms.Where(item => item.Promotion.isShow == true && item.Promotion.FromDate >= dNow && dNow <= item.Promotion.ToDate);
            return re.ToList();
        }

        public ICollection<CodeProm> GetListCodeProm(bool isAvailable)
        {
            if (!isAvailable) return _context.CodeProms.ToList();
            var dNow = DateTime.Now;
            var re = _context.CodeProms.Where(item => item.Promotion.isShow == true && item.Promotion.FromDate >= dNow && dNow <= item.Promotion.ToDate);
            return re.ToList();
        }

        public ICollection<ProductProm> GetListProductProm(bool isAvailable)
        {
            if (!isAvailable) return _context.ProductProms.ToList();
            var dNow = DateTime.Now;
            var re = _context.ProductProms.Where(item => item.Promotion.isShow == true && item.Promotion.FromDate >= dNow && dNow <= item.Promotion.ToDate);
            return re.ToList();
        }



        // public bool UpdateBillProm(int promId, Dictionary<string, object> newObject)
        // {
        //     if (!this.CheckConnect()) return false;
        //     try
        //     {
        //         ProductDetail obj = _context.Find<ProductDetail>(id);
        //         if (obj == null) return false;
        //         UpdateDataFor<ProductDetail>(obj, newObject);
        //         _context.SaveChangesAsync().Wait();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return false;
        //     }
        // }

        // public bool UpdateCodeProm(int promId, Dictionary<string, object> newObject)
        // {
        //     if (!this.CheckConnect()) return false;
        //     try
        //     {
        //         ProductDetail obj = _context.Find<ProductDetail>(promId);
        //         if (obj == null) return false;
        //         UpdateDataFor<ProductDetail>(obj, newObject);
        //         _context.SaveChangesAsync().Wait();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return false;
        //     }
        // }

        // public bool UpdateProductProm(int promId, Dictionary<string, object> newObject)
        // {
        //     if (!this.CheckConnect()) return false;
        //     try
        //     {
        //         ProductDetail obj = _context.Find<ProductDetail>(id);
        //         if (obj == null) return false;
        //         UpdateDataFor<ProductDetail>(obj, newObject);
        //         _context.SaveChangesAsync().Wait();
        //         return true;
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex.Message);
        //         return false;
        //     }
        // }
    }
}