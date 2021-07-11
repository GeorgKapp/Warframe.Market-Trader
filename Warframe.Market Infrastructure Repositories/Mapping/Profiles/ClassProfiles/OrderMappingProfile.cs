using AutoMapper;
using Warframe.Market_DomainModels.Enums;
using Warframe.Market_Infrastructure;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.Order, Order>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(source => source.User.ID))
                .ForMember(dest => dest.PlatformTypeID, opt => opt.MapFrom(source => (int?)source.Platform))
                .ForMember(dest => dest.OrderTypeID, opt => opt.MapFrom(source => (int?)source.OrderType))
                .ForMember(dest => dest.SubTypeTypeID, opt => opt.MapFrom(source => (int?)source.SubType))
                .ForMember(dest => dest.RegionTypeID, opt => opt.MapFrom(source => (int?)source.Region))
                .ForMember(dest => dest.OrderType, opt => opt.Ignore());

            CreateMap<Order, Market_DomainModels.Models.Order>()
                .IncludeAllDerived()
                .ForMember(dest => dest.User, opt => opt.MapFrom(source => source.User))
                .ForMember(dest => dest.Platform, opt => opt.MapFrom(source => (Platform?)source.PlatformTypeID))
                .ForMember(dest => dest.OrderType, opt => opt.MapFrom(source => (Market_DomainModels.Enums.OrderType?)source.OrderTypeID))
                .ForMember(dest => dest.SubType, opt => opt.MapFrom(source => (SubType?)source.SubTypeTypeID))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(source => (Market_DomainModels.Enums.OrderType?)source.RegionTypeID))
                .ForMember(dest => dest.OrderType, opt => opt.Ignore());
        }
    }
}
