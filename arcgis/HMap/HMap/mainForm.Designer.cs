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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
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
            this.layManag_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.addLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullExtentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EagleEyeMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EagleEyeMapControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMapControl
            // 
            this.mainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainMapControl.Location = new System.Drawing.Point(298, 61);
            this.mainMapControl.Margin = new System.Windows.Forms.Padding(2);
            this.mainMapControl.Name = "mainMapControl";
            this.mainMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mainMapControl.OcxState")));
            this.mainMapControl.Size = new System.Drawing.Size(638, 619);
            this.mainMapControl.TabIndex = 0;
            this.mainMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.mainMapControl_OnMouseDown);
            this.mainMapControl.OnExtentUpdated += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnExtentUpdatedEventHandler(this.mainMapControl_OnExtentUpdated);
            this.mainMapControl.OnMapReplaced += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMapReplacedEventHandler(this.mainMapControl_OnMapReplaced);
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
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 31);
            this.axToolbarControl1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(936, 28);
            this.axToolbarControl1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_menu,
            this.layManag_menu,
            this.customToolsToolStripMenuItem});
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
            // layManag_menu
            // 
            this.layManag_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addLayerToolStripMenuItem,
            this.addShapefileToolStripMenuItem,
            this.deleteLayerToolStripMenuItem,
            this.clearAllLayersToolStripMenuItem,
            this.moveLayerToolStripMenuItem,
            this.customizesToolStripMenuItem});
            this.layManag_menu.Name = "layManag_menu";
            this.layManag_menu.Size = new System.Drawing.Size(119, 27);
            this.layManag_menu.Text = "Lay Manage";
            // 
            // addLayerToolStripMenuItem
            // 
            this.addLayerToolStripMenuItem.Name = "addLayerToolStripMenuItem";
            this.addLayerToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.addLayerToolStripMenuItem.Text = "Add Layer";
            this.addLayerToolStripMenuItem.Click += new System.EventHandler(this.addLayerToolStripMenuItem_Click);
            // 
            // addShapefileToolStripMenuItem
            // 
            this.addShapefileToolStripMenuItem.Name = "addShapefileToolStripMenuItem";
            this.addShapefileToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.addShapefileToolStripMenuItem.Text = "Add Shapefile";
            this.addShapefileToolStripMenuItem.Click += new System.EventHandler(this.addShapefileToolStripMenuItem_Click);
            // 
            // deleteLayerToolStripMenuItem
            // 
            this.deleteLayerToolStripMenuItem.Name = "deleteLayerToolStripMenuItem";
            this.deleteLayerToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.deleteLayerToolStripMenuItem.Text = "Delete Top Layer";
            this.deleteLayerToolStripMenuItem.Click += new System.EventHandler(this.deleteLayerToolStripMenuItem_Click);
            // 
            // clearAllLayersToolStripMenuItem
            // 
            this.clearAllLayersToolStripMenuItem.Name = "clearAllLayersToolStripMenuItem";
            this.clearAllLayersToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.clearAllLayersToolStripMenuItem.Text = "Clear All Layers";
            this.clearAllLayersToolStripMenuItem.Click += new System.EventHandler(this.clearAllLayersToolStripMenuItem_Click);
            // 
            // moveLayerToolStripMenuItem
            // 
            this.moveLayerToolStripMenuItem.Name = "moveLayerToolStripMenuItem";
            this.moveLayerToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.moveLayerToolStripMenuItem.Text = "Move Last Layer";
            this.moveLayerToolStripMenuItem.Click += new System.EventHandler(this.moveLayerToolStripMenuItem_Click);
            // 
            // customizesToolStripMenuItem
            // 
            this.customizesToolStripMenuItem.Name = "customizesToolStripMenuItem";
            this.customizesToolStripMenuItem.Size = new System.Drawing.Size(225, 28);
            this.customizesToolStripMenuItem.Text = "Customizes";
            this.customizesToolStripMenuItem.Click += new System.EventHandler(this.customizesToolStripMenuItem_Click);
            // 
            // customToolsToolStripMenuItem
            // 
            this.customToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.fullExtentToolStripMenuItem,
            this.boxSelectToolStripMenuItem,
            this.clearSelectionToolStripMenuItem,
            this.openFileDatabaseToolStripMenuItem,
            this.addRasterToolStripMenuItem});
            this.customToolsToolStripMenuItem.Name = "customToolsToolStripMenuItem";
            this.customToolsToolStripMenuItem.Size = new System.Drawing.Size(119, 27);
            this.customToolsToolStripMenuItem.Text = "custom tools";
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.zoomToolStripMenuItem.Text = "Zoom In";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // fullExtentToolStripMenuItem
            // 
            this.fullExtentToolStripMenuItem.Name = "fullExtentToolStripMenuItem";
            this.fullExtentToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.fullExtentToolStripMenuItem.Text = "Full Extent";
            this.fullExtentToolStripMenuItem.Click += new System.EventHandler(this.fullExtentToolStripMenuItem_Click);
            // 
            // boxSelectToolStripMenuItem
            // 
            this.boxSelectToolStripMenuItem.Name = "boxSelectToolStripMenuItem";
            this.boxSelectToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.boxSelectToolStripMenuItem.Text = "Box Select";
            this.boxSelectToolStripMenuItem.Click += new System.EventHandler(this.boxSelectToolStripMenuItem_Click);
            // 
            // clearSelectionToolStripMenuItem
            // 
            this.clearSelectionToolStripMenuItem.Name = "clearSelectionToolStripMenuItem";
            this.clearSelectionToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.clearSelectionToolStripMenuItem.Text = "Clear Selection";
            this.clearSelectionToolStripMenuItem.Click += new System.EventHandler(this.clearSelectionToolStripMenuItem_Click);
            // 
            // openFileDatabaseToolStripMenuItem
            // 
            this.openFileDatabaseToolStripMenuItem.Name = "openFileDatabaseToolStripMenuItem";
            this.openFileDatabaseToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.openFileDatabaseToolStripMenuItem.Text = "Load PersonalDatabase";
            this.openFileDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openFileDatabaseToolStripMenuItem_Click);
            // 
            // addRasterToolStripMenuItem
            // 
            this.addRasterToolStripMenuItem.Name = "addRasterToolStripMenuItem";
            this.addRasterToolStripMenuItem.Size = new System.Drawing.Size(274, 28);
            this.addRasterToolStripMenuItem.Text = "Add Raster";
            this.addRasterToolStripMenuItem.Click += new System.EventHandler(this.addRasterToolStripMenuItem_Click);
            // 
            // EagleEyeMapControl
            // 
            this.EagleEyeMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.EagleEyeMapControl.Location = new System.Drawing.Point(0, 456);
            this.EagleEyeMapControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 1);
            this.EagleEyeMapControl.Name = "EagleEyeMapControl";
            this.EagleEyeMapControl.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("EagleEyeMapControl.OcxState")));
            this.EagleEyeMapControl.Size = new System.Drawing.Size(294, 224);
            this.EagleEyeMapControl.TabIndex = 8;
            this.EagleEyeMapControl.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.EagleEyeMapControl_OnMouseDown);
            this.EagleEyeMapControl.OnMouseUp += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseUpEventHandler(this.EagleEyeMapControl_OnMouseUp);
            this.EagleEyeMapControl.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.EagleEyeMapControl_OnMouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(0, 61);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(294, 390);
            this.axTOCControl1.TabIndex = 9;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(936, 703);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.EagleEyeMapControl);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainMapControl);
            this.Font = new System.Drawing.Font("Ink Free", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map By 何豪";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EagleEyeMapControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public ESRI.ArcGIS.Controls.AxMapControl mainMapControl;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        public ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        public ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem file_menu;
        public System.Windows.Forms.ToolStripMenuItem file_new;
        public System.Windows.Forms.ToolStripMenuItem openDocumentToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveDocumentToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public ESRI.ArcGIS.Controls.AxMapControl EagleEyeMapControl;
        public System.Windows.Forms.ToolStripMenuItem layManag_menu;
        public System.Windows.Forms.ToolStripMenuItem addLayerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem addShapefileToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem deleteLayerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clearAllLayersToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem moveLayerToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem customizesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullExtentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRasterToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

