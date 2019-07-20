namespace HMap
{
    partial class FrmSymbolLibrary
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSymbolLibrary));
            this.ptbPreview = new System.Windows.Forms.PictureBox();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnMoreSymbols = new System.Windows.Forms.Button();
            this.lblAngle = new System.Windows.Forms.Label();
            this.contextMenuStripMoreSymbol = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblOutlineColor = new System.Windows.Forms.Label();
            this.axSymbologyControl1 = new ESRI.ArcGIS.Controls.AxSymbologyControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.G = new System.Windows.Forms.GroupBox();
            this.btnOutlineColor = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.LabelX4 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudAngle = new System.Windows.Forms.NumericUpDown();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).BeginInit();
            this.G.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbPreview
            // 
            this.ptbPreview.BackColor = System.Drawing.Color.White;
            this.ptbPreview.Location = new System.Drawing.Point(11, 20);
            this.ptbPreview.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbPreview.Name = "ptbPreview";
            this.ptbPreview.Size = new System.Drawing.Size(240, 144);
            this.ptbPreview.TabIndex = 5;
            this.ptbPreview.TabStop = false;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(27, 91);
            this.lblWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(47, 15);
            this.lblWidth.TabIndex = 12;
            this.lblWidth.Text = "width";
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(27, 58);
            this.lblSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(39, 15);
            this.lblSize.TabIndex = 12;
            this.lblSize.Text = "size";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "OpenFileDialog1";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(409, 449);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 35);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnMoreSymbols
            // 
            this.btnMoreSymbols.Location = new System.Drawing.Point(409, 404);
            this.btnMoreSymbols.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMoreSymbols.Name = "btnMoreSymbols";
            this.btnMoreSymbols.Size = new System.Drawing.Size(96, 35);
            this.btnMoreSymbols.TabIndex = 19;
            this.btnMoreSymbols.Text = "More Symbols";
            this.btnMoreSymbols.UseVisualStyleBackColor = true;
            this.btnMoreSymbols.Click += new System.EventHandler(this.btnMoreSymbols_Click);
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(27, 135);
            this.lblAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(55, 15);
            this.lblAngle.TabIndex = 12;
            this.lblAngle.Text = "height";
            // 
            // contextMenuStripMoreSymbol
            // 
            this.contextMenuStripMoreSymbol.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripMoreSymbol.Name = "contextMenuStripMoreSymbol";
            this.contextMenuStripMoreSymbol.Size = new System.Drawing.Size(61, 4);
            // 
            // lblOutlineColor
            // 
            this.lblOutlineColor.AutoSize = true;
            this.lblOutlineColor.Location = new System.Drawing.Point(27, 176);
            this.lblOutlineColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutlineColor.Name = "lblOutlineColor";
            this.lblOutlineColor.Size = new System.Drawing.Size(95, 15);
            this.lblOutlineColor.TabIndex = 12;
            this.lblOutlineColor.Text = "outer color";
            // 
            // axSymbologyControl1
            // 
            this.axSymbologyControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSymbologyControl1.Location = new System.Drawing.Point(4, 22);
            this.axSymbologyControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.axSymbologyControl1.Name = "axSymbologyControl1";
            this.axSymbologyControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSymbologyControl1.OcxState")));
            this.axSymbologyControl1.Size = new System.Drawing.Size(337, 482);
            this.axSymbologyControl1.TabIndex = 5;
            this.axSymbologyControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnMouseDownEventHandler(this.axSymbologyControl1_OnMouseDown);
            this.axSymbologyControl1.OnDoubleClick += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnDoubleClickEventHandler(this.axSymbologyControl1_OnDoubleClick);
            this.axSymbologyControl1.OnStyleClassChanged += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnStyleClassChangedEventHandler(this.axSymbologyControl1_OnStyleClassChanged);
            this.axSymbologyControl1.OnItemSelected += new ESRI.ArcGIS.Controls.ISymbologyControlEvents_Ax_OnItemSelectedEventHandler(this.axSymbologyControl1_OnItemSelected);
            // 
            // G
            // 
            this.G.Controls.Add(this.axSymbologyControl1);
            this.G.Location = new System.Drawing.Point(11, -11);
            this.G.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.G.Name = "G";
            this.G.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.G.Size = new System.Drawing.Size(345, 508);
            this.G.TabIndex = 18;
            this.G.TabStop = false;
            // 
            // btnOutlineColor
            // 
            this.btnOutlineColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOutlineColor.Location = new System.Drawing.Point(141, 170);
            this.btnOutlineColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOutlineColor.Name = "btnOutlineColor";
            this.btnOutlineColor.Size = new System.Drawing.Size(103, 28);
            this.btnOutlineColor.TabIndex = 11;
            this.btnOutlineColor.UseVisualStyleBackColor = true;
            this.btnOutlineColor.Click += new System.EventHandler(this.btnOutlineColor_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ptbPreview);
            this.GroupBox1.Location = new System.Drawing.Point(364, 4);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox1.Size = new System.Drawing.Size(264, 174);
            this.GroupBox1.TabIndex = 16;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "preview";
            // 
            // LabelX4
            // 
            this.LabelX4.AutoSize = true;
            this.LabelX4.Location = new System.Drawing.Point(27, 28);
            this.LabelX4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelX4.Name = "LabelX4";
            this.LabelX4.Size = new System.Drawing.Size(47, 15);
            this.LabelX4.TabIndex = 12;
            this.LabelX4.Text = "color";
            // 
            // btnColor
            // 
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(144, 21);
            this.btnColor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(103, 28);
            this.btnColor.TabIndex = 11;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(141, 89);
            this.nudWidth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(107, 25);
            this.nudWidth.TabIndex = 9;
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // nudAngle
            // 
            this.nudAngle.Location = new System.Drawing.Point(141, 124);
            this.nudAngle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudAngle.Name = "nudAngle";
            this.nudAngle.Size = new System.Drawing.Size(107, 25);
            this.nudAngle.TabIndex = 9;
            this.nudAngle.ValueChanged += new System.EventHandler(this.nudAngle_ValueChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.lblOutlineColor);
            this.GroupBox2.Controls.Add(this.lblAngle);
            this.GroupBox2.Controls.Add(this.lblWidth);
            this.GroupBox2.Controls.Add(this.lblSize);
            this.GroupBox2.Controls.Add(this.LabelX4);
            this.GroupBox2.Controls.Add(this.btnOutlineColor);
            this.GroupBox2.Controls.Add(this.btnColor);
            this.GroupBox2.Controls.Add(this.nudWidth);
            this.GroupBox2.Controls.Add(this.nudAngle);
            this.GroupBox2.Controls.Add(this.nudSize);
            this.GroupBox2.Location = new System.Drawing.Point(356, 185);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroupBox2.Size = new System.Drawing.Size(283, 211);
            this.GroupBox2.TabIndex = 17;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "settings";
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(141, 55);
            this.nudSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(107, 25);
            this.nudSize.TabIndex = 9;
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(532, 425);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 35);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "cancle";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSymbolLibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 502);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnMoreSymbols);
            this.Controls.Add(this.G);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmSymbolLibrary";
            this.Text = "Symbol Selection";
            this.Load += new System.EventHandler(this.FrmSymbolLibrary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSymbologyControl1)).EndInit();
            this.G.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAngle)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox ptbPreview;
        internal System.Windows.Forms.Label lblWidth;
        internal System.Windows.Forms.Label lblSize;
        internal System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.Button btnMoreSymbols;
        internal System.Windows.Forms.Label lblAngle;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStripMoreSymbol;
        internal System.Windows.Forms.Label lblOutlineColor;
        internal ESRI.ArcGIS.Controls.AxSymbologyControl axSymbologyControl1;
        internal System.Windows.Forms.ColorDialog colorDialog;
        internal System.Windows.Forms.GroupBox G;
        internal System.Windows.Forms.Button btnOutlineColor;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label LabelX4;
        internal System.Windows.Forms.Button btnColor;
        internal System.Windows.Forms.NumericUpDown nudWidth;
        internal System.Windows.Forms.NumericUpDown nudAngle;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.NumericUpDown nudSize;
        internal System.Windows.Forms.Button btnCancel;
    }
}