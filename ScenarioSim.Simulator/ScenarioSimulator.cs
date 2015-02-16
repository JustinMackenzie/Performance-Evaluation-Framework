using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.UmlStateChart;
using System.IO;
using ScenarioSim.Simulator;

namespace ScenarioSim.Core
{
    public class ScenarioSimulator : IScenarioSimulator
    {
        ISimulatorEventHandler simulatorEventHandler;
        IStateChartEventHandler stateChartEventHandler;
        IStateChartEngine stateChart;
        TrackedEventParameters trackedParameters;
        ParameterKeeper parameterKeeper;
        IComplicationEnactorRepository repo = new ComplicationEnactorRepository();
        TimeKeeper timeKeeper;
        string folderPath;
        Scenario scenario;
        User user;
        bool logging;
        string scenarioFile;

        public bool IsActive { get { return stateChart.IsActive; } }

        public ScenarioSimulator(string scenarioFile, string folderPath, User user, bool logging)
        {
            timeKeeper = new TimeKeeper();
            this.logging = logging;

            IFileSerializer<Scenario> serializer = new XmlFileSerializer<Scenario>();
            scenario = serializer.Deserialize(scenarioFile);
            this.scenarioFile = scenarioFile;

            this.user = user;
            this.folderPath = folderPath + "\\" + string.Format("{0}-{1}-{2}", user.Name, scenario.Name, DateTime.Now.ToString("yyyy-MM-dd-HHmm"));
            Directory.CreateDirectory(this.folderPath);

            ActionFactory actionFactory = new ActionFactory(new TextLogger(this.folderPath + "\\StateChartLog.txt"), timeKeeper,
                new TextLogger(this.folderPath + "\\ComplicationLog.txt"));

            stateChart = new UmlStateChartEngine(scenario, actionFactory, repo);

            List<ISimulatorEventLogger> loggers = new List<ISimulatorEventLogger>();
            loggers.Add(new TextSimulatorEventLogger(this.folderPath + "\\SimulatorEvents.txt"));
            loggers.Add(new CsvSimulatorEventLogger(this.folderPath + "\\SimulatorEvents.csv"));

            List<IStateChartEventLogger> sLoggers = new List<IStateChartEventLogger>();
            sLoggers.Add(new TextStateChartEventLogger(this.folderPath + "\\StateChartEvents.txt"));

            simulatorEventHandler = new SimulatorEventHandler(loggers);
            stateChartEventHandler = new StateChartEventHandler(stateChart, sLoggers);

            parameterKeeper = new ParameterKeeper();
            trackedParameters = new TrackedEventParameters();
        }

        public void Start()
        {
            timeKeeper.StartTimer(scenario.Task.Value.Name);
            stateChart.Start();
        }

        public void SubmitSimulatorEvent(ScenarioEvent e)
        {
            if (!IsActive)
                throw new Exception("Simulator has not been started. Please call Start() before submitting events.");

            simulatorEventHandler.SubmitEvent(e);

            foreach (EventParameter p in e.Parameters)
                if (IsTracked(p, e.Id))
                    parameterKeeper.AddParameter(p, e.Timestamp);

            IStateChartEvent stateChartEvent = TransformSimulatorEvent(e);
            stateChartEventHandler.SubmitEvent(stateChartEvent);

            if (!IsActive)
                Complete();
        }

        public void AddTrackedParameter(int eventId, string parameterName)
        {
            trackedParameters.Items.Add(new EventParameterPair() { EventId = eventId, ParameterName = parameterName });
        }

        public void AddEnactor(IComplicationEnactor enactor)
        {
            repo.AddEnactor(enactor);
        }

        public List<string> ActiveTasks()
        {
            return stateChart.ActiveStates();
        }

        private bool IsTracked(EventParameter parameter, int eventId)
        {
            return (from EventParameterPair p in trackedParameters.Items
                    where p.ParameterName == parameter.Name && p.EventId == eventId
                    select p).Count<EventParameterPair>() > 0;
        }

        private IStateChartEvent TransformSimulatorEvent(ScenarioEvent e)
        {
            return new UmlStateChartEvent() { Id = e.Id, Name = e.Name, Timestamp = DateTime.Now };
        }

        private void Complete()
        {
            timeKeeper.StopAllTimers();
            timeKeeper.LogTimes(folderPath + "\\TaskTimes.csv");
            simulatorEventHandler.Save(folderPath + "\\SimulatorEvents.xml");
            WriteResults();

            if(!logging)
            {
                DirectoryInfo dir = new DirectoryInfo(folderPath);
                dir.Delete(true);
            }
        }

        private void WriteResults()
        {
            SimulationResult result = new SimulationResult();
            result.User = user;
            result.ScenarioFile = scenarioFile;
            result.Events = simulatorEventHandler.Events;
            result.TaskResult = BuildTaskResultTree(scenario.Task);
            IFileSerializer<SimulationResult> serializer = new XmlFileSerializer<SimulationResult>();
            serializer.Serialize(folderPath + "\\SimulationResult.xml", result);

            List<ITaskResultLogger> taskResultLoggers = new List<ITaskResultLogger>();
            taskResultLoggers.Add(new CsvTaskResultLogger());

            LogTaskResult(result.TaskResult, taskResultLoggers);
        }

        private void LogTaskResult(TreeNode<TaskResult> result, List<ITaskResultLogger> loggers)
        {
            foreach (ITaskResultLogger logger in loggers)
                logger.LogTaskResult(result, string.Format("{0}\\{1}", folderPath, result.Value.TaskName));

            foreach(TreeNode<TaskResult> child in result.children)
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
                foreach(AccuracyMetric metric in task.Value.AccuracyMetrics)
                {
                    AccuracyMetricResult metricResult = new AccuracyMetricResult();
                    metricResult.IdealValue = metric.IdealValue;
                    ScenarioEvent e = (from ScenarioEvent ev in simulatorEventHandler.Events
                                       where ev.Id == metric.ActualValue.EventId
                                       select ev).First<ScenarioEvent>();
                    metricResult.ActualValue = (Vector3f)e.Parameters.FindByName(metric.ActualValue.ParameterName).Value;
                    metricResult.Error = metric.CalculateError(metricResult.ActualValue);
                    metricResult.ValueName = metric.ValueName;

                    result.Results.Add(metricResult);
                }
            }

            foreach(TreeNode<Task> childTask in task.children)
                resultTree.AppendChild(BuildTaskResultTree(childTask));

            return resultTree;
        }

        public bool IsTaskActive(string task)
        {
            return stateChart.IsStateActive(task);
        }
    }
}
