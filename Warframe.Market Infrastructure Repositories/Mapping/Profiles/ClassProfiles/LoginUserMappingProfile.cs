using AutoMapper;
using Warframe.Market_DomainModels.Enums;

namespace Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles
{
    public class LoginUserMappingProfile : Profile
    {
        public LoginUserMappingProfile()
        {
            CreateMap<Market_DomainModels.Models.LoginUser, Market_Infrastructure.LoginUser>()
               .ForMember(dest => dest.PlatformID, opt => opt.MapFrom(source => (int)source.Platform))
               .ForMember(dest => dest.RoleID, opt => opt.MapFrom(source => (int)source.Role))
               .ForMember(dest => dest.LinkedAccounts, opt => opt.Ignore())
               .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Market_Infrastructure.LoginUser, Market_DomainModels.Models.LoginUser>()
                .IncludeAllDerived()
                .ForMember(dest => dest.Platform, opt => opt.MapFrom(source => (Platform)source.PlatformID))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(source => (Role)source.RoleID));
        }
    }
}
