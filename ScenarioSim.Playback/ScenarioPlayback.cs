using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScenarioSim.Core;
using System.Timers;

namespace ScenarioSim.Playback
{
    public class ScenarioPlayback : IScenarioPlayback
    {
        IFileSerializer<ScenarioEventCollection> serializer;
        ScenarioEventCollection collection;
        Dictionary<int, IEventEnactor> enactors;
        Timer timer;
        DateTime startTime;
        int nextEventIndex;

        public ScenarioPlayback(string filename)
        {
            serializer = new XmlFileSerializer<ScenarioEventCollection>();
            collection = serializer.Deserialize(filename);
            ShiftEventTimes(collection);
            timer = new Timer(1000.0/60);
            timer.Elapsed += timer_Elapsed;
            nextEventIndex = 0;
            enactors = new Dictionary<int, IEventEnactor>();
        }

        public ScenarioPlayback(ScenarioEventCollection collection)
        {
            this.collection = collection;
            ShiftEventTimes(collection);
            timer = new Timer(1000.0/60);
            timer.Elapsed += timer_Elapsed;
            nextEventIndex = 0;
            enactors = new Dictionary<int, IEventEnactor>();
        }

        private void ShiftEventTimes(ScenarioEventCollection collection)
        {
            long startTime = collection[0].Timestamp.Ticks;

            foreach (ScenarioEvent e in collection)
                e.Timestamp = new DateTime(e.Timestamp.Ticks - startTime);
        }

        private void timer_Elapsed(object source, ElapsedEventArgs e)
        {
            long currentTime = e.SignalTime.Ticks - startTime.Ticks;   
            while (nextEventIndex < collection.Count &&
                collection[nextEventIndex].Timestamp.Ticks < currentTime)
            {
                ScenarioEvent se = collection[nextEventIndex];
                if(enactors.ContainsKey(se.Id))
                    enactors[se.Id].Enact(se);
                nextEventIndex++;
            }
        }

        public void Play()
        {
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

        public void EnqueueEnactor(IEventEnactor enactor)
        {
            enactors.Add(enactor.EventId, enactor);
        }
    }
}
