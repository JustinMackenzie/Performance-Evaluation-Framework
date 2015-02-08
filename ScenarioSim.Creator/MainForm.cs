using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void toolStripButtonHierarchy_Click(object sender, EventArgs e)
        {
            HierarchyForm form = new HierarchyForm();
            form.MdiParent = this;
            form.Show();
        }
    }
}
