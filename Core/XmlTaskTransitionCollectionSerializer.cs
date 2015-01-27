using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ScenarioSim.Core
{
    public class XmlTaskTransitionCollectionSerializer
    {
        public void Serialize(string filename, TaskTransitionCollection collection)
        {
            using(StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(collection.GetType());
                serializer.Serialize(writer, collection);
            }
        }

        public TaskTransitionCollection Deserialize(string filename)
        {
            using(XmlTextReader reader = new XmlTextReader(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TaskTransitionCollection));
                return serializer.Deserialize(reader) as TaskTransitionCollection;
            }
        }
    }
}
