using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class WireService : AbstractService<Wire>, IWireService
    {
        private const string _CACHE = "_LIST_FEE";
        public WireService(IBaseDAO<Wire> db, ICache cache, string cacheKey = null) : base(db, cache, _CACHE)
        {
        }
    }
}