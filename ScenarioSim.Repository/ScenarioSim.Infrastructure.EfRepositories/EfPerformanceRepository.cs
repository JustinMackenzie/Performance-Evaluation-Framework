using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfEntityRepository{ScenarioSim.Core.Entities.ScenarioPerformance}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IScenarioPerformanceRepository" />
    public class EfPerformanceRepository : EfEntityRepository<ScenarioPerformance>, IScenarioPerformanceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfPerformanceRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfPerformanceRepository(IDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets the scenario performances by scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        public IEnumerable<ScenarioPerformance> GetByScenario(Scenario scenario)
        {
            return GetAll().Where(p => p.Scenario.Id == scenario.Id);
        }
    }
}
