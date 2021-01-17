using System.Collections.Generic;
using Application.Domains;

namespace Application.Interfaces.DAOs
{
    public interface IPromotionDAO : IBaseDAO<Promotion>
    {
        CodeProm GetCodeProm(string coupon);
        ICollection<BillProm> GetListBillProm(bool isAvailable);
        ICollection<ProductProm> GetListProductProm(bool isAvailable);
        ICollection<CodeProm> GetListCodeProm(bool isAvailable);
    }
}