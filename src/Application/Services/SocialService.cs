using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class SocialService : AbstractService<Social>, ISocialService
    {
        public SocialService(IBaseDAO<Social> db) : base(db)
        {
        }
    }
}