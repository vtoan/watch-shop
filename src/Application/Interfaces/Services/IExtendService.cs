using Application.Domains;

namespace Application.Interfaces.Services
{
    public interface IBandService : IBaseService<Band> { }
    public interface IFeeService : IBaseService<Fee> { }
    public interface IWireService : IBaseService<Wire> { }
    public interface ISocialService : IBaseService<Social> { }
    public interface IAddressService : IBaseService<Address> { }
    public interface IPhoneService : IBaseService<Phone> { }
    public interface ITransportService : IBaseService<UnitTransport> { }
    public interface IOrderStatusService : IGetListItem<OrderStatus>, IGetItem<OrderStatus>, IAddItem<OrderStatus> { }
    public interface ICateService :
        IGetItem<Category>, IAddItem<Category>, IUpdateItem<Category>, IGetListItem<Category>
    { }
    public interface IInfoService :
        IGetItem<InfoShop>, IUpdateItem<InfoShop>
    { }

}