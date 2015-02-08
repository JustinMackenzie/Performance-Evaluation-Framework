using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScenarioSim.Core;

namespace ScenarioSim.Creator
{
    public partial class MainForm : Form
    {
        Scenario scenario;

        public MainForm()
        {
            InitializeComponent();
            scenario = new Scenario();

            Task scenarioTask = new Task()
            {
                Name = "Scenario Task"
            };

            scenario.Task = new TreeNode<Task>(scenarioTask);
        }

        private void toolStripButtonHierarchy_Click(object sender, EventArgs e)
        {
            foreach (Form child in MdiChildren)
            {
                if (child is HierarchyForm)
                {
                    child.BringToFront();
                    return;
                }
            }

            HierarchyForm form = new HierarchyForm(scenario);
            form.MdiParent = this;
            form.Show();
        }
    }
}
