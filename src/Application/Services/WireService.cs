using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class WireService : AbstractService<Wire>, IWireService
    {
        public WireService(IBaseDAO<Wire> db) : base(db)
        {
        }
    }
}