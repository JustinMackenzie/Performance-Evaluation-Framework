using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Performer}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IPerformerRepository" />
    public class EfPerformerRepository : EfEntityRepository<Performer>, IPerformerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfPerformerRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfPerformerRepository(IDbContext context) : base(context)
        {
        }
    }
}
