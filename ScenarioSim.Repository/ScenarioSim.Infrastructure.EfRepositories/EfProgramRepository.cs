using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.Program, ScenarioSim.Infrastructure.EfRepositories.EfProgram}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IProgramRepository" />
    public class EfProgramRepository : EfMappedEntityRepository<Program, EfProgram>, IProgramRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfProgramRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfProgramRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
