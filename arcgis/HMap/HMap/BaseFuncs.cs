using ESRI.ArcGIS.Carto;
using System;
using System.Windows.Forms;

namespace HMap
{
    internal class BaseFuncs
    {
        public static void NewMapDoc(Control.ControlCollection controls, ESRI.ArcGIS.Controls.AxMapControl mainMapControl)
        {
            try
            {
                //实例化AxMapControl控件，并加入Form的Controls
                ESRI.ArcGIS.Controls.AxMapControl axMapControl = new ESRI.ArcGIS.Controls.AxMapControl();
                ((System.ComponentModel.ISupportInitialize)(axMapControl)).BeginInit();
                controls.Add(axMapControl);
                ((System.ComponentModel.ISupportInitialize)(axMapControl)).EndInit();

                //实例化SaveFileDialog控件
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                pSaveFileDialog.Title = "输入需要新建地图文档的名称";
                pSaveFileDialog.Filter = "地图文件(*.mxd)|*.mxd";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.RestoreDirectory = true;

                if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                {//保存地图文档
                    string filename = pSaveFileDialog.FileName;
                    IMapDocument pMapDocument = new MapDocumentClass();
                    pMapDocument.New(filename);
                    axMapControl.Map = pMapDocument.get_Map(0);
                    axMapControl.DocumentFilename = pMapDocument.DocumentFilename;
                    pMapDocument.Close();
                    mainMapControl.LoadMxFile(filename);
                    mainMapControl.Refresh();
                    MessageBox.Show("新建地图文档成功!", "信息提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("新建地图文档失败！" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }
    }
}