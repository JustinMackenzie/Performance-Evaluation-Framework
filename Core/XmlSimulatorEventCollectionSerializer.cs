using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ScenarioSim.Core
{
    public class XmlSimulatorEventCollectionSerializer : ISimulatorEventCollectionSerializer
    {
        public void Serialize(string filename, SimulatorEventCollection collection)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(collection.GetType());
                serializer.Serialize(writer, collection);
            }
        }


        public SimulatorEventCollection Deserialize(string filename)
        {
            using (XmlTextReader reader = new XmlTextReader(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SimulatorEventCollection));
                return serializer.Deserialize(reader) as SimulatorEventCollection;
            }
        }
    }
}
