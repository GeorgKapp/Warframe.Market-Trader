using AutoMapper;


namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class ItemTagMappingProfile : Profile
    {
        public ItemTagMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.ItemTag, Market_Infrastructure.ItemTag>()
                .ForMember(dest => dest.Item, opt => opt.Ignore())
                .ForMember(dest => dest.Tag, opt => opt.Ignore());

            CreateMap<Market_Infrastructure.ItemTag, Market_DomainModels.Models.ItemTag>()
                .IncludeAllDerived()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(source => source.Item))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(source => source.Tag));
        }
    }
}
