using Application.Domains;
using Application.Interfaces.DAOs;
using Application.Interfaces.Services;

namespace Application.Services
{
    public class PhoneService : AbstractService<Phone>, IPhoneService
    {
        public PhoneService(IBaseDAO<Phone> db) : base(db)
        {
        }
    }
}