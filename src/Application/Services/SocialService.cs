using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class SocialService : AbstractService<Social>, ISocialService
    {
        private const string _CACHE = "_LIST_SOCIAL";

        public SocialService(IBaseDAO<Social> db, ICache cache) : base(db, cache, _CACHE)
        {
        }
    }
}