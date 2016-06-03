using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Infrastructure.XmlSerialization;

namespace ScenarioSim.WebApp.Repositories
{
    public class TestScenarioResultRepository : IScenarioResultRepository
    {
        private readonly List<ScenarioResult> results;

        public TestScenarioResultRepository()
        {
            results = new List<ScenarioResult>();

            XmlFileSerializer<ScenarioResult> serializer = new XmlFileSerializer<ScenarioResult>();

            results.Add(serializer.Deserialize("trial-1.result"));
            results.Add(serializer.Deserialize("trial-2.result"));
        }

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
            return results;
        }

        public IEnumerable<ScenarioResult> GetAllResultsByUser(User user)
        {
            return results;
        }

        public ScenarioResult GetResult(int id)
        {
            return results[0];
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