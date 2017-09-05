using System;
using System.Collections.Generic;
using Gateway.API.Query.ScenarioManagement;

namespace Gateway.API.Query.TrialSetManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class TrialSetQueryDto
    {
        /// <summary>
        /// Gets or sets the scenarios.
        /// </summary>
        /// <value>
        /// The scenarios.
        /// </value>
        public List<ScenarioQueryDto> Scenarios { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}