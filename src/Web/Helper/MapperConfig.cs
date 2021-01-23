using Application.Domains;
using AutoMapper;
using Web.Models;

namespace Web.Helper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(src => src.BandName, act => act.MapFrom(des => des.Band.Name))
                .ForMember(src => src.CategoryName, act => act.MapFrom(des => des.Category.Name))
                .ForMember(src => src.WireName, act => act.MapFrom(des => des.TypeWire.Name));
        }
    }
}