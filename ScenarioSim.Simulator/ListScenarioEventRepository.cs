using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class ListScenarioEventRepository : IScenarioEventRepository
    {
        ScenarioEventCollection collection;

        public ListScenarioEventRepository()
        {
            collection = new ScenarioEventCollection();
        }

        public ScenarioEventCollection Events
        {
            get { return collection; }
        }

        public void Save(ScenarioEvent e)
        {
            collection.Add(e);
        }
    }
}
