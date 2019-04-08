using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using System;

namespace HMap
{
    public partial class mainForm : System.Windows.Forms.Form
    {
        //初始化
        public static mainForm mainform;  //实例化窗体
        public static CustomizeDialog m_CustomizeDialog; //自定义控件绑定
        int flag = 0; //工具标志

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
            m_CustomizeDialog.StartDialog(axToolbarControl1.hWnd);
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
        
        //放大按钮按下
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;
            baseOrder.zoom_in();
        }
        
        //缩小按钮按下
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;
            baseOrder.zoom_out();
        }

        //全图按钮按下
        private void fullExtentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 0;
            baseOrder.full_view();
        }

        //拉框选择按钮按下
        private void boxSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = 1;
        }

        //拉框选择
        private void mainMapControl_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if(flag == 1)
                baseOrder.box_select(e);
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

        private void addRasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            baseOrder.add_raster();
        }

        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {

        }
    }
}