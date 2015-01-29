using System;
namespace ScenarioSim.Core
{
    interface IComplicationEnactorRepository
    {
        void AddEnactor(IComplicationEnactor enactor);
        IComplicationEnactor GetEnactor(int id);
        bool Contains(int id);
    }
}
