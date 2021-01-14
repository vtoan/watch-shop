using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IProductDAO : IBaseDAO<Product>
    {
        ICollection<Product> FindItem(string query);
        ICollection<Product> GetListByIds(int[] arrayId);
        ICollection<Product> GetByBand(int bandId, int catId, int wireId, bool isAdmin);
        ICollection<Product> GetByCate(int catId, int bandId, int wireId, bool isAdmin);
        ICollection<Product> GetList(bool isAdmin);
        ICollection<Product> GetListFeatured();
        ProductDetail GetDetail(int id);
        bool UpdateDetail(int id, Dictionary<string, object> newObject);
    }
}