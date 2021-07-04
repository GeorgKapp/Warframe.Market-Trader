using AutoMapper;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class LinkedAccountsMappingProfile : Profile
    {
        public LinkedAccountsMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.LinkedAccounts, Market_Infrastructure.LinkedAccounts>();
            CreateMap<Market_Infrastructure.LinkedAccounts, Market_DomainModels.Models.LinkedAccounts>();
        }
    }
}
