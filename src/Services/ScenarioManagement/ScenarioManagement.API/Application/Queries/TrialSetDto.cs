using System;
using System.Collections.Generic;
using ScenarioManagement.Domain;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class TrialSetDto
    {
        /// <summary>
        /// Gets or sets the scenarios.
        /// </summary>
        /// <value>
        /// The scenarios.
        /// </value>
        public IEnumerable<Scenario> Scenarios { get; set; }

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