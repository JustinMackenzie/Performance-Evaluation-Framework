using System.Collections.Generic;
using ScenarioSim.Core;

namespace ScenarioSim.Playback
{
    public interface IScenarioPlayback
    {
        int CurrentEventIndex { get; }
        void Play();
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
