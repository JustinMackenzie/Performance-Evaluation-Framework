using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;
using System.IO;
using ScenarioSim.UmlStateChart;

namespace ScenarioSim.Simulator
{
    public class LoggingScenarioSimulator : ScenarioSimulator
    {
        TimeKeeper timeKeeper;
        string folderPath;
        User user;
        string scenarioFile;
        ParameterKeeper parameterKeeper;
        TrackedEventParameters trackedParameters;
        IScenarioEventRepository scenarioEventRepository;
        List<ISimulatorEventLogger> loggers;

        public LoggingScenarioSimulator(string scenarioFile, IEntityPlacer placer, string folderPath, User user)
            : base(scenarioFile, placer)
        {
            this.user = user;
            this.scenarioFile = scenarioFile;
            timeKeeper = new TimeKeeper();
            this.folderPath = folderPath + "\\" + string.Format("{0}-{1}-{2}", user.Name, scenario.Name, DateTime.Now.ToString("yyyy-MM-dd-HHmm"));
            Directory.CreateDirectory(this.folderPath);

            loggers = new List<ISimulatorEventLogger>();
            loggers.Add(new TextSimulatorEventLogger(this.folderPath + "\\SimulatorEvents.txt"));
            loggers.Add(new CsvSimulatorEventLogger(this.folderPath + "\\SimulatorEvents.csv"));

            parameterKeeper = new ParameterKeeper();
            trackedParameters = new TrackedEventParameters();
            scenarioEventRepository = new ListScenarioEventRepository();
        }

        public override void Start()
        {
            ActionFactory actionFactory = new ActionFactory(new TextLogger(this.folderPath + "\\StateChartLog.txt"), 
                timeKeeper, new TextLogger(this.folderPath + "\\ComplicationLog.txt"));

            IStateChartBuilder builder = new LoggingUmlStateChartBuilder(actionFactory, repo);
            stateChart = builder.Build(scenario);

            timeKeeper.StartTimer(scenario.Task.Value.Name);
            stateChart.Start();
        }

        public override void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!IsActive)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            scenarioEventRepository.Save(e);

            foreach (ISimulatorEventLogger logger in loggers)
                logger.Log(e);
            
            stateChart.Dispatch(TransformSimulatorEvent(e));

            foreach (EventParameter p in e.Parameters)
                if (IsTracked(p, e.Id))
                    parameterKeeper.AddParameter(p, e.Timestamp);
            if (!IsActive)
                Complete();
        }

        public void AddTrackedParameter(EventParameterPair pair)
        {
            trackedParameters.Items.Add(pair);
        }

        private bool IsTracked(EventParameter parameter, int eventId)
        {
            return (from EventParameterPair p in trackedParameters.Items
                    where p.ParameterName == parameter.Name && p.EventId == eventId
                    select p).Count<EventParameterPair>() > 0;
        }

        protected override void Complete()
        {
            base.Complete();

            timeKeeper.StopAllTimers();
            timeKeeper.LogTimes(folderPath + "\\TaskTimes.csv");
            WriteResults();
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
            result.Speed = timeKeeper.InactiveTimes.ContainsKey(result.TaskName) ?
                timeKeeper.InactiveTimes[result.TaskName] :
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
