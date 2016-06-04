using System.Collections.Generic;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.Repositories
{
    public class InMemoryComplicationEnactorRepository : IComplicationEnactorRepository
    {
        private readonly Dictionary<int, IComplicationEnactor> enactors;

        public InMemoryComplicationEnactorRepository()
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

        public IEnumerable<IComplicationEnactor> Enactors
        {
            get { return enactors.Values; }
        }
    }
}
