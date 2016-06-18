using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    /// <summary>
    /// An interface used to place entities in the simulator world.
    /// </summary>
    public interface IEntityPlacer
    {
        /// <summary>
        /// Places the given ScenarioObject in the virtual world.
        /// </summary>
        /// <param name="scenarioObject">The ScenarioObject to be placed.</param>
        void Place(ScenarioObject scenarioObject);
    }
}
