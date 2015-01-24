using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ScenarioSim.Core;
using System.IO;
using NSubstitute;
using UmlStateChart;

namespace ScenarioSim.Core.Test
{
    [TestFixture]
    class SimulatorCommandRecieverTests
    {
        [Test]
        public void TestCreateWriteLog()
        {
            int Id = 0;
            string Name = "Test Command";
            string Description = "A description.";
            DateTime timestamp = DateTime.Now;
            Dictionary<string, object> parameters = new Dictionary<string,object>();
            parameters.Add("A parameter", 5);

            IStateChart stateChart = Substitute.For<IStateChart>();


            StateChartEventHandler rec = new StateChartEventHandler(stateChart);

            SimulatorEventHandler reciever = new SimulatorEventHandler(rec);

            for(int i = 0; i < 500; i++)
            {
                reciever.SubmitEvent(new SimulatorEvent() { Id = Id, Name = Name, Description = Description, Timestamp = timestamp, Parameters = parameters });
            }
            
            string filename = "simEvents.log";
            string filename2 = "stateEvents.log";
            reciever.WriteToLog(filename);
            rec.Write(filename2);

            Assert.IsTrue(File.Exists(filename));
        }

        [Test]
        public void TestTextSimulatorEventLogger()
        {
            string filename = "simEventsLog.txt";

            ISimulatorEventLogger logger = new TextSimulatorEventLogger(filename);

            int Id = 0;
            string Name = "Test Command";
            string Description = "A description.";
            DateTime timestamp = DateTime.Now;
            Dictionary<string, object> parameters = new Dictionary<string,object>();
            parameters.Add("A parameter", 5);

            for (int i = 0; i < 60; i++)
            {
                logger.Log(new SimulatorEvent() { Id = Id, Name = Name, Description = Description, Timestamp = timestamp, Parameters = parameters });
            }

            Assert.IsTrue(File.Exists(filename));
        }

        [Test]
        public void TestStateChartBuilder()
        {
            Task selectLongestAxis = new Task() { Name = "Select Longest Axis" };
            Task PositionTool = new Task() { Name = "Position Tool" };
            Task ChangeView = new Task() { Name = "Change View" };
            Task TranslateTool = new Task() { Name = "Translate Tool" };
            Task RotateTool = new Task() { Name = "Rotate Tool" };
            Task PanCamera = new Task() { Name = "Pan Camera" };
            Task LookCamera = new Task() { Name = "Look Camera" };
            Task ZoomCamera = new Task() { Name = "Zoom Camera" };
            Task Selection = new Task() { Name = "Selection" };

            TaskTreeNode selectNode = new TaskTreeNode(selectLongestAxis);
            selectNode.AppendChild(PositionTool);
            selectNode.AppendChild(ChangeView);
            selectNode.children[0].AppendChild(TranslateTool);
            selectNode.children[0].AppendChild(RotateTool);
            selectNode.children[1].AppendChild(PanCamera);
            selectNode.children[1].AppendChild(LookCamera);
            selectNode.children[1].AppendChild(ZoomCamera);
            selectNode.AppendChild(Selection);

            PositionTool.Transition.Add(new TaskTransition() { Id = 1, NextTask = Selection});
            ChangeView.Transition.Add(new TaskTransition() { Id = 2, NextTask = Selection });
            TranslateTool.Transition.Add(new TaskTransition() { Id = 3, NextTask = RotateTool });
            PanCamera.Transition.Add(new TaskTransition() { Id = 4, NextTask = ZoomCamera });
            PanCamera.Transition.Add(new TaskTransition() { Id = 5, NextTask = LookCamera });
            ZoomCamera.Transition.Add(new TaskTransition() { Id = 6, NextTask =  PanCamera});
            ZoomCamera.Transition.Add(new TaskTransition() { Id = 7, NextTask = LookCamera });
            LookCamera.Transition.Add(new TaskTransition() { Id = 8, NextTask = PanCamera });
            LookCamera.Transition.Add(new TaskTransition() { Id = 9, NextTask = ZoomCamera });

            StateChartBuilder builder = new StateChartBuilder();
            StateChart stateChart = builder.Build(selectNode);

            // Should be 12 states. 9 tasks above + 3 pseudo-start states for each hierarchical task.
            Assert.AreEqual(12, stateChart.States.Count);

        }
    }
}
