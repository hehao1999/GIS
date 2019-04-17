﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HMap
{
    
    public partial class FormMeasureResult : Form
    {
        //声明运行结果关闭事件
        public delegate void FormClosedEventHandler();
        public event FormClosedEventHandler frmClosed = null;

        public FormMeasureResult()
        {
            InitializeComponent();
        }

        private void FormMeasureResult_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frmClosed != null)
            {
                frmClosed();
            }
        }
    }
}
