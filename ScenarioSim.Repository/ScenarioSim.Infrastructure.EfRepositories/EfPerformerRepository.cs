using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.Performer, ScenarioSim.Infrastructure.EfRepositories.EfPerformer}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IPerformerRepository" />
    public class EfPerformerRepository : EfMappedEntityRepository<Performer, EfPerformer>, IPerformerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfPerformerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfPerformerRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
