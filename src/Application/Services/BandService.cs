using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class BandService : AbstractService<Band>, IBandService
    {
        private const string _CACHE_BAND = "_LIST_BAND";
        public BandService(IBaseDAO<Band> db, ICache cache) : base(db, cache, _CACHE_BAND)
        {
        }
    }
}