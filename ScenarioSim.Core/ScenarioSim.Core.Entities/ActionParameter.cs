using System.Xml.Serialization;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// Represents a parameter to be included with scenario events.
    /// </summary>
    [XmlInclude(typeof(Vector3f))]
    public class ActionParameter
    {
        /// <summary>
        /// The name of the parameter.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the paramter.
        /// </summary>
        public object Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1}", Name, Value);

        }
    }
}
