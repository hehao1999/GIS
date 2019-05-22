using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
//using ESRI.ArcGIS.SpatialAnalyst;
//using ESRI.ArcGIS.GeoAnalyst;
using System.Collections;
using ESRI.ArcGIS.DataSourcesRaster;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Geometry;
using System.IO;
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;
namespace HMap
{
    public partial class FrmRasterCalculatornew : Form
    {

        mainForm _frmMain;

        #region 控制只打开一个界面
        public static FrmRasterCalculatornew TmpFrmRasterCalculatornew = null;
        #endregion

        public FrmRasterCalculatornew()
        {
            InitializeComponent();
        }

        public FrmRasterCalculatornew(mainForm TmpFrom, IMap TmpMap)
        {
            InitializeComponent();
            _frmMain = TmpFrom;
            this.Map = TmpMap;
        }

        #region "变量、过程或函数"
        //获取当前的地图
        IMap pCurMap;
        IMapAlgebraOp pMapAlgebraOp;
        ArrayList LayerList = new ArrayList();
        ArrayList RasterList = new ArrayList();
        //栅格运算结果保存的路径名及文件名
        string sOutRasPath;

        string sOutRasName;
        public IMap Map
        {
            get { return pCurMap; }
            set { pCurMap = value; }
        }

        /// <summary>
        /// 使mapcontrolMain中的部分图层添加到listBox中
        /// </summary>
        /// <param name="bLayer"></param>
        /// <remarks></remarks>
        private void PopulateListBoxWithMapLayers(bool bLayer)
        {
            int i = 0;
            ILayer pLayer = default(ILayer);
            listBoxLayer.Items.Clear();
            for (i = 0; i <= pCurMap.LayerCount - 1; i++)
            {
                //获取图层名字，并且加到listbox中
                pLayer = pCurMap.get_Layer(i);
                if (pLayer.Valid == true)
                {
                    if (bLayer == true)
                    {
                        if (pLayer is IRasterLayer)
                        {
                            listBoxLayer.Items.Add(pLayer.Name);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取指定图层的范围大小
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private IEnvelope GetLayerExtend(string sLayerName)
        {
            ILayer pLayer = default(ILayer);
            IEnvelope pEnvelope = default(IEnvelope);
            int i = 0;
            pEnvelope = new Envelope() as IEnvelope;
            for (i = 0; i <= pCurMap.LayerCount - 1; i++)
            {
                pLayer = pCurMap.get_Layer(i);
                if (pLayer.Name == sLayerName.ToString())
                {
                    if (pLayer.Valid == true)
                    {
                        //获取分析范围的Envelope对象
                        pEnvelope = pLayer.AreaOfInterest;

                    }
                }
            }
            return pEnvelope;

        }


        /// <summary>
        /// 该函数获得栅格影像分辨率大小
        /// </summary>
        /// <param name="sLayerName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private double GetRasterCellSize(string sLayerName)
        {
            double dCellSize = 0;
            int i = 0;
            ILayer pLyr = default(ILayer);
            IRasterLayer pRlyr = default(IRasterLayer);
            IRaster pRaster = default(IRaster);
            IRasterProps pRasterProp = default(IRasterProps);
            double cellX;
            double cellY;
            for (i = 0; i <= pCurMap.LayerCount - 1; i++)
            {
                pLyr = pCurMap.get_Layer(i);
                if ((pLyr != null))
                {
                    if (pLyr is IRasterLayer)
                    {
                        if (pLyr.Name == sLayerName)
                        {
                            pRlyr = (IRasterLayer)pLyr;
                            pRaster = pRlyr.Raster;
                            pRasterProp = (IRasterProps)pRaster;
                            cellX = pRasterProp.MeanCellSize().X;
                            cellY =  pRasterProp.MeanCellSize().Y;

                            dCellSize = (cellX + cellY) / 2.0;
                        }
                    }
                }
            }
            return dCellSize;
        }
        /// <summary>
        /// 通过名称在MAP中找到图层
        /// </summary>
        /// <param name="pMap"></param>
        /// <param name="sName"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private ILayer FindLayerByName(IMap pMap, string sName)
        {
            int i = 0;
            ILayer pSelectedLayer = null;
            for (i = 0; i <= pMap.LayerCount - 1; i++)
            {
                if (pMap.get_Layer(i).Name == sName)
                {
                    pSelectedLayer = pMap.get_Layer(i);
                    break; // TODO: might not be correct. Was : Exit For
                }
            }
            return pSelectedLayer;
        }
        #endregion

        private void FrmRasterCalculatornew_Load(object sender, EventArgs e)
        {
            PopulateListBoxWithMapLayers(true);
        }

        #region "计算器面板的各种操作"
        private void btnMultiply_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "*" + " ";
        }

        private void btnDiv_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "/" + " ";
        }

        private void btnMinus_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "-" + " ";
        }

        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "+" + " ";
        }

        private void btn0_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "0";
        }

