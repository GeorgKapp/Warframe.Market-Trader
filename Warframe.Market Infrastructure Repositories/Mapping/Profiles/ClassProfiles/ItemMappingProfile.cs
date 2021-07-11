using AutoMapper;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.Item, Market_Infrastructure.Item>()
                .ForMember(dest => dest.IconFormatID, opt => opt.MapFrom(source => (int)source.IconFormat));

            CreateMap<Market_Infrastructure.Item, Market_DomainModels.Models.Item>()
                .IncludeAllDerived()
                .ForMember(dest => dest.IconFormat, opt => opt.MapFrom(source => (IconFormat)source.IconFormatID))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(source => source.ItemTag))
                .ForMember(dest => dest.ChildItems, opt => opt.MapFrom(source => source.SetItem))
                .ForMember(dest => dest.ParentItems, opt => opt.MapFrom(source => source.SetItem1));
        }
    }
}
