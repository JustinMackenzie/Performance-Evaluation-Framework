using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioSim.Core
{
    class DistanceKeeper
    {
        Dictionary<string, Vector3f> distances;

        public Dictionary<string, Vector3f> Distances { get { return distances; } }

        public DistanceKeeper()
        {
            distances = new Dictionary<string, Vector3f>();
        }

        public void AddDistance(string task, Vector3f distance)
        {
            distances.Add(task, distance);
        }

        public override string ToString()
        {
            string text = "Accuracy:\n";

            foreach (KeyValuePair<string, Vector3f> p in distances)
            {
                text += p.Key + " : " + p.Value + "\n";
            }

            return text;
        }
    }
}
