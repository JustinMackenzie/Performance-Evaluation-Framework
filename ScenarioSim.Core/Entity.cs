using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    /// <summary>
    /// Represents a phyiscal entity in the scenario.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// The transform of the entity.
        /// </summary>
        public Transform transform { get; set; }

        /// <summary>
        /// The identification number of the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the entity. 
        /// </summary>
        public string Name { get; set; }
    }
}
