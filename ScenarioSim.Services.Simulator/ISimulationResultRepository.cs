using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core.Entities;

namespace ScenarioSim.Services.Simulator
{
    public interface ISimulationResultRepository
    {
        void Save(SimulationResult result);

        IEnumerable<SimulationResult> GetAllResults(Scenario scenario);
    }
}
