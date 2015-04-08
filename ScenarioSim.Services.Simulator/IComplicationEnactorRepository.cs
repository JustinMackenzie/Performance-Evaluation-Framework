using System.Collections.Generic;

namespace ScenarioSim.Services.Simulator
{
    public interface IComplicationEnactorRepository
    {
        IEnumerable<IComplicationEnactor> Enactors { get; }
        void AddEnactor(IComplicationEnactor enactor);
        IComplicationEnactor GetEnactor(int id);
        bool Contains(int id);
    }
}
