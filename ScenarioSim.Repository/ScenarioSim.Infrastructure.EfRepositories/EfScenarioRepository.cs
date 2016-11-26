using System;
using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.Scenario}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IScenarioRepository" />
    public class EfScenarioRepository : EfEntityRepository<Scenario>, IScenarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfScenarioRepository" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfScenarioRepository(IDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the by scenario ids.
        /// </summary>
        /// <param name="scenarioIds">The scenario ids.</param>
        /// <returns></returns>
        public IEnumerable<Scenario> GetByScenarioIds(IList<Guid> scenarioIds)
        {
            return GetAll()
                .Where(s => scenarioIds.Contains(s.Id))
                .OrderBy(s => scenarioIds.IndexOf(s.Id));
        }
    }
}
