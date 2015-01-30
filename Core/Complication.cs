using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScenarioSim.Core
{
    [XmlInclude(typeof(TaskDependantComplication))]
    public abstract class Complication
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
