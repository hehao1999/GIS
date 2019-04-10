using ESRI.ArcGIS.Carto;
using System;
using System.Windows.Forms;

namespace HMap
{
    public partial class layerManageForm : Form
    {
        public layerManageForm()
        {
            InitializeComponent();
        }
        
        private void layerManageForm_Load(object sender, EventArgs e)
        {
            //读入图层名
            ILayer lyr;
            listBox1.Items.Clear();
            if (mainForm.mainform.mainMapControl.LayerCount > 0)
            {
                IEnumLayer pMapLayers;
                pMapLayers = mainForm.mainform.mainMapControl.Map.get_Layers(null, true);

                //遍历Layers
                lyr = pMapLayers.Next(); while (lyr != null)
                {
                    listBox1.Items.Add(lyr.Name); lyr = pMapLayers.Next();
                }
            }
        }

        //添加图层
        private void add_btn_Click(object sender, EventArgs e)
        {
            baseOrder.add_layer();
            baseOrder.SynchronizeEagleEye();
            layerManageForm_Load(sender, e);
            this.Refresh();
        }

        //删除图层
        private void delbtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                mainForm.mainform.mainMapControl.DeleteLayer(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                mainForm.mainform.mainMapControl.Update();
                baseOrder.SynchronizeEagleEye();
            }
        }

        //上移图层
        private void upbtn_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > 0)
            {
                int i;
                i = listBox1.SelectedIndex;
                mainForm.mainform.mainMapControl.MoveLayerTo(i, i - 1);
                //地图刷新
                mainForm.mainform.mainMapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                mainForm.mainform.mainMapControl.Update();
                //list控件内的两个元素位置交换
                String tstring = listBox1.Items[i].ToString();
                listBox1.Items[i] = listBox1.Items[i - 1].ToString();
                listBox1.Items[i - 1] = tstring;
                listBox1.SelectedIndex = i - 1;
            }
            baseOrder.SynchronizeEagleEye();
        }

        //清空图层
        private void clearbtn_Click(object sender, EventArgs e)
        {
            baseOrder.clear_layers();
            baseOrder.SynchronizeEagleEye();
            listBox1.Items.Clear();
        }

        //下移图层
        private void downbtn_Click(object sender, EventArgs e)
        {
            //判断选中图层使否可移动
            if (listBox1.SelectedIndex < listBox1.Items.Count - 1 && listBox1.SelectedIndex > -1)
            {
                int i = listBox1.SelectedIndex;
                mainForm.mainform.mainMapControl.MoveLayerTo(i, i + 1);

                //地图刷新
                mainForm.mainform.mainMapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                mainForm.mainform.mainMapControl.Update();

                //list控件内的两个元素位置交换
                String tstring = listBox1.Items[i].ToString();
                listBox1.Items[i] = listBox1.Items[i + 1].ToString();
                listBox1.Items[i + 1] = tstring;
                listBox1.SelectedIndex = i + 1;
            }
        }
    }
}