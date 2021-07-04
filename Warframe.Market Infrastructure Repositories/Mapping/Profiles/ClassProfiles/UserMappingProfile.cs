using AutoMapper;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.User, Market_Infrastructure.User>()
                .ForMember(dest => dest.RegionID, opt => opt.MapFrom(source => (int?)source.Region))
                .ForMember(dest => dest.StatusID, opt => opt.MapFrom(source => (int?)source.Status));

            CreateMap<Market_Infrastructure.User, Market_DomainModels.Models.User>()
                .ForMember(dest => dest.Region, opt => opt.MapFrom(source => (Region?)source.RegionID))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(source => (Region?)source.StatusID));
        }
    }
}
