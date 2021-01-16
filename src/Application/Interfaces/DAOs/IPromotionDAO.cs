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

        // bool UpdateBillProm(int promId, Dictionary<string, object> newObject);
        // bool UpdateProductProm(int promId, Dictionary<string, object> newObject);
        // bool UpdateCodeProm(int promId, Dictionary<string, object> newObject);
    }
}