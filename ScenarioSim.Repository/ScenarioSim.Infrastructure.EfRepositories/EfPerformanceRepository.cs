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
    /// <seealso cref="ScenarioSim.Infrastructure.EfRepositories.EfMappedEntityRepository{ScenarioSim.Core.Entities.ScenarioPerformance, ScenarioSim.Infrastructure.EfRepositories.EfPerformance}" />
    /// <seealso cref="ScenarioSim.Core.Interfaces.IScenarioPerformanceRepository" />
    public class EfPerformanceRepository : EfMappedEntityRepository<ScenarioPerformance, EfPerformance>, IScenarioPerformanceRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EfPerformanceRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        public EfPerformanceRepository(IDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        /// <summary>
        /// Gets the scenario performances by scenario.
        /// </summary>
        /// <param name="scenario">The scenario.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ScenarioPerformance> GetByScenario(Scenario scenario)
        {
            return GetAll().Where(p => p.Scenario.Id == scenario.Id);
        }
    }
}
