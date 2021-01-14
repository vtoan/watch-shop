using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Infrastructure.EF;
using System.Linq;
using System;

namespace Infrastructure.DAOs
{
    public class ProductDAO : BaseDAO<Product>, IProductDAO
    {
        public ProductDAO(WatchContext context) : base(context) { }

        public ICollection<Product> FindItem(string query)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.Name.Contains(query) || item.Band.Name.Contains(query));
                return re.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetByBand(int id)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.BandId == id);
                return re.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetByBand(int bandId, int catId, int wireId, bool isAdmin)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetByCate(int catId, int bandId, int wireId, bool isAdmin)
        {
            throw new NotImplementedException();
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
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetList(bool isAdmin = false)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => item.isDel == false);
                return re.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetListByIds(int[] arrayId)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Products.Where(item => arrayId.Contains(item.Id));
                return re.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<Product> GetListFeatured()
        {
            throw new NotImplementedException();
        }

        public bool UpdateDetail(int id, Dictionary<string, object> newObject)
        {
            throw new NotImplementedException();
        }
    }
}