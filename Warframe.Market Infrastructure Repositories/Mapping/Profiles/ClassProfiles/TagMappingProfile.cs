using AutoMapper;


namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class TagMappingProfile : Profile
    {
        public TagMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.Tag, Market_Infrastructure.Tag>()
                .ReverseMap();
        }
    }
}
