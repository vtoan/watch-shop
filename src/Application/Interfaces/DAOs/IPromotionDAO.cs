using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IPromotionDAO : IBaseDAO<Promotion>
    {
        ICollection<BillProm> GetListBillProm(bool isAvailable);
        ICollection<ProductProm> GetListProductProm(bool isAvailable);
        bool UpdateBillProm(int promId, BillProm billProm);
        bool UpdateProductProm(int promId, ProductProm productProm);
    }
}