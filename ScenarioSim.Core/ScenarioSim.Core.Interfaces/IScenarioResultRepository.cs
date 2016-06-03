using System.Collections.Generic;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Core.Interfaces
{
    public interface IScenarioResultRepository
    {
        void Save(ScenarioResult result);

        IEnumerable<ScenarioResult> GetAllResults();
        
        IEnumerable<ScenarioResult> GetAllResultsByScenario(Scenario scenario);

        IEnumerable<ScenarioResult> GetAllResultsByUser(User user);

        ScenarioResult GetResult(int id);

        void RemoveResult(int id);

        void UpdateResult(int id, ScenarioResult result);
    }
}
