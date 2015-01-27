﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using UmlStateChart;
using ScenarioSim.Utility;

namespace ScenarioSim.Core.Test
{
    [TestFixture]
    class SimulatorCommandRecieverTests
    {
        [Test]
        public void TestTextSimulatorEventLogger()
        {
            string filename = "simEventsLog.txt";

            ISimulatorEventLogger logger = new TextSimulatorEventLogger(filename);

            int Id = 0;
            string Name = "Test Command";
            string Description = "A description.";
            DateTime timestamp = DateTime.Now;
            List<EventParameter> parameters = new List<EventParameter>();
            parameters.Add(new EventParameter() { Name = "A parameter", Value = 5 });

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

            TreeNode<Task> selectNode = new TreeNode<Task>(selectLongestAxis);
            selectNode.AppendChild(PositionTool);
            selectNode.AppendChild(ChangeView);
            selectNode.children[0].AppendChild(TranslateTool);
            selectNode.children[0].AppendChild(RotateTool);
            selectNode.children[1].AppendChild(PanCamera);
            selectNode.children[1].AppendChild(LookCamera);
            selectNode.children[1].AppendChild(ZoomCamera);
            selectNode.AppendChild(Selection);

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

            StateChartBuilder builder = new StateChartBuilder();
            StateChart stateChart = builder.Build(selectNode, transitions);

            // Should be 12 states. 9 tasks above + 3 pseudo-start states for each hierarchical task.
            Assert.AreEqual(12, stateChart.States.Count);

        }
    }
}
