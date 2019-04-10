namespace HMap
{
    partial class layerManageForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.add_btn = new System.Windows.Forms.Button();
            this.delbtn = new System.Windows.Forms.Button();
            this.upbtn = new System.Windows.Forms.Button();
            this.downbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.okbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(25, 25);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(269, 364);
            this.listBox1.TabIndex = 0;
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(325, 40);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(94, 33);
            this.add_btn.TabIndex = 1;
            this.add_btn.Text = "添加";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(325, 99);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(94, 33);
            this.delbtn.TabIndex = 2;
            this.delbtn.Text = "删除";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // upbtn
            // 
            this.upbtn.Location = new System.Drawing.Point(325, 158);
            this.upbtn.Name = "upbtn";
            this.upbtn.Size = new System.Drawing.Size(94, 33);
            this.upbtn.TabIndex = 3;
            this.upbtn.Text = "上移";
            this.upbtn.UseVisualStyleBackColor = true;
            this.upbtn.Click += new System.EventHandler(this.upbtn_Click);
            // 
            // downbtn
            // 
            this.downbtn.Location = new System.Drawing.Point(325, 218);
            this.downbtn.Name = "downbtn";
            this.downbtn.Size = new System.Drawing.Size(94, 33);
            this.downbtn.TabIndex = 4;
            this.downbtn.Text = "下移";
            this.downbtn.UseVisualStyleBackColor = true;
            this.downbtn.Click += new System.EventHandler(this.downbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(325, 278);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(94, 33);
            this.clearbtn.TabIndex = 5;
            this.clearbtn.Text = "清空";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // okbtn
            // 
            this.okbtn.Location = new System.Drawing.Point(325, 338);
            this.okbtn.Name = "okbtn";
            this.okbtn.Size = new System.Drawing.Size(94, 33);
            this.okbtn.TabIndex = 6;
            this.okbtn.Text = "确定";
            this.okbtn.UseVisualStyleBackColor = true;
            // 
            // layerManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 410);
            this.Controls.Add(this.okbtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.downbtn);
            this.Controls.Add(this.upbtn);
            this.Controls.Add(this.delbtn);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "layerManageForm";
            this.Text = "layerManage";
            this.Load += new System.EventHandler(this.layerManageForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button upbtn;
        private System.Windows.Forms.Button downbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button okbtn;
    }
}