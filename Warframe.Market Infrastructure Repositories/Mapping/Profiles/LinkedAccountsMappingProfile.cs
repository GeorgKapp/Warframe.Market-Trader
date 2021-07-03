using AutoMapper;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles
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
