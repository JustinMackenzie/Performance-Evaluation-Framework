using System;
using System.Collections.Generic;

namespace ScenarioManagement.API.Application.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class ProcedureQueryDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the scenarios.
        /// </summary>
        /// <value>
        /// The scenarios.
        /// </value>
        public List<ScenarioDto> Scenarios { get; set; }
    }
}