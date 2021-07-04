using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class RegionMappingProfile : Profile
    {
        public RegionMappingProfile()
        {
            CreateMap<Market_Infrastructure.RegionType, Market_DomainModels.Enums.Region>().ConvertUsing(val 
                => val.Type.ParseEnum<Market_DomainModels.Enums.Region>());

            CreateMap<Market_DomainModels.Enums.Region, Market_Infrastructure.RegionType>().ConvertUsing(val 
                =>  new Market_Infrastructure.RegionType { ID = (int)val, Type = val.ToString() });
        }
    }
}
