using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ScenarioSim.Core.Entities
{
    /// <summary>
    /// This class represents a node in N-ary tree structure. It is generic
    /// and can store any type as the data for the node. The node consists of
    /// the data (Generic), the children nodes (Of same type) and the parent node.
    /// </summary>
    /// <typeparam name="T">The type of the value for the node.</typeparam>
    public class TreeNode<T>
    {
        /// <summary>
        /// A list of direct children nodes of this tree node.
        /// </summary>
        public List<TreeNode<T>> children { get; set; }

        /// <summary>
        /// The data being held at this tree node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The parent of this tree node. Note: This field is not serialized
        /// into Xml, because it would cause a loop in the Xml generation.
        /// </summary>
        [XmlIgnore]
        public TreeNode<T> Parent { get; private set; }

        /// <summary>
        /// Default contructor. This constructor is mainly used by the
        /// serializer. It is better to use the constructor that takes 
        /// the data value.
        /// </summary>
        public TreeNode()
        {
            children = new List<TreeNode<T>>();
        }

        /// <summary>
        /// A constructor that takes in the data value to be held by 
        /// this node.
        /// </summary>
        /// <param name="data">The data to be held in this tree node.</param>
        public TreeNode(T data)
        {
            Value = data;
            children = new List<TreeNode<T>>();
        }

        /// <summary>
        /// Creates a tree node with the given data and adds the node to 
        /// the end collection of children nodes.
        /// </summary>
        /// <param name="child">The data of the child node to be created.</param>
        public void AppendChild(T child)
        {
            TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
            children.Add(childNode);
        }

        /// <summary>
        /// Adds the given tree node to the end of the collection of child nodes.
        /// </summary>
        /// <param name="child">The child node to be added.</param>
        public void AppendChild(TreeNode<T> child)
        {
            child.Parent = this;
            children.Add(child);
        }

        /// <summary>
        /// Creates a tree node with the given data and inserts the node into 
        /// the given index of the collection of children nodes.
        /// </summary>
        /// <param name="index">The index of the children where the child will be inserted.</param>
        /// <param name="child">The data of the child node to be created.</param>
        public void InsertChild(int index, T child)
        {
            TreeNode<T> childNode = new TreeNode<T>(child) { Parent = this };
            children.Insert(index, childNode);
        }

        /// <summary>
        /// Inserts the given tree node into the given index of the collection of child nodes.
        /// </summary>
        /// <param name="index">The index of the children where the child will be inserted.</param>
        /// <param name="child">The child tree node.</param>
        public void InsertChild(int index, TreeNode<T> child)
        {
            child.Parent = this;
            children.Insert(index, child);
        }

        /// <summary>
        /// Removes the given tree node from the collection of children.
        /// </summary>
        /// <param name="child">The child node to be removed from its parent.</param>
        public void RemoveChild(TreeNode<T> child)
        {
            children.Remove(child);
        }

        /// <summary>
        /// A pre-order traversal that applies the given action to each child node 
        /// in the tree.
        /// </summary>
        /// <param name="action">The action to be performed on each node during traversal.</param>
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
