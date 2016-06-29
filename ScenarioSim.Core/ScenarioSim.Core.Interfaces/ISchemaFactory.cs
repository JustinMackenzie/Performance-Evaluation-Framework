using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// A factory interface used to create schema entities.
    /// </summary>
    public interface ISchemaFactory
    {
        /// <summary>
        /// Makes the schema.
        /// </summary>
        /// <returns></returns>
        Schema MakeSchema();
    }
}
