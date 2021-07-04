using AutoMapper;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.User, Market_Infrastructure.User>();
            CreateMap<Market_Infrastructure.User, Market_DomainModels.Models.User>();
        }
    }
}
