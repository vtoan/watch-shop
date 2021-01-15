using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IPromotionDAO : IBaseDAO<Promotion>
    {
        ICollection<BillProm> GetListBillProm(bool isAvailable);
        ICollection<ProductProm> GetListProductProm(bool isAvailable);
        bool UpdateBillProm(int promId, Dictionary<string, object> newObject);
        bool UpdateProductProm(int promId, Dictionary<string, object> newObject);
    }
}