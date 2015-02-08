using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Northwoods.Go;
using ScenarioSim.Core;

namespace ScenarioSim.Creator
{
    public partial class HierarchyForm : Form
    {
        ToolType tool;

        public HierarchyForm()
        {
            InitializeComponent();
            tool = ToolType.Task;
            InitializeCreatorView();
        }

        private void InitializeCreatorView()
        {
            // all links go in a layer behind all nodes
            creatorView.Document.LinksLayer = creatorView.Document.Layers.CreateNewLayerBefore(creatorView.Document.DefaultLayer);
            // ensure tree structure
            creatorView.Document.ValidCycle = GoDocumentValidCycle.DestinationTree;
            // enable undo/redo support
            creatorView.Document.UndoManager = new GoUndoManager();
            // use a tree dragging tool instead of the standard one
            creatorView.ReplaceMouseTool(typeof(GoToolDragging), new TreeDraggingTool(creatorView));
            // make sure each newly drawn link has an arrowhead
            creatorView.NewGoLink.ToArrow = true;
        }

        private void toolStripButtonAddTask_Click(object sender, EventArgs e)
        {
            tool = ToolType.Task;
            toolStripButtonAddTask.Checked = true;
        }

        private void creatorView_DoubleClick(object sender, GoInputEventArgs e)
        {
            switch (tool)
            {
                case ToolType.Task:
                    CreateNewTask("Task", e.DocPoint);
                    break;
            }
        }

        private void CreateNewTask(string name, PointF position)
        {
            creatorView.StartTransaction();
            Task task = new Task()
            {
                Name = name
            };
            TreeNode<Task> taskNode = new TreeNode<Task>(task);
            TaskTreeNode node = new TaskTreeNode(taskNode);
            node.Center = position;
            creatorView.Document.Add(node);
            creatorView.FinishTransaction("Added new task.");
        }
    }
}
