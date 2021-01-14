using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class FeeService : AbstractService<Fee>, IFeeService
    {
        private const string _CACHE = "_LIST_FEE";

        public FeeService(IBaseDAO<Fee> db, ICache cache) : base(db, cache, _CACHE)
        {
        }
    }
}