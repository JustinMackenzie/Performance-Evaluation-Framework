using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface used to store and retrieve actor entities.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IEntityRepository{ScenarioSim.Core.Entities.Actor}" />
    public interface IActorRepository : IEntityRepository<Actor>
    {
    }
}
