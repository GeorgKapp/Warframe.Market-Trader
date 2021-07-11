using AutoMapper;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class SetItemMappingProfile : Profile
    {
        public SetItemMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.SetItem, Market_Infrastructure.SetItem>()
                .ForMember(dest => dest.Item, opt => opt.Ignore())
                .ForMember(dest => dest.Item1, opt => opt.Ignore());

            CreateMap<Market_Infrastructure.SetItem, Market_DomainModels.Models.SetItem>()
                .IncludeAllDerived()
                .ForMember(dest => dest.Child, opt => opt.MapFrom(source => source.Item))
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(source => source.Item1));
        }
    }
}
