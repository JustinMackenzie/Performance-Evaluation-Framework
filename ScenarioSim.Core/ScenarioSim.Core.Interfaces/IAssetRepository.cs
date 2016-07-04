using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    /// <summary>
    /// An interface used to store and retrieve asset entities.
    /// </summary>
    /// <seealso cref="ScenarioSim.Core.Interfaces.IEntityRepository{ScenarioSim.Core.Entities.Asset}" />
    public interface IAssetRepository : IEntityRepository<Asset>
    {
    }
}
