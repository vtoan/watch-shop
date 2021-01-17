using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class AddressService : AbstractService<Address>, IAddressService
    {
        public AddressService(IBaseDAO<Address> db) : base(db)
        {
        }
    }
}