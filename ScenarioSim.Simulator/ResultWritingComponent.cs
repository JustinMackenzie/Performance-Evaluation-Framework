using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;

namespace ScenarioSim.Simulator
{
    public class ResultWritingComponent : ISimulationComponent
    {
        private TimeKeeperComponent timeKeeper;
        private string folderPath;
        private ParameterTrackingComponent paramterTracker;


        public ResultWritingComponent(TimeKeeperComponent timeKeeper, ParameterTrackingComponent paramterTracker, string folderPath)
        {
            this.timeKeeper = timeKeeper;
            this.folderPath = folderPath;
            this.paramterTracker = paramterTracker;

        }

        public void Start()
        {
            
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            
        }

        public void Complete()
        {
            
        }

        private void WriteResults()
        {
            SimulationResult result = new SimulationResult();
            result.User = user;
            result.ScenarioFile = scenarioFile;
            result.Events = scenarioEventRepository.Events;
            result.TaskResult = BuildTaskResultTree(scenario.Task);
            result.TrackedParameters = parameterKeeper;
            IFileSerializer<SimulationResult> serializer = new XmlFileSerializer<SimulationResult>();
            serializer.Serialize(folderPath + "\\SimulationResult.xml", result);

            List<ITaskResultLogger> taskResultLoggers = new List<ITaskResultLogger>();
            taskResultLoggers.Add(new CsvTaskResultLogger());

            LogTaskResult(result.TaskResult, taskResultLoggers);

            Result = result;
        }

        public SimulationResult Result { get; private set; }

        private void LogTaskResult(TreeNode<TaskResult> result, List<ITaskResultLogger> loggers)
        {
            foreach (ITaskResultLogger logger in loggers)
                logger.LogTaskResult(result, string.Format("{0}\\{1}", folderPath, result.Value.TaskName));

            foreach (TreeNode<TaskResult> child in result.children)
                LogTaskResult(child, loggers);
        }

        private TreeNode<TaskResult> BuildTaskResultTree(TreeNode<Task> task)
        {
            TaskResult result = new TaskResult();
            TreeNode<TaskResult> resultTree = new TreeNode<TaskResult>(result);

            result.TaskName = task.Value.Name;
            result.Speed = timeKeeper.TaskTimes.ContainsKey(result.TaskName) ?
                timeKeeper.TaskTimes[result.TaskName] :
                0;

            if (task.Value.EvaluateValue)
            {
                foreach (AccuracyMetric metric in task.Value.AccuracyMetrics)
                {
                    AccuracyMetricResult metricResult = new AccuracyMetricResult();
                    metricResult.IdealValue = metric.IdealValue;
                    ScenarioEvent e = (from ScenarioEvent ev in scenarioEventRepository.Events
                                       where ev.Id == metric.ActualValue.EventId
                                       select ev).First<ScenarioEvent>();
                    metricResult.ActualValue = (Vector3f)e.Parameters.FindByName(metric.ActualValue.ParameterName).Value;
                    metricResult.Error = metric.CalculateError(metricResult.ActualValue);
                    metricResult.ValueName = metric.ValueName;

                    result.Results.Add(metricResult);
                }
            }

            foreach (TreeNode<Task> childTask in task.children)
                resultTree.AppendChild(BuildTaskResultTree(childTask));

            return resultTree;
        }
    }
}
