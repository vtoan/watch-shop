using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IProductDAO : IBaseDAO<Product>
    {
        ICollection<Product> FindItem(string query);
        ICollection<Product> GetByBand(int id);
        ICollection<Product> GetListByIds(int[] arrayId);
        ICollection<Product> GetList(bool isAdmin = false);
        ProductDetail GetDetail(int id);
    }
}