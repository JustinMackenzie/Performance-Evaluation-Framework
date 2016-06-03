using System;
using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;

namespace ScenarioSim.Infrastructure.MongoDbRepositories
{
    public class MongoDbScenarioResultRepository : IScenarioResultRepository
    {
        public void Save(ScenarioResult result)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ScenarioResult> GetAllResults()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ScenarioResult> GetAllResultsByScenario(Scenario scenario)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ScenarioResult> GetAllResultsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public ScenarioResult GetResult(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveResult(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateResult(int id, ScenarioResult result)
        {
            throw new NotImplementedException();
        }
    }
}
