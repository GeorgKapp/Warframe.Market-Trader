using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class OrderTypeMappingProfile : Profile
    {
        public OrderTypeMappingProfile()
        {
            CreateMap<Market_Infrastructure.OrderType, Market_DomainModels.Enums.OrderType>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.OrderType>());

            CreateMap<Market_DomainModels.Enums.OrderType, Market_Infrastructure.OrderType>().ConvertUsing(val
                => new Market_Infrastructure.OrderType { ID = (int)val, Type = val.ToString() });
        }
    }
}
