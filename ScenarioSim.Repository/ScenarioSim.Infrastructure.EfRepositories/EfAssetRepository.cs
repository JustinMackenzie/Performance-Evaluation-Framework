using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.Asset, ScenarioSim.Infrastructure.EfRepositories.EfAsset}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IAssetRepository" />
    public class EfAssetRepository : EfMappedEntityRepository<Asset, EfAsset>, IAssetRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfAssetRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfAssetRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
