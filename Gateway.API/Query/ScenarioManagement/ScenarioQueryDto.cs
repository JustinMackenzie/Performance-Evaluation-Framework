using System;
using System.Collections.Generic;

namespace Gateway.API.Query.ScenarioManagement
{
    /// <summary>
    /// 
    /// </summary>
    public class ScenarioQueryDto
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
        /// Gets or sets the assets.
        /// </summary>
        /// <value>
        /// The assets.
        /// </value>
        public List<ScenarioAssetDto> Assets { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScenarioQueryDto"/> class.
        /// </summary>
        public ScenarioQueryDto()
        {
            this.Assets = new List<ScenarioAssetDto>();
        }
    }
}