using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    public interface IScenarioResultRepository
    {
        void Save(ScenarioPerformance performance);

        IEnumerable<ScenarioPerformance> GetAllResults();
        
        IEnumerable<ScenarioPerformance> GetAllResultsByScenario(Scenario scenario);

        IEnumerable<ScenarioPerformance> GetAllResultsByUser(User user, Scenario scenario);

        ScenarioPerformance GetResult(int id);

        void RemoveResult(int id);

        void UpdateResult(int id, ScenarioPerformance performance);
    }
}
