using AutoMapper;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class TranslationMappingProfile : Profile
    {
        public TranslationMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.Translation, Market_Infrastructure.Translation>()
                .ReverseMap();
        }
    }
}
