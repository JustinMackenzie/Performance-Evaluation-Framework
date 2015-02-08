namespace ScenarioSim.Creator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHierarchy = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHierarchy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(888, 54);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonHierarchy
            // 
            this.toolStripButtonHierarchy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHierarchy.Image")));
            this.toolStripButtonHierarchy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonHierarchy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHierarchy.Name = "toolStripButtonHierarchy";
            this.toolStripButtonHierarchy.Size = new System.Drawing.Size(62, 51);
            this.toolStripButtonHierarchy.Text = "Hierarchy";
            this.toolStripButtonHierarchy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonHierarchy.Click += new System.EventHandler(this.toolStripButtonHierarchy_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 506);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Scenario Creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonHierarchy;
    }
}