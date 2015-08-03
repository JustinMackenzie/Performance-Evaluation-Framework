using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Services.Evaluation
{
    public interface IEvaluator
    {
        void Evaluate(SimulationResult result);

        void EvaluateUser(User user, Scenario scenario);
    }
}
