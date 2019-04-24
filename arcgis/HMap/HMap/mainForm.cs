using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geometry;
using MapOperation;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HMap
{
    public partial class mainForm : System.Windows.Forms.Form
    {
        //初始化
        private FormMeasureResult frmMeasureResult = null;   //量算结果窗体
        private INewLineFeedback pNewLineFeedback;           //追踪线对象
        private INewPolygonFeedback pNewPolygonFeedback;     //追踪面对象
        private IPoint pPointPt = null;                      //鼠标点击点
        private IPoint pMovePt = null;                       //鼠标移动时的当前点
        private double dToltalLength = 0;                    //量测总长度
        private double dSegmentLength = 0;                   //片段距离
        private IPointCollection pAreaPointCol = new MultipointClass();  //面积量算时画的点进行存储；  
        private string sMapUnits = "未知单位";             //地图单位变量
        private object missing = Type.Missing;
        string pMouseOperate = null;
        public static mainForm mainform;  //实例化窗体
        public static CustomizeDialog m_CustomizeDialog; //自定义控件绑定
        private int flag = 0; //工具标志

        public mainForm()
        {
            InitializeComponent();
            mainform = this;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            baseOrder.create_customize_dialog();
        }

        //exit按钮按下
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.exit();
        }

        //new document按钮按下
        private void file_new_Click(object sender, EventArgs e)
        {
            baseOrder.new_doc();
        }

        //open document按钮按下
        private void openDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.open_doc();
        }

        //save document按钮按下
        private void saveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.save_doc();
        }

        //save as按钮按下
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.saveas_doc();
        }

        //add layer按钮按下
        private void addLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.add_layer();
        }

        //add shapefile按钮按下
        private void addShapefileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.add_shapefile();
        }

        //delet layer按钮按下
        private void deleteLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.del_top_layer();
        }

        //clear all layers按钮按下
        private void clearAllLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.clear_layers();
        }

        //move last layer按钮按下
        private void moveLayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.move_last_layer();
        }

        //customizes按钮按下
        private void customizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //开始鹰眼操作
        private void EagleEyeMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            baseOrder.start_move(e);
        }

        //同步鹰眼
        private void mainMapControl_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            baseOrder.SynchronizeEagleEye();
        }

        //鹰眼得到当前显示范围
        private void mainMapControl_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            baseOrder.get_extent(e);
        }

        //鹰眼矩形框移动
        private void EagleEyeMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            baseOrder.move_rect(e);
        }

        //结束对鹰眼操作
        private void EagleEyeMapControl_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            baseOrder.end_move(e);
        }

        //拉框选择按钮按下
        private void boxSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
        }

        //拉框选择
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (flag == 1)
                baseOrder.box_select(e);
            //屏幕坐标点转化为地图坐标点
            pPointPt = (mainMapControl.Map as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

            if (e.button == 1)
            {
                IActiveView pActiveView = mainMapControl.ActiveView;
                IEnvelope pEnvelope = new EnvelopeClass();
                if (pMouseOperate == "MeasureLength")
                {
                    //判断追踪线对象是否为空，若是则实例化并设置当前鼠标点为起始点
                    if (pNewLineFeedback == null)
                    {
                        //实例化追踪线对象
                        pNewLineFeedback = new NewLineFeedbackClass();
                        pNewLineFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                        //设置起点，开始动态线绘制
                        pNewLineFeedback.Start(pPointPt);
                        dToltalLength = 0;
                    }
                    else //如果追踪线对象不为空，则添加当前鼠标点
                    {
                        pNewLineFeedback.AddPoint(pPointPt);
                    }
                    //pGeometry = m_PointPt;
                    if (dSegmentLength != 0)
                    {
                        dToltalLength = dToltalLength + dSegmentLength;
                    }
                }
                else if (pMouseOperate == "MeasureArea")
                {
                    if (pNewPolygonFeedback == null)
                    {
                        //实例化追踪面对象
                        pNewPolygonFeedback = new NewPolygonFeedback();
                        pNewPolygonFeedback.Display = (mainMapControl.Map as IActiveView).ScreenDisplay;
                        ;
                        pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount);
                        //开始绘制多边形
                        pNewPolygonFeedback.Start(pPointPt);
                        pAreaPointCol.AddPoint(pPointPt, ref missing, ref missing);
                    }
                    else
                    {
                        pNewPolygonFeedback.AddPoint(pPointPt);
                        pAreaPointCol.AddPoint(pPointPt, ref missing, ref missing);
                    }
                }
            }
            else if (e.button == 2)
            {
                pMouseOperate = "";
                mainMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
        }
        //打开个人地理数据库
        private void openFileDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.load_personal_database();
        }

        //清除选择
        private void clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.clear_selection();
        }

        //添加栅格数据
        private void addRasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.add_raster();
        }

        //图层管理窗口
        private void layManageWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            layerManageForm f = new layerManageForm
            {
                Owner = this
            };
            f.Show();
        }

        //打开mxd
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            baseOrder.open_doc();
        }

        //添加数据
        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            baseOrder.add_data();
        }

        //保存
        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            baseOrder.save_doc();
        }

        //放大
        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            baseOrder.zoom_in();
        }

        //缩小
        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            baseOrder.zoom_out();
        }

        //漫游
        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            baseOrder.pan();
        }

        //全图
        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            baseOrder.full_view();
        }

        //自定义
        private void ToolStripLabel3_Click(object sender, EventArgs e)
        {
            m_CustomizeDialog.StartDialog(axToolbarControl1.hWnd);
        }

        //管理书签
        private void ManageBookMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FormManageBookMarks frmManageBookMark = new FormManageBookMarks(mainMapControl.Map);
                frmManageBookMark.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //缩放至选择
        private void ScalesToSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.zoom_to_selection();
        }

        //添加书签
        private void AddBookMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookMark bookmark = new bookMark();
            bookmark.Show();
        }

        //距离量测
        private void DistanceMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;

            frmMeasureResult_frmColsed();
            mainMapControl.CurrentTool = null;
            pMouseOperate = "MeasureLength";
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            if (frmMeasureResult == null || frmMeasureResult.IsDisposed)
            {
                frmMeasureResult = new FormMeasureResult();
                frmMeasureResult.frmClosed += new FormMeasureResult.FormClosedEventHandler(frmMeasureResult_frmColsed);
                frmMeasureResult.label2.Text = "";
                frmMeasureResult.Text = "距离量测";
                frmMeasureResult.Show();
            }
            else
            {
                frmMeasureResult.Activate();
            }
        }


        //面积量测
        private void AreaMeasureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;

            frmMeasureResult_frmColsed();
            mainMapControl.CurrentTool = null;
            pMouseOperate = "MeasureArea";
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
            if (frmMeasureResult == null || frmMeasureResult.IsDisposed)
            {
                frmMeasureResult = new FormMeasureResult();
                frmMeasureResult.frmClosed += new FormMeasureResult.FormClosedEventHandler(frmMeasureResult_frmColsed);
                frmMeasureResult.label2.Text = "";
                frmMeasureResult.Text = "面积量测";
                frmMeasureResult.Show();
            }
            else
            {
                frmMeasureResult.Activate();
            }
        }

        //鼠标移动
        private void MainMapControl_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            sMapUnits = GetMapUnit(mainMapControl.Map.MapUnits);
            mainform.toolStripStatusLabel1.Text = String.Format("当前坐标：X = {0:#.###} Y = {1:#.###} {2}", e.mapX, e.mapY, sMapUnits);

            frmMeasureResult.label2.Text = String.Format("当前坐标：X = {0:#.###} Y = {1:#.###} {2}", e.mapX, e.mapY, sMapUnits);
            pMovePt = (mainMapControl.Map as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);

            if (pMouseOperate == "MeasureLength")
            {
                if (pNewLineFeedback != null)
                {
                    pNewLineFeedback.MoveTo(pMovePt);
                }
                double deltaX = 0; //两点之间X差值
                double deltaY = 0; //两点之间Y差值

                if ((pPointPt != null) && (pNewLineFeedback != null))
                {
                    deltaX = pMovePt.X - pPointPt.X;
                    deltaY = pMovePt.Y - pPointPt.Y;
                    dSegmentLength = Math.Round(Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY)), 3);
                    dToltalLength = dToltalLength + dSegmentLength;
                    if (frmMeasureResult != null)
                    {
                        frmMeasureResult.label2.Text = String.Format(
                            "当前线段长度：{0:.###}{1};\r\n总长度为: {2:.###}{1}",
                            dSegmentLength, sMapUnits, dToltalLength);
                        dToltalLength = dToltalLength - dSegmentLength; //鼠标移动到新点重新开始计算
                    }
                    frmMeasureResult.frmClosed += new FormMeasureResult.FormClosedEventHandler(frmMeasureResult_frmColsed);
                }
            }
            if (pMouseOperate == "MeasureArea")
            {
                if (pNewPolygonFeedback != null)
                {
                    pNewPolygonFeedback.MoveTo(pMovePt);
                }

                IPointCollection pPointCol = new Polygon();
                IPolygon pPolygon = new PolygonClass();
                IGeometry pGeo = null;

                ITopologicalOperator pTopo = null;
                for (int i = 0; i <= pAreaPointCol.PointCount - 1; i++)
                {
                    pPointCol.AddPoint(pAreaPointCol.get_Point(i), ref missing, ref missing);
                }
                pPointCol.AddPoint(pMovePt, ref missing, ref missing);

                if (pPointCol.PointCount < 3) return;
                pPolygon = pPointCol as IPolygon;

                if ((pPolygon != null))
                {
                    pPolygon.Close();
                    pGeo = pPolygon as IGeometry;
                    pTopo = pGeo as ITopologicalOperator;
                    //使几何图形的拓扑正确
                    pTopo.Simplify();
                    pGeo.Project(mainMapControl.Map.SpatialReference);
                    IArea pArea = pGeo as IArea;

                    frmMeasureResult.label2.Text = String.Format("总面积为：{0:.####}平方{1};\r\n总长度为：{2:.####}{1}", pArea.Area, sMapUnits, pPolygon.Length);
                    pPolygon = null;
                }
            }
        }

        private void MainMapControl_OnDoubleClick(object sender, IMapControlEvents2_OnDoubleClickEvent e)
        {
            if (pMouseOperate == "MeasureLength")
            {
                if (frmMeasureResult != null)
                {
                    frmMeasureResult.label2.Text = "线段总长度为：" + dToltalLength + sMapUnits;
                }
                if (pNewLineFeedback != null)
                {
                    pNewLineFeedback.Stop();
                    pNewLineFeedback = null;
                    //清空所画的线对象
                    (mainMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                }
                dToltalLength = 0;
                dSegmentLength = 0;
            }
            else if (pMouseOperate == "MeasureArea")
            {
                if (pNewPolygonFeedback != null)
                {
                    pNewPolygonFeedback.Stop();
                    pNewPolygonFeedback = null;
                    //清空所画的线对象
                    (mainMapControl.Map as IActiveView).PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                }
                pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount); //清空点集中所有点
            }
        }

        //获取地图单位
        private string GetMapUnit(esriUnits _esriMapUnit)
        {
            string sMapUnits = string.Empty;
            switch (_esriMapUnit)
            {
                case esriUnits.esriCentimeters:
                    sMapUnits = "厘米";
                    break;
                case esriUnits.esriDecimalDegrees:
                    sMapUnits = "度";
                    break;
                case esriUnits.esriDecimeters:
                    sMapUnits = "分米";
                    break;
                case esriUnits.esriFeet:
                    sMapUnits = "尺";
                    break;
                case esriUnits.esriInches:
                    sMapUnits = "英寸";
                    break;
                case esriUnits.esriKilometers:
                    sMapUnits = "千米";
                    break;
                case esriUnits.esriMeters:
                    sMapUnits = "米";
                    break;
                case esriUnits.esriMiles:
                    sMapUnits = "英里";
                    break;
                case esriUnits.esriMillimeters:
                    sMapUnits = "毫米";
                    break;
                case esriUnits.esriNauticalMiles:
                    sMapUnits = "海里";
                    break;
                case esriUnits.esriPoints:
                    sMapUnits = "点";
                    break;
                case esriUnits.esriUnitsLast:
                    sMapUnits = "UnitsLast";
                    break;
                case esriUnits.esriUnknownUnits:
                    sMapUnits = "单位未知";
                    break;
                case esriUnits.esriYards:
                    sMapUnits = "码";
                    break;
                default:
                    break;
            }
            return sMapUnits;
        }
        
        //绘制面
        public IPolygon DrawPolygon(AxMapControl mapCtrl)
        {
            IGeometry pGeometry = null;
            if (mapCtrl == null) return null;
            IRubberBand rb = new RubberPolygonClass();
            pGeometry = rb.TrackNew(mapCtrl.ActiveView.ScreenDisplay, null);
            return pGeometry as IPolygon;
        }

        //测量结果窗口关闭响应事件---清空绘制要素
        private void frmMeasureResult_frmColsed()
        {
            //清空线对象
            if (pNewLineFeedback != null)
            {
                pNewLineFeedback.Stop();
                pNewLineFeedback = null;
            }
            //清空面对象
            if (pNewPolygonFeedback != null)
            {
                pNewPolygonFeedback.Stop();
                pNewPolygonFeedback = null;
                pAreaPointCol.RemovePoints(0, pAreaPointCol.PointCount); //清空点集中所有点
            }
            //清空量算画的线、面对象
            mainMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            //结束量算功能
            pMouseOperate = string.Empty;
            mainMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
        }

        private void FindByAttributeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAttriQuery frmAttQDlg = new frmAttriQuery();
            frmAttQDlg.Show();
        }

        //RGB转LONG
        private long RGBtoLong(int Red, int Green, int Blue)
        {
            return Red + (0x100 * Green) + (0x10000 * Blue);
            //return Red + (256*Green) + (65536*Blue); 
        }

        //LONG转RGB 
        private short[] LongToRGB(long RGBlong)
        {
            short[] pbyte = new short[3];
            pbyte[0] = (short)(RGBlong % 0x100);
            pbyte[1] = (short)((RGBlong / 0x100) % 0x100);
            pbyte[2] = (short)((RGBlong / 0x10000) % 0x100);
            return pbyte;
        }

        //RGB颜色构造器
        private IRgbColor getRGB(int R, int G, int B)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = R;
            pColor.Green = G;
            pColor.Blue = B;
            return pColor;
        }

        //HSV颜色构造器
        private IHsvColor getHSV(int Hue, int Saturation, int Val)
        {
            IHsvColor pColor; pColor = new HsvColorClass();
            pColor.Hue = Hue;
            pColor.Saturation = Saturation;
            pColor.Value = Val; return pColor;
        }

        //AlgorithmicColorRamp是通过起止颜色来确定多个在这两个颜色之间的色带
        private IEnumColors createAlgorithmicColorRamp(IColor fromColor, IColor toColor, int count)
        {
            IAlgorithmicColorRamp pRampColor;
            pRampColor = new AlgorithmicColorRampClass();
            pRampColor.FromColor = fromColor;
            pRampColor.ToColor = toColor;
            pRampColor.Size = count;
            bool ok;
            pRampColor.CreateRamp(out ok);
            return pRampColor.Colors;
        }

        //简单符号化
        private void MarkerSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //获得点图层，要求当前地图文档第一个图层为点图层 
                IFeatureLayer layer;
                layer = mainMapControl.get_Layer(0) as IFeatureLayer;
                //QI到IGeoFeatureLayer 
                IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
                //新建SimpleRendererClass对象 
                SimpleRenderer simpleRender = new SimpleRendererClass();
                ISimpleMarkerSymbol pMarkerSymbol;
                IColor pColor = new RgbColorClass();
                pColor.RGB = 2256;
                pMarkerSymbol = new SimpleMarkerSymbolClass();
                pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                pMarkerSymbol.Color = pColor;
                pMarkerSymbol.Angle = 60;
                pMarkerSymbol.Size = 6;
                simpleRender.Symbol = pMarkerSymbol as ISymbol;
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
                mainMapControl.Refresh();
                axTOCControl1.Update();
            }
            catch
            {
                MessageBox.Show("没有可以实例化的图层");
            }
        }

        //箭头符号化
        private void ArrowMarkerSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //获得点图层，要求当前地图文档第一个图层为点图层 
                IFeatureLayer layer;
                layer = mainMapControl.get_Layer(0) as IFeatureLayer;
                //QI到IGeoFeatureLayer 
                IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
                SimpleRenderer simpleRender = new SimpleRendererClass();
                IArrowMarkerSymbol pMarkerSymbol;
                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 255;
                pColor.Green = 0;
                pColor.Blue = 255;
                pMarkerSymbol = new ArrowMarkerSymbolClass();
                pMarkerSymbol.Length = 20;
                pMarkerSymbol.Color = pColor;
                pMarkerSymbol.Width = 10;
                //箭头底边的宽度
                pMarkerSymbol.Angle = 60;
                simpleRender.Symbol = pMarkerSymbol as ISymbol;
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
                mainMapControl.Refresh();
                axTOCControl1.Update();
            }
            catch
            {
                MessageBox.Show("没有可以实例化的图层");
            }
        }

        //文字符号化
        private void CharacterMarkerSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //获得点图层，要求当前地图文档第一个图层为点图层 
                IFeatureLayer layer;
                layer = mainMapControl.get_Layer(0) as IFeatureLayer;
                //QI到IGeoFeatureLayer 
                IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
                SimpleRenderer simpleRender = new SimpleRendererClass();
                ICharacterMarkerSymbol pCharacterMarkerSymbol = new CharacterMarkerSymbolClass();
                IColor pColor = new RgbColorClass();
                pColor.RGB = 2256;
                stdole.IFontDisp font = new stdole.StdFontClass() as stdole.IFontDisp;
                font.Name = "Arial"; font.Size = 30;
                font.Bold = true;
                pCharacterMarkerSymbol.Font = font;
                pCharacterMarkerSymbol.Color = pColor;
                pCharacterMarkerSymbol.Size = 20;
                pCharacterMarkerSymbol.CharacterIndex = 55;
                //ASCII55对应数字7 
                simpleRender.Symbol = pCharacterMarkerSymbol as ISymbol;
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
                mainMapControl.Refresh();
                axTOCControl1.Update();
            }
            catch
            {
                MessageBox.Show("没有可以实例化的图层");
            }
        }

        //图片符号化
        private void PictureMarkerSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //获得点图层，要求当前地图文档第一个图层为点图层 
                IFeatureLayer layer;
                layer = mainMapControl.get_Layer(0) as IFeatureLayer;
                //QI到IGeoFeatureLayer 
                IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
                SimpleRenderer simpleRender = new SimpleRendererClass();
                //指定图片存放的位置
                //实例化OpenFileDialog控件
                OpenFileDialog pOpenFileDialog = new OpenFileDialog
                {
                    CheckFileExists = true,
                    RestoreDirectory = true,
                    Title = "选择图片"
                };

                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = pOpenFileDialog.FileName;
                    IPictureMarkerSymbol pPictureMarkerSymbol = new PictureMarkerSymbolClass();
                    pPictureMarkerSymbol.Size = 40;
                    pPictureMarkerSymbol.CreateMarkerSymbolFromFile(esriIPictureType.esriIPictureBitmap, path);
                    simpleRender.Symbol = pPictureMarkerSymbol as ISymbol;
                    geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
                    mainMapControl.Refresh();
                    axTOCControl1.Update();
                }                   
            }
            catch
            {
                MessageBox.Show("没有可以实例化的图层");
            }
        }

        //组合点符号化
        private void MultiLayerMarkerSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //获得点图层，要求当前地图文档第一个图层为点图层 
                IFeatureLayer layer;
                layer = mainMapControl.get_Layer(0) as IFeatureLayer;
                //QI到IGeoFeatureLayer 
                IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
                SimpleRenderer simpleRender = new SimpleRendererClass();
                //创建第一组成成分点符号的颜色
                IColor pColor = new RgbColorClass();
                pColor.RGB = 2256;
                //创建第二组成成分点符号的颜色
                IColor pColor1 = new RgbColorClass();
                pColor1.RGB = 0;
                //创建简单点符号
                ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
                pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCross;
                pMarkerSymbol.Color = pColor;
                pMarkerSymbol.Angle = 60;
                //创建箭头点符号
                IArrowMarkerSymbol pArrowMarkerSymbol = new ArrowMarkerSymbolClass();
                pArrowMarkerSymbol.Length = 5;
                pArrowMarkerSymbol.Width = 10;
                pArrowMarkerSymbol.Color = pColor1;
                //创建以上两种符号的组合符号
                IMultiLayerMarkerSymbol pMultiLayerMarkerSymbol = new MultiLayerMarkerSymbolClass();
                pMultiLayerMarkerSymbol.AddLayer(pArrowMarkerSymbol);
                pMultiLayerMarkerSymbol.AddLayer(pMarkerSymbol);
                simpleRender.Symbol = pMultiLayerMarkerSymbol as ISymbol;
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
                mainMapControl.Refresh();
                axTOCControl1.Update();
            }
            catch
            {
                MessageBox.Show("没有可以实例化的图层");
            }
        }

        //简单线符号化
        private void SimpleLineSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得线图层，要求当前地图文档第二个图层为线图层 
            IFeatureLayer layer;
            layer = mainMapControl.get_Layer(1) as IFeatureLayer;
            //QI到IGeoFeatureLayer 
            IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            IColor pColor = new RgbColorClass();
            pColor.RGB = 2256;
            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
            pSimpleLineSymbol.Color = pColor;
            pSimpleLineSymbol.Width = 3;
            pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDot;
            simpleRender.Symbol = pSimpleLineSymbol as ISymbol;
            geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            mainMapControl.Refresh();
            axTOCControl1.Update();
        }

        //简单填充符号化
        private void SimpleFillSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //获得面图层，要求当前地图文档第三个图层为面图层 
            IFeatureLayer layer = mainMapControl.get_Layer(2) as IFeatureLayer;
            IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            IColor pLineColor = new RgbColorClass();
            pLineColor.RGB = 2256;
            IColor pFillColor = new RgbColorClass();
            pFillColor.RGB = 255;
            ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
            pSimpleLineSymbol.Width = 5;
            pSimpleLineSymbol.Color = pLineColor;
            ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
            pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSCross;
            pSimpleFillSymbol.Outline = pSimpleLineSymbol;
            pSimpleFillSymbol.Color = pFillColor;
            simpleRender.Symbol = pSimpleFillSymbol as ISymbol;
            geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            mainMapControl.Refresh();
            axTOCControl1.Update();
        }
    }
}