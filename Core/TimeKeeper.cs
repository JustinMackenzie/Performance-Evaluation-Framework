using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    public class TimeKeeper : IUpdatable
    {
        Dictionary<string, float> _activeTimes;
        Dictionary<string, float> _inactiveTimes;

        public Dictionary<string, float> InactiveTimes { get { return _inactiveTimes; } }

        public TimeKeeper()
        {
            _activeTimes = new Dictionary<string, float>();
            _inactiveTimes = new Dictionary<string, float>();
        }

        public void Update(float deltaTime)
        {
            foreach (string key in _activeTimes.Keys.ToList())
                _activeTimes[key] += deltaTime;
        }

        public void StartTimer(string state)
        {
            if (!_activeTimes.ContainsKey(state))
                _activeTimes.Add(state, 0);
        }

        public void StopTimer(string state)
        {
            if (_inactiveTimes.ContainsKey(state))
            {
                _inactiveTimes[state] += _activeTimes[state];
            }
            else
            {
                _inactiveTimes.Add(state, _activeTimes[state]);
            }

            _activeTimes.Remove(state);
        }

        public override string ToString()
        {
            string text = "Active States: \n";

            foreach (KeyValuePair<string, float> p in _activeTimes)
            {
                text += p.Key + ":" + p.Value + " s. \n";
            }

            text += "Inactive States: \n";

            foreach (KeyValuePair<string, float> p in _inactiveTimes)
            {
                text += p.Key + ":" + p.Value + " s. \n";
            }

            return text;
        }
    }
}
