﻿using System.Collections.Generic;

namespace Simulator.Unity
{
    /// <summary>
    /// 
    /// </summary>
    public class Scenario
    {
        /// <summary>
        /// The assets
        /// </summary>
        public List<Asset> Assets;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Scenario" /> class.
        /// </summary>
        public Scenario()
        {
            this.Assets = new List<Asset>();
        }
    }
}
