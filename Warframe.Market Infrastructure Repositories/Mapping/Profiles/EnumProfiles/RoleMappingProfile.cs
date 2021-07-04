using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Market_Infrastructure.RoleType, Market_DomainModels.Enums.Role>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.Role>());

            CreateMap<Market_DomainModels.Enums.Role, Market_Infrastructure.RoleType>().ConvertUsing(val
                => new Market_Infrastructure.RoleType { ID = (int)val, Type = val.ToString() });
        }
    }
}
