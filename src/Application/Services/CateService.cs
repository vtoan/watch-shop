using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Helper;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class CateService : AbstractService<Category>, ICateService
    {
        private const string _CACHE = "_LIST_CATE";

        public CateService(IBaseDAO<Category> db, ICache cache) : base(db, cache, _CACHE)
        {
        }

        public ISeoDomain GetSeo(int id)
        {
            return base.GetItem(id);
        }
    }
}