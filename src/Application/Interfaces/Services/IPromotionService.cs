using System.Collections.Generic;
using Application.Domains;
using Application.Enums;

namespace Application.Interfaces.Services
{
    public interface IPromotionService :
        IGetItem<Promotion>, IDeleteItem<Promotion>, IUpdateItem<Promotion>, IGetListItem<Promotion>
    {
        Promotion AddItem(Promotion newObject, EPromo promType);
        bool UpdateStatus(int id, bool status);
        CodeProm GetCodeProm(string coupon);
        ICollection<BillProm> GetListBillProm(bool isAvailable = false);
        ICollection<ProductProm> GetListProductProm(bool isAvailable = false);
        ICollection<CodeProm> GetListCodeProm(bool isAvailable = false);
        bool UpdatePromItem(int promId, object codeProm, EPromo promType);

        BillProm AddBillItem(int promId, BillProm newObject);
        CodeProm AddCodeItem(int promId, CodeProm newObject);
        ProductProm AddProducttem(int promId, ProductProm newObject);
    }
}