using System.Collections.Generic;
using System.Linq;
using ScenarioSim.Core.Entities;
using ScenarioSim.Core.Interfaces;
using ScenarioSim.Infrastructure.XmlSerialization;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Infrastructure.SimulationComponents
{
    //TODO
    public class ResultWritingComponent : ISimulationComponent
    {
        private ITimeKeeper timeKeeper;
        private string folderPath;
        private User user;
        private string scenarioFile;
        private Scenario scenario;
        private ParameterTrackingComponent trackingComponent;
        private ScenarioEventCollectionComponent eventCollectionComponent;


        public ResultWritingComponent(ITimeKeeper timeKeeper, string folderPath, string scenarioFile,
            Scenario scenario, ParameterTrackingComponent trackingComponent, 
            ScenarioEventCollectionComponent eventCollectionComponent)
        {
            this.timeKeeper = timeKeeper;
            this.folderPath = folderPath;
            this.scenarioFile = scenarioFile;
            this.scenario = scenario;
            this.trackingComponent = trackingComponent;
            this.eventCollectionComponent = eventCollectionComponent;
        }

        public void Start(Scenario scenario1)
        {
            
        }

        public void SubmitEvent(ScenarioEvent e)
        {
            
        }

        public void Complete()
        {
            WriteResults();   
        }

        private void WriteResults()
        {
            SimulationResult result = new SimulationResult();
            result.Scenario = scenario;
            result.User = user;
            result.ScenarioFile = scenarioFile;
            result.Events = eventCollectionComponent.Events.ToList();
            result.TaskResult = BuildTaskResultTree(scenario.Task);
            result.TrackedParameters = trackingComponent.TrackedParameters.ToList();
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
                    ScenarioEvent e = (from ScenarioEvent ev in eventCollectionComponent.Events
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
