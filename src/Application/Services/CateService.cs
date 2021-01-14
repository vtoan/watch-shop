using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class CateService : AbstractService<Category>, ICateService
    {
        private const string _CACHE = "_LIST_CATE";

        public CateService(IBaseDAO<Category> db, ICache cache, string cacheKey = null) : base(db, cache, _CACHE)
        {
        }
    }
}