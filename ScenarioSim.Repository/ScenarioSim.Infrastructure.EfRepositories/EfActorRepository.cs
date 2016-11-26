using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Actor}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IActorRepository" />
    public class EfActorRepository : EfEntityRepository<
        Actor>, IActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfActorRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfActorRepository(IDbContext context) : base(context)
        {
        }
    }
}
