namespace HMap
{
    partial class frmAttriQuery
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxLayers = new System.Windows.Forms.ComboBox();
            this.comboBoxFields = new System.Windows.Forms.ComboBox();
            this.txtOperator = new System.Windows.Forms.TextBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxValues = new System.Windows.Forms.ListBox();
            this.btnBuildSQL = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.textBoxSQL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "属性字段：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "操作：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "值：";
            // 
            // comboBoxLayers
            // 
            this.comboBoxLayers.FormattingEnabled = true;
            this.comboBoxLayers.Location = new System.Drawing.Point(115, 12);
            this.comboBoxLayers.Name = "comboBoxLayers";
            this.comboBoxLayers.Size = new System.Drawing.Size(212, 23);
            this.comboBoxLayers.TabIndex = 4;
            this.comboBoxLayers.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLayers_SelectedIndexChanged_1);
            // 
            // comboBoxFields
            // 
            this.comboBoxFields.FormattingEnabled = true;
            this.comboBoxFields.Location = new System.Drawing.Point(115, 71);
            this.comboBoxFields.Name = "comboBoxFields";
            this.comboBoxFields.Size = new System.Drawing.Size(212, 23);
            this.comboBoxFields.TabIndex = 5;
            // 
            // txtOperator
            // 
            this.txtOperator.Location = new System.Drawing.Point(115, 137);
            this.txtOperator.Name = "txtOperator";
            this.txtOperator.Size = new System.Drawing.Size(212, 25);
            this.txtOperator.TabIndex = 6;
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(115, 199);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(212, 25);
            this.textBoxValue.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "获取属性值";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBoxValues
            // 
            this.listBoxValues.FormattingEnabled = true;
            this.listBoxValues.ItemHeight = 15;
            this.listBoxValues.Location = new System.Drawing.Point(115, 251);
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.Size = new System.Drawing.Size(212, 154);
            this.listBoxValues.TabIndex = 9;
            this.listBoxValues.SelectedValueChanged += new System.EventHandler(this.ListBoxValues_SelectedValueChanged);
            // 
            // btnBuildSQL
            // 
            this.btnBuildSQL.Location = new System.Drawing.Point(12, 411);
            this.btnBuildSQL.Name = "btnBuildSQL";
            this.btnBuildSQL.Size = new System.Drawing.Size(121, 35);
            this.btnBuildSQL.TabIndex = 10;
            this.btnBuildSQL.Text = "构建查询条件：";
            this.btnBuildSQL.UseVisualStyleBackColor = true;
            this.btnBuildSQL.Click += new System.EventHandler(this.BtnBuildSQL_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(345, 478);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(82, 41);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.BtnQuery_Click);
            // 
            // textBoxSQL
            // 
            this.textBoxSQL.Location = new System.Drawing.Point(115, 452);
            this.textBoxSQL.Multiline = true;
            this.textBoxSQL.Name = "textBoxSQL";
            this.textBoxSQL.Size = new System.Drawing.Size(212, 67);
            this.textBoxSQL.TabIndex = 13;
            // 
            // frmAttriQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 531);
            this.Controls.Add(this.textBoxSQL);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.btnBuildSQL);
            this.Controls.Add(this.listBoxValues);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.txtOperator);
            this.Controls.Add(this.comboBoxFields);
            this.Controls.Add(this.comboBoxLayers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAttriQuery";
            this.Text = "属性查询";
            this.Load += new System.EventHandler(this.FrmAttriQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxLayers;
        private System.Windows.Forms.ComboBox comboBoxFields;
        private System.Windows.Forms.TextBox txtOperator;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxValues;
        private System.Windows.Forms.Button btnBuildSQL;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox textBoxSQL;
    }
}