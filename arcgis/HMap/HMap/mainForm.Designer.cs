namespace HMap
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.file_new = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(281, 60);
            this.mainMapControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(655, 619);
            this.mainMapControl.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 681);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(936, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.axTOCControl1.Location = new System.Drawing.Point(0, 60);
            this.axTOCControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 1);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(277, 619);
            this.axTOCControl1.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(904, 31);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 28);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(2);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(936, 28);
            this.axToolbarControl1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(936, 31);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file_menu
            // 
            this.file_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_new,
            this.openDocumentToolStripMenuItem,
            this.saveDocumentToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.file_menu.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.file_menu.Name = "file_menu";
            this.file_menu.Size = new System.Drawing.Size(50, 27);
            this.file_menu.Text = "File";
            // 
            // file_new
            // 
            this.file_new.Image = ((System.Drawing.Image)(resources.GetObject("file_new.Image")));
            this.file_new.Name = "file_new";
            this.file_new.Size = new System.Drawing.Size(216, 28);
            this.file_new.Text = "New Document...";
            this.file_new.Click += new System.EventHandler(this.file_new_Click);
            // 
            // openDocumentToolStripMenuItem
            // 
            this.openDocumentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openDocumentToolStripMenuItem.Image")));
            this.openDocumentToolStripMenuItem.Name = "openDocumentToolStripMenuItem";
            this.openDocumentToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.openDocumentToolStripMenuItem.Text = "Open Document";
            this.openDocumentToolStripMenuItem.Click += new System.EventHandler(this.openDocumentToolStripMenuItem_Click);
            // 
            // saveDocumentToolStripMenuItem
            // 
            this.saveDocumentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveDocumentToolStripMenuItem.Image")));
            this.saveDocumentToolStripMenuItem.Name = "saveDocumentToolStripMenuItem";
            this.saveDocumentToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.saveDocumentToolStripMenuItem.Text = "Save Document";
            this.saveDocumentToolStripMenuItem.Click += new System.EventHandler(this.saveDocumentToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(213, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(216, 28);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(936, 703);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainMapControl);
            this.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HMap";
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file_menu;
        private System.Windows.Forms.ToolStripMenuItem file_new;
        private System.Windows.Forms.ToolStripMenuItem openDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDocumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

