using AutoMapper;
using ScenarioSim.Services.Mapping;
using IMapper = ScenarioSim.Services.Mapping.IMapper;

namespace ScenarioSim.Infrastructure.AutoMapperMapping
{
    /// <summary>
    /// An implementation of the mapping service that uses AutoMapper.
    /// </summary>
    /// <seealso cref="ScenarioSim.Services.Mapping.IMapper" />
    public class AutoMapperMapper : IMapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperMapper"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public AutoMapperMapper(IMappingConfiguration configuration)
        {
            configuration.Initialize();
        }

        /// <summary>
        /// Maps the specified source object to the destination object type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TDestination">The type of the destination object.</typeparam>
        /// <param name="sourceObject">The source object.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            return Mapper.Map<TSource, TDestination>(sourceObject);
        }
    }
}
