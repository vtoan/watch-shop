using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IProductDAO : IBaseDAO<Product>
    {
        ICollection<Product> FindItem(string query, int items);
        Product GetByName(string name);
        ICollection<Product> GetListSeller(int count);

        ICollection<Product> GetList(bool isAdmin);
        ICollection<Product> GetListByIds(int[] arrayId, bool isAdmin);
        ICollection<Product> GetByBand(int bandId, int catId, int wireId, bool isAdmin);
        ICollection<Product> GetByCate(int catId, int bandId, int wireId, bool isAdmin);

    }
}