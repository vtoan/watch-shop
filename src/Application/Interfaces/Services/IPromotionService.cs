using System.Collections.Generic;
using Application.Domains;
using Application.Enums;

namespace Application.Interfaces.Services
{
    public interface IPromotionService : IBaseService<Promotion>
    {
        bool UpdateStatus(int id, bool status);
        CodeProm GetCodeProm(string coupon);
        ICollection<BillProm> GetListBillProm(bool isAvailable = false);
        ICollection<ProductProm> GetListProductProm(bool isAvailable = false);
        ICollection<CodeProm> GetListCodeProm(bool isAvailable = false);
        //remove
        // bool UpdateBillProm(int promId, BillProm billProm);
        // bool UpdateProductProm(int promId, ProductProm productProm);
        // bool UpdateCodeProm(int promId, CodeProm codeProm);
        //end-remove
        bool UpdatePromDetail(int promId, object codeProm, EPromo promType);
    }
}