using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class PlatformMappingProfile : Profile
    {
        public PlatformMappingProfile()
        {
            CreateMap<Market_Infrastructure.PlatformType, Market_DomainModels.Enums.Platform>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.Platform>());

            CreateMap<Market_DomainModels.Enums.Platform, Market_Infrastructure.PlatformType>().ConvertUsing(val
                => new Market_Infrastructure.PlatformType { ID = (int)val, Type = val.ToString() });
        }
    }
}
