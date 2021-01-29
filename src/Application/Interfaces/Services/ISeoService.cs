using Application.Interfaces.Helper;

namespace Application.Interfaces.Services
{
    public interface ISeoService
    {
        ISeoDomain GetSeo(int id);
    }
}