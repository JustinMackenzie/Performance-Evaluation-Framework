using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using ScenarioSim.Core;
using NSubstitute;

namespace ScenarioSim.Core.Tests
{
    [TestFixture]
    class XmlTaskTreeNodeTests
    {
        [Test]
        public void TestSerializeTaskTreeNode()
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

            TreeNode<Task> selectNode = new TreeNode<Task>(selectLongestAxis);
            selectNode.AppendChild(PositionTool);
            selectNode.AppendChild(ChangeView);
            selectNode.children[0].AppendChild(TranslateTool);
            selectNode.children[0].AppendChild(RotateTool);
            selectNode.children[1].AppendChild(PanCamera);
            selectNode.children[1].AppendChild(LookCamera);
            selectNode.children[1].AppendChild(ZoomCamera);
            selectNode.AppendChild(Selection);

            string filename = "Task Tree.xml";

            XmlFileSerializer<TreeNode<Task>> serializer = new XmlFileSerializer<TreeNode<Task>>();
            serializer.Serialize(filename, selectNode);

            Assert.IsTrue(File.Exists(filename));
        }

        [Test]
        public void TestSerializeScenario()
        {
            Task selectLongestAxis = new Task() { Name = "Select Longest Axis", EvaluateValue = true };
            Task PositionTool = new Task() { Name = "Position Tool" };
            Task ChangeView = new Task() { Name = "Change View" };
            Task TranslateTool = new Task() { Name = "Translate Tool" };
            Task RotateTool = new Task() { Name = "Rotate Tool" };
            Task MoveCamera = new Task() { Name = "Move Camera" };
            Task ZoomCamera = new Task() { Name = "Zoom Camera" };
            Task Complete = new Task() { Name = "Evaluate", Final = true };

            selectLongestAxis.AccuracyMetrics.Add(
                new PositionAccuracyMetric()
                {
                    IdealValue = new Vector3f(1.389501f, 1.436389f, -9.342558f),
                    ActualValue = new ActualValueLocation(1, "Tip Position"),
                    ValueName = "Tool Tip Position"
                });

            selectLongestAxis.AccuracyMetrics.Add(
                new DirectionAccuracyMetric()
                {
                    IdealValue = new Vector3f(0.1325523f, 0.9609355f, 0.242967f),
                    ActualValue = new ActualValueLocation(1, "Tool Direction"),
                    ValueName = "Tool Direction"
                });

            TreeNode<Task> selectNode = new TreeNode<Task>(selectLongestAxis);
            selectNode.AppendChild(PositionTool);
            selectNode.AppendChild(ChangeView);
            selectNode.children[0].AppendChild(TranslateTool);
            selectNode.children[0].AppendChild(RotateTool);
            selectNode.children[1].AppendChild(MoveCamera);
            selectNode.children[1].AppendChild(ZoomCamera);
            selectNode.AppendChild(Complete);

            string filename = "Task Transitions.xml";

            List<TaskTransition> transitions = new List<TaskTransition>();

            transitions.Add(new TaskTransition() { EventId = 1, Source = "Position Tool", Destination = "Evaluate" });
            transitions.Add(new TaskTransition() { EventId = 1, Source = "Change View", Destination = "Evaluate" });
            transitions.Add(new TaskTransition() { EventId = 2, Source = "Translate Tool", Destination = "Rotate Tool" });
            transitions.Add(new TaskTransition() { EventId = 3, Source = "Move Camera", Destination = "Zoom Camera" });
            transitions.Add(new TaskTransition() { EventId = 4, Source = "Zoom Camera", Destination = "Move Camera" });
            transitions.Add(new TaskTransition() { EventId = 6, Source = "Change View", Destination = "Position Tool" });
            transitions.Add(new TaskTransition() { EventId = 5, Source = "Position Tool", Destination = "Change View" });

            XmlFileSerializer<List<TaskTransition>> serializer = new XmlFileSerializer<List<TaskTransition>>();
            serializer.Serialize(filename, transitions);

            Scenario scenario = new Scenario()
            {
                Task = selectNode,
                TaskTransitions = transitions
            };

            scenario.Complications = new List<Complication>();
            scenario.Complications.Add(new TaskDependantComplication()
                {
                    Id = 1,
                    Name = "Test Complication",
                    TaskName = "Translate Tool",
                    Entry = false
                }
                );

            string scenarioFilename = "Scenario.xml";
            XmlFileSerializer<Scenario> serializer1 = new XmlFileSerializer<Scenario>();
            serializer1.Serialize(scenarioFilename, scenario);


            Assert.IsTrue(File.Exists(filename));
            Assert.IsTrue(File.Exists(scenarioFilename));

        }
    }
}
