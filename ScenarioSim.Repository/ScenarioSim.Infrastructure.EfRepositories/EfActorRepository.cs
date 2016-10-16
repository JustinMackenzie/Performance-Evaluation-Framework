using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.Actor, ScenarioSim.Infrastructure.EfRepositories.EfActor}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IActorRepository" />
    public class EfActorRepository : EfMappedEntityRepository<Actor, EfActor>, IActorRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfActorRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfActorRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
