using AutoMapper;
using Warframe.Market_Infrastructure_Repositories.Utilities;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles
{
    public class IconFormatMappingProfile : Profile
    {
        public IconFormatMappingProfile()
        {
            CreateMap<Market_Infrastructure.IconFormatType, Market_DomainModels.Enums.IconFormat>().ConvertUsing(val
                => val.Type.ParseEnum<Market_DomainModels.Enums.IconFormat>());

            CreateMap<Market_DomainModels.Enums.IconFormat, Market_Infrastructure.IconFormatType>().ConvertUsing(val
                => new Market_Infrastructure.IconFormatType { ID = (int)val, Type = val.ToString() });
        }
    }
}
