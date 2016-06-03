using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// An interface used to place entities in the simulator world.
    /// </summary>
    public interface IEntityPlacer
    {
        /// <summary>
        /// Places the given entity in the virtual world.
        /// </summary>
        /// <param name="entity">The entity to be placed.</param>
        void Place(Entity entity);
    }
}
