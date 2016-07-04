using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface used to store and retrieve scenarios.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IEntityRepository{ScenarioSim.Core.Entities.Scenario}" />
    public interface IScenarioRepository : IEntityRepository<Scenario>
    {

    }
}
