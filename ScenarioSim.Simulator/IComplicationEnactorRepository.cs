using System;
namespace ScenarioSim.Core
{
    public interface IComplicationEnactorRepository
    {
        void AddEnactor(IComplicationEnactor enactor);
        IComplicationEnactor GetEnactor(int id);
        bool Contains(int id);
    }
}
