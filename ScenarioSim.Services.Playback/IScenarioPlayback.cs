using System.Collections.Generic;
using ScenarioSim.Core.Entities;
using ScenarioSim.Services.Simulator;

namespace ScenarioSim.Services.Playback
{
    public interface IScenarioPlayback
    {
        int CurrentEventIndex { get; }
        void Play(SimulationResult result);
        void Pause();
        void Restart();
        void Stop();
        void EnqueueEnactor(IEventEnactor enactor);
        IEnumerable<string> ActiveTasks { get; }
        IEnumerable<AccuracyMetricResult> ActiveResults { get; }

        void Previous();
        void Next();

    }
}
