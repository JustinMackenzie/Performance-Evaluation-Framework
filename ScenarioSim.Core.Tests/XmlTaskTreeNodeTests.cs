﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using ScenarioSim.Utility;
using ScenarioSim.Core;

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
        public void TestSerializeTaskTransitionCollection()
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

            string filename = "Task Transitions.xml";

            TaskTransitionCollection transitions = new TaskTransitionCollection();

            transitions.Add(new TaskTransition() { EventId = 1, Source = "Position Tool", Destination = "Selection" });
            transitions.Add(new TaskTransition() { EventId = 2, Source = "Change View", Destination = "Selection" });
            transitions.Add(new TaskTransition() { EventId = 3, Source = "Translate Tool", Destination = "Rotate Tool" });
            transitions.Add(new TaskTransition() { EventId = 4, Source = "Pan Camera", Destination = "Zoom Camera" });
            transitions.Add(new TaskTransition() { EventId = 5, Source = "Pan Camera", Destination = "Look Camera" });
            transitions.Add(new TaskTransition() { EventId = 6, Source = "Zoom Camera", Destination = "Pan Camera" });
            transitions.Add(new TaskTransition() { EventId = 7, Source = "Zoom Camera", Destination = "Look Camera" });
            transitions.Add(new TaskTransition() { EventId = 8, Source = "Look Camera", Destination = "Pan Camera" });
            transitions.Add(new TaskTransition() { EventId = 9, Source = "Look Camera", Destination = "Zoom Camera" });

            XmlFileSerializer<TaskTransitionCollection> serializer = new XmlFileSerializer<TaskTransitionCollection>();
            serializer.Serialize(filename, transitions);

            Scenario scenario = new Scenario()
            {
                Task = selectNode,
                TaskTransitions = transitions
            };

            string scenarioFilename = "Scenario.xml";
            XmlFileSerializer<Scenario> serializer1 = new XmlFileSerializer<Scenario>();
            serializer1.Serialize(scenarioFilename, scenario);


            Assert.IsTrue(File.Exists(filename));
            Assert.IsTrue(File.Exists(scenarioFilename));

        }
    }
}
