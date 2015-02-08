namespace ScenarioSim.Creator
{
    partial class HierarchyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HierarchyForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddTask = new System.Windows.Forms.ToolStripButton();
            this.creatorView = new ScenarioSim.Creator.CreatorView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.creatorView);
            this.splitContainer1.Size = new System.Drawing.Size(772, 437);
            this.splitContainer1.SplitterDistance = 59;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddTask});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(59, 64);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddTask
            // 
            this.toolStripButtonAddTask.AutoSize = false;
            this.toolStripButtonAddTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddTask.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddTask.Image")));
            this.toolStripButtonAddTask.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAddTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddTask.Name = "toolStripButtonAddTask";
            this.toolStripButtonAddTask.Size = new System.Drawing.Size(50, 50);
            this.toolStripButtonAddTask.Text = "Task";
            this.toolStripButtonAddTask.Click += new System.EventHandler(this.toolStripButtonAddTask_Click);
            // 
            // creatorView
            // 
            this.creatorView.ArrowMoveLarge = 10F;
            this.creatorView.ArrowMoveSmall = 1F;
            this.creatorView.BackColor = System.Drawing.Color.White;
            this.creatorView.CopiesSubtrees = true;
            this.creatorView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creatorView.Location = new System.Drawing.Point(0, 0);
            this.creatorView.Name = "creatorView";
            this.creatorView.Size = new System.Drawing.Size(709, 437);
            this.creatorView.TabIndex = 0;
            this.creatorView.BackgroundDoubleClicked += new Northwoods.Go.GoInputEventHandler(this.creatorView_DoubleClick);
            // 
            // HierarchyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 437);
            this.Controls.Add(this.splitContainer1);
            this.Name = "HierarchyForm";
            this.Text = "Hierarchy Viewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private CreatorView creatorView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddTask;

    }
}

