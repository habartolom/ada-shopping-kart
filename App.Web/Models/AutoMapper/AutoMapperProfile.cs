using App.Web.Models.Contracts.Users;
using App.Web.Models.Dtos;
using App.Web.Models.Entities;
using AutoMapper;

namespace App.Web.Models.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Person.Name))
                .ForMember(dest => dest.Address, src => src.MapFrom(x => x.Person.Address))
                .ForMember(dest => dest.Phone, src => src.MapFrom(x => x.Person.Phone));

            CreateMap<UserEntity, LoginResponseContract>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Person.Name))
                .ForMember(dest => dest.Role, src => src.MapFrom(x => x.Role.Name))
                .ForMember(dest => dest.Token, src => src.Ignore());

            
            CreateMap<OrderProductEntity, OrderProductDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Product.Id))
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.Price, src => src.MapFrom(x => x.Price))
                .ForMember(dest => dest.Quantity, src => src.MapFrom(x => x.Quantity));

            CreateMap<OrderEntity, OrderDetailDto>();
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}
