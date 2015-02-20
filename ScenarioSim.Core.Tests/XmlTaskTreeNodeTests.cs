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
                    IdealValue = new Vector3f(-4.453103f, 6.926574f, -50.67035f),
                    ActualValue = new ActualValueLocation(1, "Tip Position"),
                    ValueName = "Tool Tip Position"
                });

            selectLongestAxis.AccuracyMetrics.Add(
                new DirectionAccuracyMetric()
                {
                    IdealValue = new Vector3f(0.2162451f, -0.2103498f, 0.9534101f),
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

            Transform head = new Transform(new Vector3f(0, 0, 0), new Vector3f(282.1207f, 0, 0), new Vector3f(2.5f, 2.5f, 2.5f));
            Transform tumour = new Transform(new Vector3f(-0.1f, 2.7f, -31.5f), new Vector3f(-29.6f, -70.2f, -14), new Vector3f(9, 5, 5));
            Transform tool = new Transform(new Vector3f(0, 0.8f, -90.3f), new Vector3f(270, 180, 0), new Vector3f(0.25f, 0.25f, 0.25f));
            Transform camera = new Transform(new Vector3f(0, 76, -158), new Vector3f(31.8875f, 0, 0), new Vector3f(1, 1, 1));

            List<Entity> entities = new List<Entity>();
            entities.Add(new Entity() { Id = 1, Name = "Head", transform = head });
            entities.Add(new Entity() { Id = 2, Name = "Tool", transform = tool });
            entities.Add(new Entity() { Id = 3, Name = "Tumour", transform = tumour });
            entities.Add(new Entity() { Id = 4, Name = "Camera", transform = camera });


            Scenario scenario = new Scenario()
            {
                Name = "Longest Axis 1",
                Task = selectNode,
                TaskTransitions = transitions,
                Entities = entities
            };

            scenario.Complications = new List<Complication>();
            scenario.Complications.Add(new TaskDependantComplication()
                {
                    Id = 1,
                    Name = "Bleed",
                    TaskName = "Rotate Tool",
                    Entry = true
                }
                );

            string scenarioFilename = scenario.Name + ".scenario";
            XmlFileSerializer<Scenario> serializer1 = new XmlFileSerializer<Scenario>();
            serializer1.Serialize(scenarioFilename, scenario);


            Assert.IsTrue(File.Exists(filename));
            Assert.IsTrue(File.Exists(scenarioFilename));

        }

        [Test]
        public void TestSerializeScenario2()
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
                    IdealValue = new Vector3f(14.49247f, -6.106818f, -49.38243f),
                    ActualValue = new ActualValueLocation(1, "Tip Position"),
                    ValueName = "Tool Tip Position"
                });

            selectLongestAxis.AccuracyMetrics.Add(
                new DirectionAccuracyMetric()
                {
                    IdealValue = new Vector3f(-0.3516596f, 0.1926263f, 0.9160953f),
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

            Transform head = new Transform(new Vector3f(0, 0, 0), new Vector3f(282.1207f, 0, 0), new Vector3f(2.5f, 2.5f, 2.5f));
            Transform tumour = new Transform(new Vector3f(6.3f, -1.6f, -28.1f), new Vector3f(329.2404f, 242.2905f, 12.95357f), new Vector3f(7.5f, 5, 5));
            Transform tool = new Transform(new Vector3f(0, 0.8f, -90.3f), new Vector3f(270, 180, 0), new Vector3f(0.25f, 0.25f, 0.25f));
            Transform camera = new Transform(new Vector3f(0, 76, -158), new Vector3f(31.8875f, 0, 0), new Vector3f(1, 1, 1));

            List<Entity> entities = new List<Entity>();
            entities.Add(new Entity() { Id = 1, Name = "Head", transform = head });
            entities.Add(new Entity() { Id = 2, Name = "Tool", transform = tool });
            entities.Add(new Entity() { Id = 3, Name = "Tumour", transform = tumour });
            entities.Add(new Entity() { Id = 4, Name = "Camera", transform = camera });


            Scenario scenario = new Scenario()
            {
                Name = "Longest Axis 2",
                Task = selectNode,
                TaskTransitions = transitions,
                Entities = entities
            };

            scenario.Complications = new List<Complication>();
            scenario.Complications.Add(new TaskDependantComplication()
            {
                Id = 1,
                Name = "Bleed",
                TaskName = "Rotate Tool",
                Entry = true
            }
                );

            string scenarioFilename = scenario.Name + ".scenario";
            XmlFileSerializer<Scenario> serializer1 = new XmlFileSerializer<Scenario>();
            serializer1.Serialize(scenarioFilename, scenario);


            Assert.IsTrue(File.Exists(filename));
            Assert.IsTrue(File.Exists(scenarioFilename));

        }
    }
}
