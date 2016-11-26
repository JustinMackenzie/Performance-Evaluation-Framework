using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Program}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IProgramRepository" />
    public class EfProgramRepository : EfEntityRepository<Program>, IProgramRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfProgramRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfProgramRepository(IDbContext context) : base(context)
        {
        }
    }
}
