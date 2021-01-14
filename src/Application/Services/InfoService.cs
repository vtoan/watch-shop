using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class InfoService : AbstractService<InfoShop>, IInfoService
    {
        private const string _CACHE = "_LIST_FEE";

        public InfoService(IBaseDAO<InfoShop> db, ICache cache) : base(db, cache, _CACHE)
        {
        }
    }
}