using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go;

namespace ScenarioSim.Creator
{
    public partial class Form1 : Form
    {
        ToolType tool;

        public Form1()
        {
            InitializeComponent();

            tool = ToolType.Task;
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
            TaskTreeNode node = new TaskTreeNode();
            node.Text = name;
            node.Center = position;
            creatorView.Document.Add(node);
            creatorView.FinishTransaction("Added new task.");
        }
    }
}
