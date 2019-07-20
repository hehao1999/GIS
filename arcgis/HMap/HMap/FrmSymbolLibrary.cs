using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
namespace HMap
{
    public partial class FrmSymbolLibrary : Form
    {
        private IStyleGalleryItem pStyleGalleryItem=null;
        private ILegendClass pLegendClass=null;
        private ILayer pLayer  =null;
        public ISymbol pSymbol=null;
        public Image pSymbolImage  =null;
        private bool contextMenuMoreSymbolInitiated = false;

        public FrmSymbolLibrary(ILegendClass tempLegendClass  , ILayer tempLayer  )
        {
            InitializeComponent();
            pLegendClass = tempLegendClass;
            pLayer = tempLayer;

        }

        private void FrmSymbolLibrary_Load(object sender, EventArgs e)
        {

            try
            {
                String sInstall = ReadRegistry(@"SOFTWARE\\ESRI\\Engine10.2");//不同的版本所在的目录也不同

               //Load the ESRI.ServerStyle file into the SymbologyControl
                axSymbologyControl1.LoadStyleFile(sInstall + @"\\Styles\\ESRI.ServerStyle");
            }
            catch (Exception)
            {
                
                throw;
            }

            //确定图层的类型(点线面),设置好SymbologyControl的StyleClass,设置好各控件的可见性(visible) 
            IGeoFeatureLayer pGeoFeatureLayer = (IGeoFeatureLayer)pLayer;
            switch (pGeoFeatureLayer.FeatureClass.ShapeType)
            {
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint:
                     SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassMarkerSymbols);
                    this.lblAngle.Visible = true;
                    this.nudAngle.Visible = true;
                    this.lblSize.Visible = true;
                    this.nudSize.Visible = true;
                    this.nudSize.Value = 10;
                    this.lblWidth.Visible = false;
                    this.nudWidth.Visible = false;
                    this.lblOutlineColor.Visible = false;
                    this.btnOutlineColor.Visible = false;
                    break;

                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolyline:
                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassLineSymbols);
                    this.lblAngle.Visible = false;
                    this.nudAngle.Visible = false;
                    this.lblSize.Visible = false;
                    this.nudSize.Visible =false;
                    this.lblWidth.Visible = true;
                    this.nudWidth.Visible = true;
                    this.nudWidth.Value = 1;
                    this.lblOutlineColor.Visible = false;
                    this.btnOutlineColor.Visible = false;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPolygon:
                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols);
                    this.lblAngle.Visible = false;
                    this.nudAngle.Visible = false;
                    this.lblSize.Visible = false;
                    this.nudSize.Visible = false;
                    this.lblWidth.Visible = true;
                    this.nudWidth.Visible = true;
                    this.nudWidth.Value = 1;
                    this.lblOutlineColor.Visible = true;
                    this.btnOutlineColor.Visible = true;
                    break;
                case ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryMultiPatch:
                    this.SetFeatureClassStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols);
                    this.lblAngle.Visible = false;
                    this.nudAngle.Visible = false;
                    this.lblSize.Visible = false;
                    this.nudSize.Visible = false;
                    this.lblWidth.Visible = true;
                    this.nudWidth.Visible = true;
                    this.nudWidth.Value = 1;
                    this.lblOutlineColor.Visible = true;
                    this.btnOutlineColor.Visible = true;
                    break;
                default:
                    break;

            }
        }

        private void SetFeatureClassStyle(esriSymbologyStyleClass symbologyStyleClass )
        {
 
           this.axSymbologyControl1.StyleClass = symbologyStyleClass;
            ISymbologyStyleClass pSymbologyStyleClass = this.axSymbologyControl1.GetStyleClass(symbologyStyleClass);
            if (pLegendClass != null)
            {
                IStyleGalleryItem currentStyleGalleryItem = new ServerStyleGalleryItem();
                currentStyleGalleryItem.Name = "当前符号";
                currentStyleGalleryItem.Item = pLegendClass.Symbol;

                pSymbologyStyleClass.AddItem(currentStyleGalleryItem, 0);
                pSymbologyStyleClass.SelectItem(0);
                pStyleGalleryItem = currentStyleGalleryItem;

                pSymbol = pStyleGalleryItem.Item as ISymbol;

            }

        }

        private String ReadRegistry(String sKey )
        {
            Microsoft.Win32.RegistryKey  rk  = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(sKey, false);
            if( rk ==null)
            {
                return "";
            }
            // Get the data from a specified item in the key. 
            return rk.GetValue("InstallDir").ToString();
        }

        private void axSymbologyControl1_OnDoubleClick(object sender, ISymbologyControlEvents_OnDoubleClickEvent e)
        {
            btnOk.PerformClick();
        }

        private void axSymbologyControl1_OnItemSelected(object sender, ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            pStyleGalleryItem = (IStyleGalleryItem)e.styleGalleryItem;
            Color color  ;
            switch(axSymbologyControl1.StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    color = this.ConvertIRgbColorToColor((IRgbColor)((IMarkerSymbol)(pStyleGalleryItem.Item)).Color);
                    break;
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    color = this.ConvertIRgbColorToColor((IRgbColor)((ILineSymbol)(pStyleGalleryItem.Item)).Color);
                    break;
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    color = this.ConvertIRgbColorToColor((IRgbColor)((IFillSymbol)(pStyleGalleryItem.Item)).Color);
                    this.btnOutlineColor.BackColor = this.ConvertIRgbColorToColor((IRgbColor)((IFillSymbol)(pStyleGalleryItem.Item)).Outline.Color);
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            btnColor.BackColor = color;
            PreviewImage();
        }

        //将ArcGIS Engine中的IRgbColor接口转换至.NET中的Color结构 
        private Color ConvertIRgbColorToColor(IRgbColor pRgbColor)
        {
            return ColorTranslator.FromOle(pRgbColor.RGB);
        }
        //将.NET中的Color结构转换至于ArcGIS Engine中的IColor接口 
        private IColor ConvertColorToIColor(Color color)
        {
            IColor pColor = new RgbColor();
            pColor.RGB = color.B * 65536 + color.G * 256 + color.R;
            return pColor;
        }

        private IRgbColor ConvertColorToIRgbColor(Color color)
        {
            IRgbColor pRgbColor   = new RgbColor();
            pRgbColor.RGB = color.B * 65536 + color.G * 256 + color.R;
           return pRgbColor;
        }

        private void PreviewImage()
        {
            stdole.IPictureDisp picture   = this.axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass).PreviewItem(pStyleGalleryItem, ptbPreview.Width, ptbPreview.Height);
            System.Drawing.Image image   = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            ptbPreview.Image = image;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
             //'pLegendClass.Symbol = (ISymbol)pStyleGalleryItem.Item; 
            pSymbol = (ISymbol)pStyleGalleryItem.Item;
            pSymbolImage = ptbPreview.Image;
            ISimpleRenderer pRender ;
            IGeoFeatureLayer pGeoFeatureLayer ;
            pGeoFeatureLayer = (IGeoFeatureLayer)pLayer;
            /////////////////////////////////////////////////////////////
            switch(axSymbologyControl1.StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    ISymbol pSMarkerSymbol;
                    pSMarkerSymbol = new SimpleMarkerSymbol() as ISymbol;
                    //pSMarkerSymbol
                    //pSMarkerSymbol.Color = ConvertColorToIColor(Me.btnColor.BackColor);
                    //pSMarkerSymbol.Size = CDbl(Me.nudSize.Value);
                    //pSMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                    //pSMarkerSymbol.Outline = true;
                    //pSMarkerSymbol.OutlineColor = Me.ConvertColorToIColor(Me.btnOutlineColor.BackColor)
                    //pSMarkerSymbol.OutlineSize = 2
                    pSMarkerSymbol = pSymbol;
                    pRender = new SimpleRenderer();
                    pRender.Symbol = pSMarkerSymbol;
                    pGeoFeatureLayer.Renderer = (IFeatureRenderer)pRender;

                   break;
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    ISymbol pSlineSymbol ;
                    pSlineSymbol = new SimpleLineSymbol() as ISymbol;
                   
                   //pSlineSymbol.Color = ConvertColorToIColor(btnColor.BackColor);
                   // pSlineSymbol.Width = CDbl(Me.nudWidth.Value);
                   //pSlineSymbol.Style = esriSimpleLineStyle.esriSLSDot;
                    
                    pSlineSymbol = pSymbol;
                    pRender = new SimpleRenderer();
                    pRender.Symbol = pSlineSymbol;
                    pGeoFeatureLayer.Renderer = (IFeatureRenderer)pRender;

                   break;
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    ISymbol pSFillSymbol ;
                    pSFillSymbol = new SimpleFillSymbol() as ISymbol;
                    //'Dim pOutLine As 
                    //'pOutLine = New SimpleLineSymbol
                    //'With pOutLine
                    //'    .Color = Me.ConvertColorToIColor(Me.btnOutlineColor.BackColor)
                    //'    .Width = CDbl(Me.nudWidth.Value)
                    //'    .Style = esriSimpleLineStyle.esriSLSDashDotDot
                    //'End With
                    //'With pSFillSymbol
                    //'    .Color = Me.ConvertColorToIColor(Me.btnColor.BackColor)
                    //'    .Style = esriSimpleFillStyle.esriSFSForwardDiagonal
                    //'    .Outline = pOutLine
                    //'End With
                    pSFillSymbol = pSymbol;
                    pRender = new SimpleRenderer() ;
                    pRender.Symbol = pSFillSymbol;
                    pGeoFeatureLayer.Renderer = (IFeatureRenderer)pRender;

                    break;
            }

            ///////////////////////////////////////////////////////////////
            this.Close();
        }

        private void btnOutlineColor_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog()== DialogResult.OK )
            {
                ILineSymbol pLineSymbol = ((IFillSymbol)(pStyleGalleryItem.Item)).Outline;
                pLineSymbol.Color = this.ConvertColorToIColor(this.colorDialog.Color);
                ((IFillSymbol)pStyleGalleryItem.Item).Outline = pLineSymbol;
                this.btnOutlineColor.BackColor = this.colorDialog.Color;
                this.PreviewImage();
            }
        }

        private void btnMoreSymbols_Click(object sender, EventArgs e)
        {
            if(contextMenuMoreSymbolInitiated==false)
            {
                String sInstall = ReadRegistry("SOFTWARE\\ESRI\\Engine10.2");
                String path   = System.IO.Path.Combine(sInstall, "Styles");
                String[]  styleNames = System.IO.Directory.GetFiles(path, "*.ServerStyle");
                ToolStripMenuItem[]  symbolContextMenuItem = new ToolStripMenuItem[styleNames.Length];
                for(int i  = 0 ;i< styleNames.Length - 1;i++)
                {
                    symbolContextMenuItem[i] = new ToolStripMenuItem();
                    symbolContextMenuItem[i].CheckOnClick = true;
                    symbolContextMenuItem[i].Text = System.IO.Path.GetFileNameWithoutExtension(styleNames[i]);
                    if( symbolContextMenuItem[i].Text == "ESRI" )
                    {
                        symbolContextMenuItem[i].Checked = true;
                    }
                    symbolContextMenuItem[i].Name = styleNames[i];
                    symbolContextMenuItem[i].Click += new EventHandler(this.symbolContextMenuItem_Click);

                }
                symbolContextMenuItem[styleNames.Length - 1] = new ToolStripMenuItem();
                symbolContextMenuItem[styleNames.Length - 1].Text = "更多符号";
                symbolContextMenuItem[styleNames.Length - 1].Click += new EventHandler(this.symbolContextMenuItemMoreSymbols_Click);
                contextMenuStripMoreSymbol.Items.AddRange(symbolContextMenuItem);
                contextMenuMoreSymbolInitiated = true;

             }

           this.contextMenuStripMoreSymbol.Show(btnMoreSymbols.Location);
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK )
            {
                btnColor.BackColor = colorDialog.Color;
                switch(axSymbologyControl1.StyleClass)
                {
                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                        ((IMarkerSymbol)pStyleGalleryItem.Item).Color = ConvertColorToIColor(colorDialog.Color);
                        break;
                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                        ((ILineSymbol)pStyleGalleryItem.Item).Color = ConvertColorToIColor(colorDialog.Color);
                        break;
                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                        ((IFillSymbol)pStyleGalleryItem.Item).Color = ConvertColorToIColor(colorDialog.Color);
                        break;
                }
                PreviewImage();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e)
        {
            if (pStyleGalleryItem == null)
            {
                return;
            }

            ((IMarkerSymbol)pStyleGalleryItem.Item).Size = (double)nudSize.Value;
            PreviewImage();
        }

        private void   symbolContextMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem pToolStripMenuItem = (ToolStripMenuItem)sender;
            //Load the style file into the SymbologyControl 
            if( pToolStripMenuItem.Checked == true )
            {
                axSymbologyControl1.LoadStyleFile(pToolStripMenuItem.Name);
                axSymbologyControl1.Refresh();
            }
            else
            {
                axSymbologyControl1.RemoveFile(pToolStripMenuItem.Name);
                axSymbologyControl1.Refresh();
            }
        }
        private void symbolContextMenuItemMoreSymbols_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem pToolStripMenuItem = (ToolStripMenuItem)sender;

            //Load the style file into the SymbologyControl 

            if (pToolStripMenuItem.Checked == true)
            {
                axSymbologyControl1.LoadStyleFile(pToolStripMenuItem.Name);

                axSymbologyControl1.Refresh();
            }
            else
            {

                axSymbologyControl1.RemoveFile(pToolStripMenuItem.Name);

                axSymbologyControl1.Refresh();
            }
      
        }

        private void nudWidth_ValueChanged(object sender, EventArgs e)
        {
            switch( axSymbologyControl1.StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    ((ILineSymbol)pStyleGalleryItem.Item ).Width = Convert.ToDouble(nudWidth.Value);
                    break;
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    ILineSymbol pLineSymbol = ((IFillSymbol)pStyleGalleryItem.Item).Outline;
                    pLineSymbol.Width = Convert.ToDouble(nudWidth.Value);
                    ((IFillSymbol)pStyleGalleryItem.Item).Outline = pLineSymbol;
                    break;
            }

            PreviewImage();
        }

        private void nudAngle_ValueChanged(object sender, EventArgs e)
        {
            ((IMarkerSymbol)pStyleGalleryItem.Item).Angle = Convert.ToDouble(nudAngle.Value);
            PreviewImage();
        }

        private void axSymbologyControl1_OnStyleClassChanged(object sender, ISymbologyControlEvents_OnStyleClassChangedEvent e)
        {
            object obj =e.symbologyStyleClass;//10.0后必须通过object对象的操作进行转换
            ISymbologyStyleClass symbolClass = obj as ISymbologyStyleClass;

            switch (symbolClass.StyleClass)
            {
               case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:

                lblAngle.Visible = true;

                nudAngle.Visible = true;

                lblSize.Visible = true;

                nudSize.Visible = true;

                lblWidth.Visible = false;

                nudWidth.Visible = false;

                lblOutlineColor.Visible = false;

                btnOutlineColor.Visible = false;

                break;
            case esriSymbologyStyleClass.esriStyleClassLineSymbols:

                lblAngle.Visible = false;

                nudAngle.Visible = false;

                lblSize.Visible = false;

                nudSize.Visible = false;

                lblWidth.Visible = true;

                nudWidth.Visible = true;

                lblOutlineColor.Visible = false;

                btnOutlineColor.Visible = false;

               break;

            case esriSymbologyStyleClass.esriStyleClassFillSymbols:

                lblAngle.Visible = false;

                nudAngle.Visible = false;

                lblSize.Visible = false;

                nudSize.Visible = false;

                lblWidth.Visible = true;

                nudWidth.Visible = true;

                lblOutlineColor.Visible = true;

                btnOutlineColor.Visible = true;

               break;
            }

 

        }

        private void axSymbologyControl1_OnMouseDown(object sender, ISymbologyControlEvents_OnMouseDownEvent e)
        {

        }
 
    }
}
