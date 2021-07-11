using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles;

namespace Warframe.Market_Infrastructure_Repositories.Mapping
{
    public static class ModelMapper
    {
        private static IMapper _mapper;

        static ModelMapper()
        {
            _mapper = new MapperConfiguration(
            config =>
            {
                config.AddExpressionMapping();
                //config.AddProfile<IconFormatMappingProfile>();
                //config.AddProfile<OrderTypeMappingProfile>();
                //config.AddProfile<PlatformMappingProfile>();
                //config.AddProfile<RegionMappingProfile>();
                //config.AddProfile<RoleMappingProfile>();
                //config.AddProfile<StatusMappingProfile>();
                //config.AddProfile<SubTypeMappingProfile>();

                config.AddProfile<LoginUserMappingProfile>();
                config.AddProfile<OrderMappingProfile>();
                config.AddProfile<TagMappingProfile>();
                config.AddProfile<TranslationMappingProfile>();
                config.AddProfile<LinkedAccountsMappingProfile>();
                config.AddProfile<UserMappingProfile>();

            }).CreateMapper();
        }

        public static TDestination Map<TDestination>(object source)
            => _mapper.Map<TDestination>(source);

        public static TDestination Map<TSource, TDestination>(TSource source)
            => _mapper.Map<TSource, TDestination>(source);

        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
            => _mapper.Map(source, destination);
    }
}
