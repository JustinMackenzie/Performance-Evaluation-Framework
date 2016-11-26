using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Asset}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IAssetRepository" />
    public class EfAssetRepository : EfEntityRepository<Asset>, IAssetRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfAssetRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfAssetRepository(IDbContext context) : base(context)
        {
        }
    }
}
