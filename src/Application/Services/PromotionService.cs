using System;
using System.Collections.Generic;
using Application.Domains;
using Application.Enums;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class PromotionService : AbstractService<Promotion>, IPromotionService
    {
        private const string _CACHE_BILL = "_BILL_PROM";
        private const string _CACHE_PROD = "_PRODUCT_PROM";
        private readonly IPromotionDAO _dao;

        public PromotionService(IPromotionDAO dao, ICache cache) : base(dao, cache)
        {
            _dao = dao;
        }

        public CodeProm GetCodeProm(string coupon)
        {
            throw new NotImplementedException();
        }

        public ICollection<BillProm> GetListBillProm(bool isAvailable = false)
        {
            if (isAvailable) return _dao.GetListBillProm(isAvailable);
            var re = _cache.GetData<List<BillProm>>(_CACHE_BILL);
            if (re == null || re?.Count == 0)
            {
                re = (List<BillProm>)_dao.GetListBillProm(isAvailable);
                if (re != null && re?.Count > 0) _cache.AddData(_CACHE_BILL, re, TimeSpan.FromDays(1));
            }
            return re;
        }

        public ICollection<ProductProm> GetListProductProm(bool isAvailable = false)
        {
            if (isAvailable) return _dao.GetListProductProm(isAvailable);
            var re = _cache.GetData<List<ProductProm>>(_CACHE_PROD);
            if (re == null || re?.Count == 0)
            {
                re = (List<ProductProm>)_dao.GetListProductProm(isAvailable);
                if (re != null && re?.Count > 0) _cache.AddData(_CACHE_PROD, re, TimeSpan.FromDays(1));
            }
            return re;
        }

        public ICollection<CodeProm> GetListCodeProm(bool isAvailable = false)
        {
            if (isAvailable) return _dao.GetListCodeProm(isAvailable);
            var re = _cache.GetData<List<CodeProm>>(_CACHE_PROD);
            if (re == null || re?.Count == 0)
            {
                re = (List<CodeProm>)_dao.GetListCodeProm(isAvailable);
                if (re != null && re?.Count > 0) _cache.AddData(_CACHE_PROD, re, TimeSpan.FromDays(1));
            }
            return re;
        }

        // public bool UpdateBillProm(int promId, BillProm billProm)
        // {
        //     if (promId == 0 || billProm == null) return false;
        //     var propModifed = GetPropChangedOf(billProm);
        //     if (propModifed?.Count == 0) return true;
        //     return _dao.UpdateBillProm(promId, propModifed);
        // }

        // public bool UpdateCodeProm(int promId, CodeProm codeProm)
        // {
        //     if (promId == 0 || codeProm == null) return false;
        //     var propModifed = GetPropChangedOf(codeProm);
        //     if (propModifed?.Count == 0) return true;
        //     return _dao.UpdateCodeProm(promId, propModifed);
        // }

        // public bool UpdateProductProm(int promId, ProductProm productProm)
        // {
        //     if (promId == 0 || productProm == null) return false;
        //     var propModifed = GetPropChangedOf(productProm);
        //     if (propModifed?.Count == 0) return true;
        //     return _dao.UpdateProductProm(promId, propModifed);
        // }

        public bool UpdateStatus(int id, bool status)
        {
            if (id <= 0) return false;
            var propModifed = CreatePropChanged("isShow", status);
            var execResult = _dao.Update(id, propModifed);
            if (execResult) _cache.MarkManyChanged(new string[] { _CACHE_BILL, _CACHE_PROD });
            return execResult;
        }
        public bool UpdatePromDetail(int promId, object objectProm, EPromo promType)
        {
            if (promId == 0 || objectProm == null) return false;
            var propModifed = GetPropChangedOf(objectProm);
            if (propModifed?.Count == 0) return true;
            switch (promType)
            {
                case EPromo.Bill:
                    return _dao.Update<BillProm>(promId, propModifed);
                case EPromo.Product:
                    return _dao.Update<ProductProm>(promId, propModifed);
                case EPromo.Coupon:
                    return _dao.Update<CodeProm>(promId, propModifed);
                default:
                    return false;
            }
        }
    }
}