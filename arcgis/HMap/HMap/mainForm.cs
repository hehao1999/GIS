using ESRI.ArcGIS.Carto;
using System;
using System.Windows.Forms;

namespace HMap
{
    public partial class mainForm : System.Windows.Forms.Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        #region 退出程序

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("真的要退出程序吗", "信息提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("遇到错误，退出程序失败" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 退出程序

        #region 新建地图文档

        private void file_new_Click(object sender, EventArgs e)
        {
            //BaseFuncs.NewMapDoc(this.Controls, mainMapControl);
            try
            {
                
                //实例化SaveFileDialog控件
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                pSaveFileDialog.Title = "输入需要新建地图文档的名称";
                pSaveFileDialog.Filter = "地图文件(*.mxd)|*.mxd";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.RestoreDirectory = true;

                if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                {//保存并打开地图文档
                    string filename = pSaveFileDialog.FileName;
                    IMapDocument pMapDocument = new MapDocumentClass();
                    pMapDocument.New(filename);
                    mainMapControl.LoadMxFile(filename);

                    //将图层名重设为“图层”
                    mainMapControl.Map.Name = "图层";
                    axTOCControl1.SetBuddyControl(mainMapControl);

                    //关闭地图文档，防止发生冲突
                    pMapDocument.Close();
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

        #endregion 新建地图文档

        #region 打开文档

        private void openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //实例化OpenFileDialog控件
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.CheckFileExists = true;
                pOpenFileDialog.RestoreDirectory = true;
                pOpenFileDialog.Title = "打开地图文档";
                pOpenFileDialog.Filter = "ArcMap文档(*.mxd)|*.mxd";

                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = pOpenFileDialog.FileName;
                    if (mainMapControl.CheckMxFile(filename))
                    {//有效地图文档，加载地图
                        mainMapControl.LoadMxFile(filename);
                        return;
                    }
                    else
                    {//地图文档无效
                        MessageBox.Show(filename + "无效的地图文档!", "信息提示", MessageBoxButtons.OK);
                        return;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("打开地图文档失败" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 打开文档

        #region 保存地图文档

        private void saveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = mainMapControl.DocumentFilename;
                IMapDocument pMapDocument = new MapDocumentClass();
                if (filename != null && mainMapControl.CheckMxFile(filename))
                {
                    if (pMapDocument.get_IsReadOnly(filename))
                    {//地图文档只读
                        MessageBox.Show("该地图文档是只读的，无保存权限!", "信息提示", MessageBoxButtons.OK);
                        pMapDocument.Close();
                        return;
                    }
                }
                else
                {//地图文档为空，创建地图文档
                    //实例化SaveFileDialog
                    SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                    pSaveFileDialog.Title = "请选择保存路径";
                    pSaveFileDialog.OverwritePrompt = true;
                    pSaveFileDialog.RestoreDirectory = true;
                    pSaveFileDialog.Filter = "ArcMap文档（*.mxd）|*.mxd";

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

                //统一保存地图文档
                pMapDocument.New(filename);
                pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                pMapDocument.Close();
                MessageBox.Show("保存地图文档成功!", "信息提示", MessageBoxButtons.OK);
            }
            catch (Exception exc)
            {
                MessageBox.Show("地图文档保存失败！" + exc.Message, "信息提示", MessageBoxButtons.OK);
            }
        }

        #endregion 保存地图文档

        #region 另存为

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //实例化SaveFileDialog
                SaveFileDialog pSaveFileDialog = new SaveFileDialog();
                pSaveFileDialog.Filter = "地图文档文件（*.mxd）|*.mxd";
                pSaveFileDialog.Title = "选择保存路径";
                pSaveFileDialog.OverwritePrompt = true;
                pSaveFileDialog.RestoreDirectory = true;

                if (pSaveFileDialog.ShowDialog() == DialogResult.OK)
                {//保存地图文档
                    string filename = pSaveFileDialog.FileName;
                    IMapDocument pMapDocument = new MapDocumentClass();
                    pMapDocument.New(filename);
                    pMapDocument.ReplaceContents(mainMapControl.Map as IMxdContents);
                    pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                    pMapDocument.Close();
                    MessageBox.Show("地图文档另存为成功!", "信息提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("地图文档另存为失败！" + exc.Message, "信息提示", MessageBoxButtons.OK);
            }
        }

        #endregion 另存为
    }
}