using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.Services
{
    public interface IProductService : IBaseService<Product>, ISeoService
    {
        // Product GetItem(int id, bool isAdmin = true);
        ICollection<Product> FindByQuery(string query, int items = 0);
        ICollection<Product> GetListById(int[] arrayId, bool isAdmin = false);
        ICollection<Product> GetListSeller(int count);
        ICollection<Product> GetListByCate(int cateId, int bandId = 0, int wireId = 0, bool isAdmin = false);
        ICollection<Product> GetListByBand(int bandId, int cateId = 0, int wireId = 0, bool isAdmin = false);
        bool UpdateStatus(int id, bool status);
        //Product Detail
        ProductDetail GetDetail(int id);
        bool UpdateDetail(int id, ProductDetail modifiedObject);

        // ICollection<Product> GetListDiscount();
    }
}