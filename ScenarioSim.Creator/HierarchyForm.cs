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
        Scenario scenario;

        public HierarchyForm()
        {
            InitializeComponent();
            tool = ToolType.Task;
            InitializeCreatorView();
            
        }

        public HierarchyForm(Scenario scenario)
            : this()
        {
            this.scenario = scenario;
            InitializeScenario();
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
            creatorView.NewGoLink.Orthogonal = true;
            creatorView.NewGoLink.Style = GoStrokeStyle.RoundedLine;
        }

        private void InitializeScenario()
        {
            creatorView.StartTransaction();
            DrawTask(scenario.Task, new PointF(creatorView.Width * 0.3f, creatorView.Height * 0.5f));
            creatorView.FinishTransaction("Added new task.");
        }

        private TaskTreeNode DrawTask(TreeNode<Task> taskNode, PointF position)
        {
            TaskTreeNode node = new TaskTreeNode(taskNode);
            node.Center = position;
            creatorView.Document.Add(node);

            int count = taskNode.children.Count;
            PointF point = new PointF(position.X + 2 * node.Width, position.Y - (count - 1) * node.Height);

            foreach (TreeNode<Task> child in taskNode.children)
            {
                TaskTreeNode childNode = DrawTask(child, point);
                GoLink link = new GoLink();
                link.FromPort = node.Port;
                link.ToPort = childNode.Port;
                link.ToArrow = true;
                link.Orthogonal = true;
                link.Style = GoStrokeStyle.RoundedLine;
                creatorView.Document.Add(link);
                point.Y += 2 * node.Height;
            }

            return node;
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
