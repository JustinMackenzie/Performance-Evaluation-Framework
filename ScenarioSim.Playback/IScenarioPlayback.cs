using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScenarioSim.Playback
{
    public interface IScenarioPlayback
    {
        void Play();
        void Pause();
        void Restart();
        void Stop();
        void EnqueueEnactor(IEventEnactor enactor);
    }
}
