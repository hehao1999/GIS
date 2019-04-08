﻿using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using System;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using ESRI.ArcGIS.DataSourcesRaster;

namespace HMap
{
    public class baseOrder
    {
        //鹰眼同步
        private static bool bCanDrag;              //鹰眼地图上的矩形框可移动的标志
        private static IPoint pMoveRectPoint;      //记录在移动鹰眼地图上的矩形框时鼠标的位置
        private static IEnvelope pEnv;             //记录数据视图的Extent
        public static IFeatureLayer pTocFeatureLayer = null;

        #region 退出程序

        public static void exit()
        {
            try
            {
                if (MessageBox.Show("真的要退出程序吗", "信息提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    mainForm.mainform.Close();
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

        public static void new_doc()
        {
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
                    mainForm.mainform.mainMapControl.LoadMxFile(filename);

                    //将图层名重设为“图层”
                    mainForm.mainform.mainMapControl.Map.Name = "图层";
                    mainForm.mainform.axTOCControl1.Update();

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

        #region 打开地图文档

        public static void open_doc()
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
                    if (mainForm.mainform.mainMapControl.CheckMxFile(filename))
                    {//有效地图文档，加载地图
                        mainForm.mainform.mainMapControl.LoadMxFile(filename);
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

        #endregion 打开地图文档

        #region 保存地图文档

        public static void save_doc()
        {
            try
            {
                string filename = mainForm.mainform.mainMapControl.DocumentFilename;
                IMapDocument pMapDocument = new MapDocumentClass();
                if (filename != null && mainForm.mainform.mainMapControl.CheckMxFile(filename))
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
                pMapDocument.ReplaceContents(mainForm.mainform.mainMapControl.Map as IMxdContents);
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

        #region 另存为地图文档

        public static void saveas_doc()
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
                    pMapDocument.ReplaceContents(mainForm.mainform.mainMapControl.Map as IMxdContents);
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

        #endregion 另存为地图文档

        #region 添加图层

        public static void add_layer()
        {
            try
            {
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.Title = "加载图层文件";
                pOpenFileDialog.Filter = "Map Layers(*.lyr)|*.lyr";
                pOpenFileDialog.CheckFileExists = true;
                pOpenFileDialog.RestoreDirectory = true;
                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filename = pOpenFileDialog.FileName;
                    mainForm.mainform.mainMapControl.AddLayerFromFile(filename);
                    return;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("加载图层失败" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 添加图层

        #region 加载Shapefile

        public static void add_shapefile()
        {
            try
            {
                OpenFileDialog pOpenFileDialog = new OpenFileDialog();
                pOpenFileDialog.Title = "打开Shapefile文件";
                pOpenFileDialog.Filter = "Shape Files(*.shp)|*.shp";
                pOpenFileDialog.CheckFileExists = true;
                pOpenFileDialog.RestoreDirectory = true;
                if (pOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sFilePath = pOpenFileDialog.FileName;
                    int poi = sFilePath.LastIndexOf("\\");
                    string path = sFilePath.Substring(0, poi);
                    string fileName = sFilePath.Substring(poi + 1);
                    mainForm.mainform.mainMapControl.AddShapeFile(path, fileName);
                }
                return;
            }
            catch (Exception exc)
            {
                MessageBox.Show("加载Shapefile失败" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 加载Shapefile

        #region 加载栅格数据
        public static void add_raster()
        {
            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.CheckFileExists = true;
            pOpenFileDialog.Title = "打开Raster文件";
            pOpenFileDialog.Filter = "栅格文件 (*.*)|*.bmp;*.tif;*.jpg;*.img|(*.bmp)|*.bmp|(*.tif)|*.tif|(*.jpg)|*.jpg|(*.img)|*.img";
            pOpenFileDialog.ShowDialog();

            string pRasterFileName = pOpenFileDialog.FileName;
            if (pRasterFileName == "")
            {
                return;
            }

            string pPath = System.IO.Path.GetDirectoryName(pRasterFileName);
            string pFileName = System.IO.Path.GetFileName(pRasterFileName);

            IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pPath, 0);
            IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;
            IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pFileName);
            //影像金字塔判断与创建
            IRasterPyramid3 pRasPyrmid;
            pRasPyrmid = pRasterDataset as IRasterPyramid3;
            if (pRasPyrmid != null)
            {
                if (!(pRasPyrmid.Present))
                {
                    pRasPyrmid.Create(); //创建金字塔
                }
            }
            IRaster pRaster;
            pRaster = pRasterDataset.CreateDefaultRaster();
            IRasterLayer pRasterLayer;
            pRasterLayer = new RasterLayerClass();
            pRasterLayer.CreateFromRaster(pRaster);
            ILayer pLayer = pRasterLayer as ILayer;
            mainForm.mainform.mainMapControl.AddLayer(pLayer, 0);
        }
        #endregion

        #region 删除顶层图层

        public static void del_top_layer()
        {
            try
            {
                mainForm.mainform.mainMapControl.DeleteLayer(0);
                return;
            }
            catch (System.Exception exc)
            {
                MessageBox.Show("删除图层失败！" + exc.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 删除顶层图层

        #region 删除所有图层

        public static void clear_layers()
        {
            try
            {
                mainForm.mainform.mainMapControl.ClearLayers();
                mainForm.mainform.axTOCControl1.Update();
                return;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("删除图层失败！" + ex.Message, "信息提示", MessageBoxButtons.OK);
                return;
            }
        }

        #endregion 删除所有图层

        #region 移动最后一个图层

        public static void move_last_layer()
        {
            try
            {
                if (mainForm.mainform.mainMapControl.LayerCount > 0)
                {
                    mainForm.mainform.mainMapControl.MoveLayerTo(mainForm.mainform.mainMapControl.LayerCount - 1, 0);
                }
                return;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("移动图层失败！"+ ex.Message, "信息提示", MessageBoxButtons.OK );
                return;
            }
        }

        #endregion 移动最后一个图层

        #region 生成自定义控件窗口

        public static void create_customize_dialog()
        {
            try
            {
                mainForm.m_CustomizeDialog = new CustomizeDialog();
                mainForm.m_CustomizeDialog.DialogTitle = "自定义ToolbarControl项目";
                mainForm.m_CustomizeDialog.ShowAddFromFile = true;
                mainForm.m_CustomizeDialog.SetDoubleClickDestination(mainForm.mainform.axToolbarControl1);
                ICustomizeDialogEvents_OnStartDialogEventHandler startDialogE = new ICustomizeDialogEvents_OnStartDialogEventHandler(OnStartDialog);
                ((ICustomizeDialogEvents_Event)mainForm.m_CustomizeDialog).OnStartDialog += startDialogE;
                ICustomizeDialogEvents_OnCloseDialogEventHandler closeDialogE = new ICustomizeDialogEvents_OnCloseDialogEventHandler(OnCloseDialog);
                ((ICustomizeDialogEvents_Event)mainForm.m_CustomizeDialog).OnCloseDialog += closeDialogE;
                return;
            }
            catch
            {
                MessageBox.Show("未知错误!", "信息提示", MessageBoxButtons.OK);
            }
        }

        private static void OnStartDialog()
        {
            mainForm.mainform.axToolbarControl1.Customize = true;
            return;
        }

        private static void OnCloseDialog()
        {
            mainForm.mainform.axToolbarControl1.Customize = false;
            return;
        }

        #endregion 生成自定义控件窗口

        #region 放大、缩小、全局视图
        public static void zoom_in()
        {
            ICommand pZoomIn = new ControlsMapZoomInToolClass();
            pZoomIn.OnCreate(mainForm.mainform.mainMapControl.Object);
            mainForm.mainform.mainMapControl.CurrentTool = pZoomIn as ITool;
        }
        public static void zoom_out()
        {
            ICommand pZoomOut = new ControlsMapZoomOutToolClass();
            pZoomOut.OnCreate(mainForm.mainform.mainMapControl.Object);
            mainForm.mainform.mainMapControl.CurrentTool = pZoomOut as ITool;
        }
        public static void full_view()
        {
            ICommand pFullExtent = new ControlsMapFullExtentCommandClass();
            pFullExtent.OnCreate(mainForm.mainform.mainMapControl.Object);
            pFullExtent.OnClick();
        }
        #endregion

        #region 鹰眼
        public static void SynchronizeEagleEye()
        {//鹰眼同步
            if (mainForm.mainform.EagleEyeMapControl.LayerCount > 0)
            {//清理图层 
                mainForm.mainform.EagleEyeMapControl.ClearLayers();
            }

            mainForm.mainform.EagleEyeMapControl.SpatialReference = mainForm.mainform.mainMapControl.SpatialReference;//设置鹰眼和主地图的坐标系统一致

            for (int i = mainForm.mainform.mainMapControl.LayerCount - 1; i >= 0; i--)
            {//使鹰眼视图与数据视图的图层上下顺序保持一致
                ILayer pLayer = mainForm.mainform.mainMapControl.get_Layer(i);
                if (pLayer is IGroupLayer || pLayer is ICompositeLayer)
                {
                    ICompositeLayer pCompositeLayer = (ICompositeLayer)pLayer;
                    for (int j = pCompositeLayer.Count - 1; j >= 0; j--)
                    {
                        ILayer pSubLayer = pCompositeLayer.get_Layer(j);
                        IFeatureLayer pFeatureLayer = pSubLayer as IFeatureLayer;
                        if (pFeatureLayer != null)
                        {
                            //由于鹰眼地图较小，所以过滤点图层不添加
                            if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                                && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                            {
                                mainForm.mainform.EagleEyeMapControl.AddLayer(pLayer);
                            }
                        }
                    }
                }
                else
                {
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (pFeatureLayer != null)
                    {
                        if (pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint
                            && pFeatureLayer.FeatureClass.ShapeType != esriGeometryType.esriGeometryMultipoint)
                        {
                            mainForm.mainform.EagleEyeMapControl.AddLayer(pLayer);
                        }
                    }
                }
                //设置鹰眼地图全图显示  
                mainForm.mainform.EagleEyeMapControl.Extent = mainForm.mainform.mainMapControl.FullExtent;
                pEnv = mainForm.mainform.mainMapControl.Extent as IEnvelope;
                DrawRectangle(pEnv);
               mainForm.mainform.EagleEyeMapControl.ActiveView.Refresh();
            }
        }

        public static void DrawRectangle(IEnvelope pEnvelope)
        {//在鹰眼地图上面画矩形框
            //在绘制前，清除鹰眼中之前绘制的矩形框
            IGraphicsContainer pGraphicsContainer = mainForm.mainform.EagleEyeMapControl.Map as IGraphicsContainer;
            IActiveView pActiveView = pGraphicsContainer as IActiveView;
            pGraphicsContainer.DeleteAllElements();
            //得到当前视图范围
            IRectangleElement pRectangleElement = new RectangleElementClass();
            IElement pElement = pRectangleElement as IElement;
            pElement.Geometry = pEnvelope;
            //设置矩形框（实质为中间透明度面）
            IRgbColor pColor = new RgbColorClass();
            pColor = GetRgbColor(255, 0, 0);
            pColor.Transparency = 255;
            ILineSymbol pOutLine = new SimpleLineSymbolClass();
            pOutLine.Width = 2;
            pOutLine.Color = pColor;

            IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pColor = new RgbColorClass();
            pColor.Transparency = 0;
            pFillSymbol.Color = pColor;
            pFillSymbol.Outline = pOutLine;
            //向鹰眼中添加矩形框
            IFillShapeElement pFillShapeElement = pElement as IFillShapeElement;
            pFillShapeElement.Symbol = pFillSymbol;
            pGraphicsContainer.AddElement((IElement)pFillShapeElement, 0);
            //刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        public static IRgbColor GetRgbColor(int intR, int intG, int intB)
        {//取色
            IRgbColor pRgbColor = null;
            if (intR < 0 || intR > 255 || intG < 0 || intG > 255 || intB < 0 || intB > 255)
            {
                return pRgbColor;
            }
            pRgbColor = new RgbColorClass();
            pRgbColor.Red = intR;
            pRgbColor.Green = intG;
            pRgbColor.Blue = intB;
            return pRgbColor;
        }

        public static void start_move(IMapControlEvents2_OnMouseDownEvent e)
        {//生成鹰眼图
            if (mainForm.mainform.EagleEyeMapControl.Map.LayerCount > 0)
            {
                //按下鼠标左键移动矩形框
                if (e.button == 1)
                {
                    //如果指针落在鹰眼的矩形框中，标记可移动
                    if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
                    {
                        bCanDrag = true;
                    }
                    pMoveRectPoint = new PointClass();
                    pMoveRectPoint.PutCoords(e.mapX, e.mapY);  //记录点击的第一个点的坐标
                }
                //按下鼠标右键绘制矩形框
                else if (e.button == 2)
                {
                    IEnvelope pEnvelope = mainForm.mainform.EagleEyeMapControl.TrackRectangle();

                    IPoint pTempPoint = new PointClass();
                    pTempPoint.PutCoords(pEnvelope.XMin + pEnvelope.Width / 2, pEnvelope.YMin + pEnvelope.Height / 2);
                    mainForm.mainform.mainMapControl.Extent = pEnvelope;
                    //矩形框的高宽和数据试图的高宽不一定成正比，这里做一个中心调整
                    mainForm.mainform.mainMapControl.CenterAt(pTempPoint);
                }
            }
        }

        public static void get_extent(IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            //得到当前视图范围
            pEnv = (IEnvelope)e.newEnvelope;
            DrawRectangle(pEnv);
        }

        public static void move_rect(IMapControlEvents2_OnMouseMoveEvent e)
        {//移动鹰眼矩形框

            if (e.mapX > pEnv.XMin && e.mapY > pEnv.YMin && e.mapX < pEnv.XMax && e.mapY < pEnv.YMax)
            {
                //如果鼠标移动到矩形框中，鼠标换成小手，表示可以拖动
                mainForm.mainform.EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerHand;
                if (e.button == 2)  //如果在内部按下鼠标右键，将鼠标演示设置为默认样式
                {
                    mainForm.mainform.EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
                }
            }
            else
            {
                //在其他位置将鼠标设为默认的样式
                mainForm.mainform.EagleEyeMapControl.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }

            if (bCanDrag)
            {
                double Dx, Dy;  //记录鼠标移动的距离
                Dx = e.mapX - pMoveRectPoint.X;
                Dy = e.mapY - pMoveRectPoint.Y;
                pEnv.Offset(Dx, Dy); //根据偏移量更改 pEnv 位置
                pMoveRectPoint.PutCoords(e.mapX, e.mapY);
                DrawRectangle(pEnv);
                mainForm.mainform.mainMapControl.Extent = pEnv;
            }
        }

        public static void end_move(IMapControlEvents2_OnMouseUpEvent e)
        {//结束鹰眼操作
            if (e.button == 1 && pMoveRectPoint != null)
            {
                if (e.mapX == pMoveRectPoint.X && e.mapY == pMoveRectPoint.Y)
                {
                    mainForm.mainform.mainMapControl.CenterAt(pMoveRectPoint);
                }
                bCanDrag = false;
            }
        }
        #endregion

        #region 拉框选择
        public static void box_select(IMapControlEvents2_OnMouseDownEvent e)
        {
            mainForm.mainform.mainMapControl.CurrentTool = null;
            IMap pMap = mainForm.mainform.mainMapControl.Map;
            IActiveView pActiveView = pMap as IActiveView;
            IEnvelope pEnv = new EnvelopeClass();
            pEnv = mainForm.mainform.mainMapControl.TrackRectangle();
            pMap.SelectByShape(pEnv, null, false);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }
        #endregion

        #region 打开个人地理数据库
        public static void load_personal_database()
        {//代开个人地理数据库
            IWorkspaceFactory pAccessWorkspaceFactory;

            OpenFileDialog pOpenFileDialog = new OpenFileDialog();
            pOpenFileDialog.Filter = "Personal Geodatabase(*.mdb)|*.mdb";
            pOpenFileDialog.Title = "打开PersonGeodatabase文件";
            pOpenFileDialog.ShowDialog();

            string pFullPath = pOpenFileDialog.FileName;
            if (pFullPath == "")
            {
                return;
            }
            pAccessWorkspaceFactory = new AccessWorkspaceFactory();
           
            //获取工作空间
            IWorkspace pWorkspace = pAccessWorkspaceFactory.OpenFromFile(pFullPath, 0);

            //加载工作空间里的数据
            AddAllDataset(pWorkspace, mainForm.mainform.mainMapControl);
        }
        private static void AddAllDataset(IWorkspace pWorkspace, AxMapControl mapControl)
        {//遍历加载所有数据
            IEnumDataset pEnumDataset = pWorkspace.get_Datasets(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
            pEnumDataset.Reset();
            //将Enum数据集中的数据一个个读到DataSet中
            IDataset pDataset = pEnumDataset.Next();
            //判断数据集是否有数据
            while (pDataset != null)
            {
                if (pDataset is IFeatureDataset)  //要素数据集
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureDataset pFeatureDataset = pFeatureWorkspace.OpenFeatureDataset(pDataset.Name);
                    IEnumDataset pEnumDataset1 = pFeatureDataset.Subsets;
                    pEnumDataset1.Reset();
                    IGroupLayer pGroupLayer = new GroupLayerClass();
                    pGroupLayer.Name = pFeatureDataset.Name;
                    IDataset pDataset1 = pEnumDataset1.Next();
                    while (pDataset1 != null)
                    {
                        if (pDataset1 is IFeatureClass)  //要素类
                        {
                            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset1.Name);
                            if (pFeatureLayer.FeatureClass != null)
                            {
                                pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                                pGroupLayer.Add(pFeatureLayer);
                                mapControl.Map.AddLayer(pFeatureLayer);
                            }
                        }
                        pDataset1 = pEnumDataset1.Next();
                    }
                }
                else if (pDataset is IFeatureClass) //要素类
                {
                    IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspace;
                    IFeatureLayer pFeatureLayer = new FeatureLayerClass();
                    pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(pDataset.Name);

                    pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName;
                    mapControl.Map.AddLayer(pFeatureLayer);
                }
                else if (pDataset is IRasterDataset) //栅格数据集
                {
                    IRasterWorkspaceEx pRasterWorkspace = (IRasterWorkspaceEx)pWorkspace;
                    IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(pDataset.Name);
                    //影像金字塔判断与创建
                    IRasterPyramid3 pRasPyrmid;
                    pRasPyrmid = pRasterDataset as IRasterPyramid3;
                    if (pRasPyrmid != null)
                    {
                        if (!(pRasPyrmid.Present))
                        {
                            pRasPyrmid.Create(); //创建金字塔
                        }
                    }
                    IRasterLayer pRasterLayer = new RasterLayerClass();
                    pRasterLayer.CreateFromDataset(pRasterDataset);
                    ILayer pLayer = pRasterLayer as ILayer;
                    mapControl.AddLayer(pLayer, 0);
                }
                pDataset = pEnumDataset.Next();
            }

            mapControl.ActiveView.Refresh();
            //同步鹰眼
            SynchronizeEagleEye();
        }
        #endregion

        #region 清除选择
        public static void clear_selection()
        {
            IActiveView pActiveView = mainForm.mainform.mainMapControl.ActiveView;
            pActiveView.FocusMap.ClearSelection();
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, pActiveView.Extent);
        }
        #endregion

        #region 拖动控制图层顺序
        
        public static void move_layer_mouse_down(ITOCControlEvents_OnMouseDownEvent e)
        {/*
            try
            {
                if (e.button == 2)
                {
                    esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                    IBasicMap pMap = null;
                    ILayer pLayer = null;
                    object unk = null;
                    object data = null;
                    mainForm.mainform.axTOCControl1.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                    baseOrder.pTocFeatureLayer = pLayer as IFeatureLayer;
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer && pTocFeatureLayer != null)
                    {
                        btnLayerSel.Enabled = !pTocFeatureLayer.Selectable;
                        btnLayerUnSel.Enabled = pTocFeatureLayer.Selectable;
                        contextMenuStrip.Show(Control.MousePosition);
                    }
                }
                if (e.button == 1)
                {
                    esriTOCControlItem pItem = esriTOCControlItem.esriTOCControlItemNone;
                    IBasicMap pMap = null; object unk = null;
                    object data = null; ILayer pLayer = null;
                    mainForm.mainform.axTOCControl1.HitTest(e.x, e.y, ref pItem, ref pMap, ref pLayer, ref unk, ref data);
                    if (pLayer == null) return;

                    pMoveLayerPoint.PutCoords(e.x, e.y);
                    if (pItem == esriTOCControlItem.esriTOCControlItemLayer)
                    {
                        if (pLayer is IAnnotationSublayer)
                        {
                            return;
                        }
                        else
                        {
                            pMoveLayer = pLayer;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }
        #endregion
    }
}