using System;
using System.Collections.Generic;

namespace ScenarioSim.Core
{
    public interface IComplicationEnactorRepository
    {
        List<IComplicationEnactor> Enactors { get; }
        void AddEnactor(IComplicationEnactor enactor);
        IComplicationEnactor GetEnactor(int id);
        bool Contains(int id);
    }
}
