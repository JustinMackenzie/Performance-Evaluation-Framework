using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        List<string> ActiveTasks { get; }
        List<AccuracyMetricResult> ActiveResults { get; }

        void Previous();
        void Next();

    }
}
