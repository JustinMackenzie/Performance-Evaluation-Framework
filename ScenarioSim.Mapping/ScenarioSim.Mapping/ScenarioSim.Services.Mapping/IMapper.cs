namespace ScenarioSim.Services.Mapping
{
    /// <summary>
    /// Maps from one object type to another.
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// Maps the specified source object to the destination object type.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object.</typeparam>
        /// <typeparam name="TDestination">The type of the destination object.</typeparam>
        /// <param name="sourceObject">The source object.</param>
        /// <returns></returns>
        TDestination Map<TSource, TDestination>(TSource sourceObject);
    }
}