        private void btnDot_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = ".";
        }

        private void btn1_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "1";
        }

        private void btn2_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "2";
        }

        private void btn3_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "3";
        }

        private void btn4_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "4";
        }

        private void btn5_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "5";
        }

        private void btn6_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "6";
        }

        private void btn7_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "7";
        }

        private void btn8_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "8";
        }

        private void btn9_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "9";
        }

        private void btnLeftBracket_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "(";
        }

        private void btnRightBracket_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = ")";
        }

        private void btnSmaller_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "<" + " ";
        }

        private void btnSmallEqual_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "<=" + " ";
        }

        private void btnGreater_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + ">" + " ";
        }

        private void btnGreatEqual_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + ">=" + " ";
        }

        private void btnEqual_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "=" + " ";
        }

        private void btnNotEqual_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "<>" + " ";
        }

        private void btnAnd_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "&" + " ";
        }

        private void btnOr_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "|" + " ";
        }

        private void btnXor_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "^" + " ";
        }

        private void btnNot_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "!" + " ";
        }
        private void btnSin_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Sin()" + " ";
        }

        private void btnASin_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "ASin()" + " ";
        }

        private void btnCos_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Cos()" + " ";
        }

        private void btnACos_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Tan()" + " ";
        }

        private void btnTan_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Tan()" + " ";
        }

        private void btnATan_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "ATan()" + " ";
        }

        private void btnExp_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Exp()" + " ";
        }

        private void btnLog_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Ln()" + " ";
        }

        private void btnExp2_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Exp2()" + " ";
        }

        private void btnLog2_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Log2()" + " ";
        }

        private void btnExp10_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Exp10()" + " ";
        }

        private void btnLog10_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Log10()" + " ";
        }

        private void btnSqrt_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Sqrt()" + " ";
        }

        private void btnSqr_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Sqr()" + " ";
        }

        private void btnPow_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = " " + "Pow(, 2)" + " ";
        }
        #endregion

        #region "栅格运算"
        /// <summary>
        /// 在listBox中选择某一个数据名称，双击，该数据名称添加到计算器文本框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void listBoxLayer_DoubleClick(object sender, System.EventArgs e)
        {
            txtCalculate.SelectedText = "[" + listBoxLayer.SelectedItem.ToString() + "]";
            string tmpstr = listBoxLayer.SelectedItem.ToString();
            bool blnItm = false;
            int i;
            for (i = 0; i < LayerList.Count; i++)
            {
                if (LayerList[i].ToString() == tmpstr)
                {
                    blnItm = true;
                }
            }
            if (blnItm == false)
            {
                LayerList.Add(listBoxLayer.SelectedItem.ToString());
            }
           
            for (i = 0; i < LayerList.Count; i ++ )
            {
                MessageBox.Show(LayerList[i].ToString());
            }
        }

        /// <summary>
        /// 清空计算器文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            txtCalculate.Text = "";

        }

        /// <summary>
        /// 退出栅格运算器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// 执行地图代数运算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>

        private void btnCalculate_Click(System.Object sender, System.EventArgs e)
        {
            IRasterLayer pRasLayer = default(IRasterLayer);
            IRaster pRaster = default(IRaster);

            IEnvelope layExtend = default(IEnvelope);
            double AnalysisExtentLeft = 0;
            double AnalysisExtentRight = 0;
            double AnalysisExtentTop = 0;
            double AnalysisExtentBottom = 0;

            string layerNameFir = null;

            try
            {
                if (LayerList.Count != 0)
                {
                    if (txtResultFullName.Text.ToString().Length != 0)
                    {
                        layerNameFir = LayerList[0].ToString();

                        layExtend = GetLayerExtend(layerNameFir);
                        AnalysisExtentLeft = layExtend.XMin;
                        AnalysisExtentRight = layExtend.XMax;
                        AnalysisExtentTop = layExtend.YMax;
                        AnalysisExtentBottom = layExtend.YMin;

                        pMapAlgebraOp = new RasterMapAlgebraOp() as IMapAlgebraOp;
                        //设置栅格计算分析环境
                        IRasterAnalysisEnvironment pRasAnaEnv = default(IRasterAnalysisEnvironment);
                        pRasAnaEnv = (IRasterAnalysisEnvironment)pMapAlgebraOp;
                        pRasAnaEnv.VerifyType = esriRasterVerifyEnum.esriRasterVerifyOn;

                        object dddd;
                        dddd = GetRasterCellSize(layerNameFir);
                        pRasAnaEnv.SetCellSize(esriRasterEnvSettingEnum.esriRasterEnvValue, ref dddd);
                        //设置分析范围pAnaExtent
                        IEnvelope pAnaExtent = default(IEnvelope);
                        pAnaExtent = new Envelope() as IEnvelope;

                        pAnaExtent.XMin = Convert.ToDouble(AnalysisExtentLeft);
                        pAnaExtent.XMax = Convert.ToDouble(AnalysisExtentRight);
                        pAnaExtent.YMax = Convert.ToDouble(AnalysisExtentTop);
                        pAnaExtent.YMin = Convert.ToDouble(AnalysisExtentBottom);

                        object dd1 = pAnaExtent;
                        object dd2 = null;


                        pRasAnaEnv.SetExtent(esriRasterEnvSettingEnum.esriRasterEnvValue, ref dd1, ref dd2);

                        foreach (string LayerName in LayerList)
                        {
                            pRasLayer =(IRasterLayer) FindLayerByName(pCurMap, LayerName);
                            //MsgBox(LayerName)
                            pRaster = pRasLayer.Raster;
                            RasterList.Add(pRaster);
                        }
                        //将容量设置为 ArrayList 中元素的实际数目
                        LayerList.TrimToSize();
                        RasterList.TrimToSize();

                        //绑定
                        int i = 0;
                        if (LayerList.Count == RasterList.Count)
                        {
                            for (i = 0; i <= LayerList.Count - 1; i++)
                            {
                                pMapAlgebraOp.BindRaster((IGeoDataset)RasterList[i], LayerList[i].ToString());
                            }
                        }


                        //获取文本框中的运算表达式()
                        string sCalExpression = null;
                        sCalExpression = txtCalculate.Text;
                        //执行地图代数运算
                        IRaster pOutRasterDS = default(IRaster);
                        pOutRasterDS = (IRaster)pMapAlgebraOp.Execute(sCalExpression);

                        //解除绑定
                        if (LayerList.Count == RasterList.Count)
                        {
                            for (i = 0; i <= LayerList.Count - 1; i++)
                            {
                                pMapAlgebraOp.UnbindRaster(LayerList[i].ToString());
                            }
                        }


                        //保存到工作空间
                        IWorkspaceFactory pWsFact = default(IWorkspaceFactory);
                        IWorkspace pWS = default(IWorkspace);
                        int hwnd = 0;
                        pWsFact = new RasterWorkspaceFactory();
                        pWS = pWsFact.OpenFromFile(sOutRasPath, hwnd);
                        IRasterBandCollection pRasterbandCollection = default(IRasterBandCollection);

                        pRasterbandCollection = (IRasterBandCollection)pOutRasterDS;
                        IDataset pDataset = default(IDataset);

                        pDataset = pRasterbandCollection.SaveAs(sOutRasName, pWS, "IMAGINE Image");

                        //输出到mapcontrol中
                        IRasterDataset pOutResultDS = default(IRasterDataset);
                        pOutResultDS = (IRasterDataset)pDataset;
                        IRasterLayer pOutRasterLayer = default(IRasterLayer);
                        pOutRasterLayer = new RasterLayer();
                        pOutRasterLayer.CreateFromDataset(pOutResultDS);
                        //MapControlMain.AddLayer(pOutRasterLayer)
                        pCurMap.AddLayer(pOutRasterLayer);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("保存计算结果为空，请输入结果文件名！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //Interaction.MsgBox(ex.ToString);
            }
        }
        #endregion
        #region "保存栅格运算后的结果"
        private void btnSaveResult_Click(System.Object sender, System.EventArgs e)
        {
            string pOutDSName = null;
            int iOutIndex = 0;
            var _with1 = SaveFileDialog1;
            _with1.Title = "保存栅格运算结果";
            _with1.Filter = "(*.img)|*.img";
            _with1.OverwritePrompt = false;
            _with1.InitialDirectory = Application.StartupPath;
            if (_with1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pOutDSName = _with1.FileName;
                FileInfo fFile = new FileInfo(pOutDSName);
                //判断文件名是否已经存在，如果存在，则弹出提示
                if (fFile.Exists == true)
                {
                    MessageBox.Show("文件名已存在，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    txtResultFullName.Text = "";

                }
                else
                {
                    iOutIndex = pOutDSName.LastIndexOf("\\");
                    sOutRasPath = pOutDSName.Substring(0, iOutIndex + 1);
                    sOutRasName = pOutDSName.Substring(iOutIndex + 1, pOutDSName.Length - iOutIndex - 1);
                    txtResultFullName.Text = pOutDSName;
                }

            }
        }
        #endregion
        /// <summary>
        /// 扩展运算公式组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void btnExtend_Click(System.Object sender, System.EventArgs e)
        {
            if (panExtend.Visible == true)
            {
                panExtend.Visible = false;
                this.Width = 442;
                btnExtend.Text = ">>";
            }
            else
            {
                panExtend.Visible = true;
                this.Width = 592;
                btnExtend.Text = "<<";
            }

        }

        private void FrmRasterCalculatornew_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmRasterCalculatornew.TmpFrmRasterCalculatornew = null;
        }

        private void FrmRasterCalculatornew_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

    }
}
