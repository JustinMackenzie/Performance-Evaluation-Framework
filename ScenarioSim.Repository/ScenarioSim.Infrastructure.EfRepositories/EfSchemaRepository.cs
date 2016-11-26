using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Schema}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.ISchemaRepository" />
    public class EfSchemaRepository : EfEntityRepository<Schema>, ISchemaRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfSchemaRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfSchemaRepository(IDbContext context) : base(context)
        {
        }
    }
}
