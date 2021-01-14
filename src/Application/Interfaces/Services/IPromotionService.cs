using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.Services
{
    public interface IPromotionService : IBaseService<Promotion>
    {
        bool UpdateStatus(int id, bool status);
        ICollection<BillProm> GetListBillProm(bool isAvailable = false);
        ICollection<ProductProm> GetListProductProm(bool isAvailable = false);
        bool UpdateBillProm(int promId, BillProm billProm);
        bool UpdateProductProm(int promId, ProductProm productProm);
    }
}