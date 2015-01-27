using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ScenarioSim.Utility;
using System.IO;

namespace ScenarioSim.Core
{
    public class XmlTaskTreeNodeSerializer
    {
        public void Serialize(string filename, TreeNode<Task> node)
        {
            using(StreamWriter writer = new StreamWriter(filename))
            {
                XmlSerializer serializer = new XmlSerializer(node.GetType());
                serializer.Serialize(writer, node);
            }
        }

        public TreeNode<Task> Deserialize(string filename)
        {
            using (XmlTextReader reader = new XmlTextReader(filename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TreeNode<Task>));
                return serializer.Deserialize(reader) as TreeNode<Task>;
            }
        }
    }
}
