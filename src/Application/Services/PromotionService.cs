using System.Collections.Generic;
using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class PromotionService : AbstractService<Promotion>, IPromotionService
    {
        public PromotionService(IBaseDAO<Promotion> db, ICache cache) : base(db, cache)
        {
        }

        public ICollection<BillProm> GetListBillProm(bool isAvailable = false)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<ProductProm> GetListProductProm(bool isAvailable = false)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateBillProm(int promId, BillProm billProm)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateProductProm(int promId, ProductProm productProm)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateStatus(int id, bool status)
        {
            throw new System.NotImplementedException();
        }
    }
}