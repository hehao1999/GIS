using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;

namespace HMap
{
    public partial class export_file : Form
    {
        IActiveView pActiveView = null;
        private string filename;
        public export_file(IHookHelper map_hookHelper)
        {
            InitializeComponent();
            pActiveView = map_hookHelper.ActiveView;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog pSaveFileDialog = new SaveFileDialog
            {
                Title = "请选择保存路径",
                OverwritePrompt = true,
                RestoreDirectory = true,
                Filter = "图像格式（*.emf）|*.emf"
            };

            if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = pSaveFileDialog.FileName;
                return;
            }
            else
            {
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            baseOrder.ExportEMF(filename, pActiveView,Convert.ToInt32(numericUpDown1.Value));
            this.Close();
        }
    }
}
