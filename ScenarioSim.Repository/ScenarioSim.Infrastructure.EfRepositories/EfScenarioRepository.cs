using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Mapping;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.Scenario, ScenarioSim.Infrastructure.EfRepositories.EfScenario}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IScenarioRepository" />
    public class EfScenarioRepository : EfMappedEntityRepository<Scenario, EfScenario>, IScenarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfScenarioRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfScenarioRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IEnumerable<Scenario> GetByScenarioIds(IList<Guid> scenarioIds)
        {
            return GetAll()
                .Where(s => scenarioIds.Contains(s.Id))
                .OrderBy(s => scenarioIds.IndexOf(s.Id));
        }
    }
}
