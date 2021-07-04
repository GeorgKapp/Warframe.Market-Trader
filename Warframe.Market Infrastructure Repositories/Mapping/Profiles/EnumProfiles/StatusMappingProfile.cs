using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class StatusMappingProfile : Profile
    {
        public StatusMappingProfile()
        {
            CreateMap<Market_Infrastructure.StatusType, Market_DomainModels.Enums.Status>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.Status>());

            CreateMap<Market_DomainModels.Enums.Status, Market_Infrastructure.StatusType>().ConvertUsing(val
                => new Market_Infrastructure.StatusType { ID = (int)val, Type = val.ToString() });
        }
    }
}
