using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Helper;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class InfoService : AbstractService<InfoShop>, IInfoService
    {
        public InfoService(IBaseDAO<InfoShop> db) : base(db)
        {
        }

        public ISeoDomain GetSeo(int id)
        {
            return base.GetItem(id);
        }
    }
}