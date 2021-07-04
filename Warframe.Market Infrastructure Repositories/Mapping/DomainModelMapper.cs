using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.ClassProfiles;
using Warframe.Market_Infrastructure_Repositories.Mapping.Profiles.EnumProfiles;

namespace Warframe.Market_Infrastructure_Repositories.Mapping
{
    public static class DomainModelMapper
    {
        private static IMapper _mapper;

        static DomainModelMapper()
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

                config.AddProfile<LinkedAccountsMappingProfile>();
                config.AddProfile<UserMappingProfile>();

            }).CreateMapper();
        }

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object. The source
        //     type is inferred from the source object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        // Type parameters:
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        public static TDestination Map<TDestination>(object source)
            => _mapper.Map<TDestination>(source);


        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        // Type parameters:
        //   TSource:
        //     Source type to use, regardless of the runtime type
        //
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        public static TDestination Map<TSource, TDestination>(TSource source)
            => _mapper.Map<TSource, TDestination>(source);


        //
        // Summary:
        //     Execute a mapping from the source object to the existing destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type
        //
        // Returns:
        //     The mapped destination object, same instance as the destination object
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        => _mapper.Map(source, destination);


        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with supplied
        //     mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        public static TDestination Map<TDestination>(object source, Action<IMappingOperationOptions<object, TDestination>> opts) 
            => _mapper.Map(source, opts);
        
        
        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with supplied
        //     mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        public static TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
            => _mapper.Map(source, opts);
        
        
        //
        // Summary:
        //     Execute a mapping from the source object to the existing destination object with
        //     supplied mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type
        //
        // Returns:
        //     The mapped destination object, same instance as the destination object
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
            => _mapper.Map(source, destination, opts);
        
        
        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with explicit
        //     System.Type objects and supplied mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to create
        //
        //   opts:
        //     Mapping options
        //
        // Returns:
        //     Mapped destination object
        public static object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
            => _mapper.Map(source, sourceType, destinationType, opts);
        
        
        //
        // Summary:
        //     Execute a mapping from the source object to existing destination object with
        //     supplied mapping options and explicit System.Type objects
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to use
        //
        //   opts:
        //     Mapping options
        //
        // Returns:
        //     Mapped destination object, same instance as the destination object
        public static object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions<object, object>> opts)
            => _mapper.Map(source, destination, sourceType, destinationType, opts);
    }
}
