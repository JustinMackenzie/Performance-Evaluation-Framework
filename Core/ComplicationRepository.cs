using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class ComplicationEnactorRepository : IComplicationEnactorRepository
    {
        Dictionary<int, IComplicationEnactor> enactors;

        public ComplicationEnactorRepository()
        {
            enactors = new Dictionary<int, IComplicationEnactor>();
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            enactors.Add(enactor.ComplicationId, enactor);
        }

        public IComplicationEnactor GetEnactor(int id)
        {
            return enactors[id];
        }

        public bool Contains(int id)
        {
            return enactors.ContainsKey(id);
        }
    }
}
