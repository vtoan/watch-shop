using System.Collections.Generic;
using Application.Domains;
using Application.Data;

namespace Application.Interfaces.Services
{
    public interface IProductService : IBaseService<Product>
    {
        ICollection<Product> FindByQuery(string query);
        // ICollection<Product> GetListById(int[] arrayId);
        ICollection<Product> GetListByBand(int id);
        // ICollection<Product> GetListFeatured();
        // ICollection<Product> GetListDiscount();
        ICollection<Product> GetListItems(bool isAdmin = false);
        //
        ICollection<Product> FilterByCate(ICollection<Product> listItems, int cateId);
        ICollection<Product> FilterByWire(ICollection<Product> listItems, int wireId);
        // ICollection<Product> GetListOrderBy(ICollection<Product> listItems, ProductOrderBy orderBy);
        //
        ProductDetail GetDetail(int id);
        //
        bool UpdateStatus(int id, bool status);
    }
}