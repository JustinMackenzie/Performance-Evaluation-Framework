using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Infrastructure.EfRepositories
{
    public class EfPerformer : EfEntity
    {
        /// <summary>
        /// Gets or sets the scenario performances.
        /// </summary>
        /// <value>
        /// The scenario performances.
        /// </value>
        public List<ScenarioPerformance> ScenarioPerformances { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}