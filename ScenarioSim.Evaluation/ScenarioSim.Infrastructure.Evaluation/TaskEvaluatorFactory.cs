using System;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Evaluation;

namespace ScenarioSim.Infrastructure.Evaluation
{
    public class TaskEvaluatorFactory : ITaskEvaluatorFactory
    {
        public ITaskEvaluator MakeTaskEvaluator(Task task)
        {
            if (task.TaskValues is FittsTaskValues)
                return new FittsTaskEvaluator();
            if (task.TaskValues is SteeringTaskValues)
                return new SteeringTaskEvaluator();
            if (task.TaskValues is ReactionTaskValues)
                return new ReactionTaskEvaluator();

            throw new InvalidOperationException("The given task's type is not supported for evaluation.");
        }
    }
}
