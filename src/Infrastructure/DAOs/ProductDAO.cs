using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Infrastructure.EF;
using System.Linq;
using System;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DAOs
{
    public class ProductDAO : BaseDAO<Product>, IProductDAO
    {
        public ProductDAO(ILogger<string> logger, WatchContext context) : base(logger, context)
        {
        }

        public ICollection<Product> FindItem(string query)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.isDel == false)
                .Where(item => item.Name.Contains(query) || item.Band.Name.Contains(query));
                return re.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetListByIds(int[] arrayId)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.isDel == false)
                            .Where(item => arrayId.Contains(item.Id));
                return re.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetByBand(int bandId, int catId, int wireId, bool isAdmin)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.BandId == bandId && item.isDel == false);
                if (catId > 0) re = re.Where(item => item.CategoryId == catId);
                if (wireId > 0) re = re.Where(item => item.WireId == wireId);
                if (isAdmin == false) re = re.Where(item => item.isShow == true);
                return re.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetByCate(int catId, int bandId, int wireId, bool isAdmin)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.CategoryId == catId && item.isDel == false);
                if (bandId > 0) re = re.Where(item => item.BandId == bandId);
                if (wireId > 0) re = re.Where(item => item.WireId == wireId);
                if (isAdmin == false) re = re.Where(item => item.isShow == true);
                return re.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ProductDetail GetDetail(int id)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.ProductDetails.Find(id);
                return re;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetList(bool isAdmin = false)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.isDel == false);
                if (isAdmin == false) re = re.Where(item => item.isDel == false);
                return re.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public bool UpdateDetail(int id, Dictionary<string, object> newObject)
        {
            if (!this.CheckConnect()) return false;
            try
            {
                ProductDetail obj = _context.Find<ProductDetail>(id);
                if (obj == null) return false;
                UpdateDataFor<ProductDetail>(obj, newObject);
                _context.SaveChangesAsync().Wait();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}