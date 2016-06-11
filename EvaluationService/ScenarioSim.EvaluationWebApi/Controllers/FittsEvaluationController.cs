using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.EvaluationWebApi.Controllers
{
    public class FittsEvaluationController : ApiController
    {
        private readonly IFittsEvaluator evaluator;
        private readonly IScenarioRepository scenarioRepository;
        private readonly IUserRepository userRepository;

        public FittsEvaluationController(IFittsEvaluator evaluator, IScenarioRepository scenarioRepository, IUserRepository userRepository)
        {
            this.evaluator = evaluator;
            this.scenarioRepository = scenarioRepository;
            this.userRepository = userRepository;
        }

        [Route("/api/Fitts/EvaluateUser/{userId}/Scenario/{scenarioId}?windowSize={windowSize}")]
        public IEnumerable<FittsEvaluationResult> EvaluateUserHistory(int userId, int scenarioId, int windowSize = 5)
        {
            User user = userRepository.Get(userId);
            Scenario scenario = scenarioRepository.Get(scenarioId);

            return evaluator.EvaluateUserHistory(user, scenario, windowSize);
        }

        [HttpPost]
        public FittsTaskResultEvaluation EvaluateResults(List<FittsTaskResultPair> results)
        {
            return evaluator.EvaluateResults(results);
        } 
    }
}
