using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScenarioSim.Core
{
    public class TimeKeeper
    {
        Dictionary<string, long> _activeTimes;
        Dictionary<string, long> _inactiveTimes;

        public Dictionary<string, long> InactiveTimes { get { return _inactiveTimes; } }

        public TimeKeeper()
        {
            _activeTimes = new Dictionary<string, long>();
            _inactiveTimes = new Dictionary<string, long>();
        }

        public void StartTimer(string state)
        {
            if (!_activeTimes.ContainsKey(state))
                _activeTimes.Add(state, DateTime.Now.Ticks);
        }

        public void StopTimer(string state)
        {
            if (!_activeTimes.ContainsKey(state))
                return;

            long deltaTime = DateTime.Now.Ticks - _activeTimes[state];
            _activeTimes.Remove(state);

            if (_inactiveTimes.ContainsKey(state))
                _inactiveTimes[state] += deltaTime;
            else
                _inactiveTimes.Add(state, deltaTime);
        }

        public void StopAllTimers()
        {
            foreach (string state in _activeTimes.Keys.ToList())
                StopTimer(state);
        }

        public void LogTimes(string filename)
        {
            using (StreamWriter writer = File.AppendText(filename))
            {
                foreach (KeyValuePair<string, long> p in InactiveTimes)
                {
                    writer.WriteLine(string.Format("{0},{1}", p.Key, (1.0 * p.Value / TimeSpan.TicksPerSecond)));
                }
            }
        }

        public override string ToString()
        {
            string text = "Active States: \n";

            foreach (KeyValuePair<string, long> p in _activeTimes)
            {
                text += p.Key + ":" + ((float)(p.Value - DateTime.Now.Ticks)) / 10000000 + " s. \n";
            }

            text += "Inactive States: \n";

            foreach (KeyValuePair<string, long> p in _inactiveTimes)
            {
                text += p.Key + ":" + ((float)p.Value)/10000000 + " s. \n";
            }

            return text;
        }
    }
}
