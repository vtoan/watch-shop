using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class TransportService : AbstractService<UnitTransport>, ITransportService
    {
        public TransportService(IBaseDAO<UnitTransport> db, ICache cache) : base(db, cache)
        {
        }
    }
}