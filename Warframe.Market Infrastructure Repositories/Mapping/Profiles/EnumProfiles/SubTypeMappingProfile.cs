using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class SubTypeMappingProfile : Profile
    {
        public SubTypeMappingProfile()
        {
            CreateMap<Market_Infrastructure.SubTypeType, Market_DomainModels.Enums.SubType>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.SubType>());

            CreateMap<Market_DomainModels.Enums.SubType, Market_Infrastructure.SubTypeType>().ConvertUsing(val
                => new Market_Infrastructure.SubTypeType { ID = (int)val, Type = val.ToString() });
        }
    }
}
