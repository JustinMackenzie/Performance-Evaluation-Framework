using System.Collections.Generic;
using System.Linq;

namespace ScenarioSim.Core
{
    /// <summary>
    /// Serves as a container for event parameters.
    /// </summary>
    public class EventParameterCollection : List<EventParameter>
    {
        /// <summary>
        /// Returns the parameter from the collection with the given name.
        /// </summary>
        /// <param name="name">The name of the task.</param>
        public EventParameter FindByName(string name)
        {
            IEnumerable<EventParameter> query = from EventParameter param in this
                                                where param.Name == name
                                                select param;
            if (query.Count() == 0)
                return null;
            else
                return query.First();
        }
    }
}
