using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ScenarioSim.Utility
{
    public class TreeNode<T>
    {
        public List<TreeNode<T>> children { get; set; }

        public T Value { get; set; }

        [XmlIgnore]
        public TreeNode<T> Parent { get; private set; }

        public TreeNode()
        {
            children = new List<TreeNode<T>>();
        }

        public TreeNode(T data)
        {
            Value = data;
            children = new List<TreeNode<T>>();
        }

        public void AppendChild(T child)
        {
            TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
            children.Add(childNode);
        }

        public void InsertChild(int index, T child)
        {
            TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
            children.Insert(index, childNode);
        }

        public void RemoveChild(TreeNode<T> child)
        {
            children.Remove(child);
        }

        public void Traverse(Action<T> action)
        {
            action(Value);

            foreach(TreeNode<T> child in children)
            {
                child.Traverse(action);
            }
        }
    }
}
