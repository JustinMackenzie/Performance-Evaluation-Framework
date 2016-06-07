﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using ScenarioSim.Core.Entities;
using ScenarioSim.Infrastructure.SimulationComponents;
using ScenarioSim.Services.Playback;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Playback
{
    public class ScenarioPlayback : IScenarioPlayback
    {
        List<ScenarioEvent> collection;
        Dictionary<int, IEventEnactor> enactors;
        Timer timer;
        DateTime startTime;
        int nextEventIndex;
        ScenarioResult result;
        IScenarioSimulator simulator;
        List<AccuracyMetricResult> activeResults;
        List<KeyValuePair<long, ScenarioEvent>> events;
        private StateChartComponent stateChart;

        public ScenarioPlayback(IScenarioSimulator simulator)
        {
            this.simulator = simulator;
            stateChart = simulator.GetComponent(typeof (StateChartComponent)) as StateChartComponent;
            enactors = new Dictionary<int, IEventEnactor>();
        }

        private void Initialize()
        {
            ShiftEventTimes(collection);
            nextEventIndex = 0;
            simulator.Start(result.Scenario);
            timer = new Timer(1000.0 / 60);
            timer.Elapsed += timer_Elapsed;
        }

        private void ShiftEventTimes(List<ScenarioEvent> collection)
        {
            events = new List<KeyValuePair<long, ScenarioEvent>>();
            long startTime = collection[0].Timestamp.Ticks;

            foreach (ScenarioEvent e in collection)
                events.Add(new KeyValuePair<long, ScenarioEvent>(e.Timestamp.Ticks - startTime, e));
        }

        private void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            long currentTime = e.SignalTime.Ticks - startTime.Ticks;

            lock (events)
            {
                while (nextEventIndex < collection.Count &&
                    events[nextEventIndex].Key < currentTime)
                {
                    ScenarioEvent se = events[nextEventIndex].Value;
                    simulator.SubmitSimulatorEvent(se);
                    if (enactors.ContainsKey(se.Id))
                        enactors[se.Id].Enact(se);
                    nextEventIndex++;
                }
            }
        }

        public void Play(ScenarioResult result)
        {
            this.result = result;
            collection = result.Events;

            Initialize();

            startTime = DateTime.Now;
            timer.Start();
        }

        public void Pause()
        {
            timer.Stop();
        }

        public void Restart()
        {
            timer.Stop();
            nextEventIndex = 0;
            startTime = DateTime.Now;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            nextEventIndex = 0;
        }

        public IEnumerable<string> ActiveTasks
        {
            get
            {
                return stateChart.ActiveTasks();
            }
        }

        public IEnumerable<AccuracyMetricResult> ActiveResults
        {
            get
            {
                activeResults = new List<AccuracyMetricResult>();

                result.TaskResult.Traverse(GenerateActiveResults);

                return activeResults;
            }
        }

        public void GenerateActiveResults(TaskResult taskResult)
        {
            if (ActiveTasks.Contains(taskResult.TaskName))
                activeResults.AddRange(taskResult.Results);
        }

        public void EnqueueEnactor(IEventEnactor enactor)
        {
            enactors.Add(enactor.EventId, enactor);
        }


        public void Previous()
        {
            if (nextEventIndex - 1 < 0)
                return;

            nextEventIndex--;
            ScenarioEvent se = events[nextEventIndex].Value;
            simulator.SubmitSimulatorEvent(se);
            if (enactors.ContainsKey(se.Id))
                enactors[se.Id].Enact(se);
        }

        public void Next()
        {
            if (nextEventIndex + 1 == events.Count)
                return;

            nextEventIndex++;
            ScenarioEvent se = events[nextEventIndex].Value;
            simulator.SubmitSimulatorEvent(se);
            if (enactors.ContainsKey(se.Id))
                enactors[se.Id].Enact(se);
        }

        public int CurrentEventIndex
        {
            get { return nextEventIndex - 1; }
        }
    }
}