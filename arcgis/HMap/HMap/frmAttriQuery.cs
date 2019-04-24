using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
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
    public partial class frmAttriQuery : Form
    {
        private string strWhereClause;
        private IFeatureSelection pFeatureSelection; //用来记录最终的结果

        public frmAttriQuery()
        {
            InitializeComponent();
        }

        private void FrmAttriQuery_Load(object sender, EventArgs e)
        {
            //使用自定义的函数向图层列表控件comboBoxLayers填充图层名称
            AddAllLayerstoComboBox(comboBoxLayers);
            if (comboBoxLayers.Items.Count != 0)
            {
                comboBoxLayers.SelectedIndex = 0;
            }
            textBoxSQL.Text = "Select * From";
        }

        private void AddAllLayerstoComboBox(ComboBox combox)
        {
            try
            {
                combox.Items.Clear();

                int pLayerCount = mainForm.mainform.mainMapControl.LayerCount;
                if (pLayerCount > 0)
                {
                    combox.Enabled = true; //使下拉菜单可用 
                    for (int i = 0; i <= pLayerCount - 1; i++)
                    {
                        combox.Items.Add(mainForm.mainform.mainMapControl.get_Layer(i).Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); return;
            }
        }

        private void BtnBuildSQL_Click(object sender, EventArgs e)
        {
            string layerName = comboBoxLayers.Text;
            string fieldName = comboBoxFields.Text;
            string ope = txtOperator.Text;
            string value = textBoxValue.Text;
            textBoxSQL.Text = "Select * From";
            if (layerName == "" || fieldName == "" || ope == "" || value == "")
            {
                MessageBox.Show("构建查询条件失败！");
                return;
            }
            strWhereClause = fieldName + " " + ope + " " + value;
            string strSQL = "Select * From" + " " + layerName + " Where " + strWhereClause;
            textBoxSQL.Text = strSQL;
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (textBoxSQL.Text == "Select * From")
            {
                MessageBox.Show("请生成查询语句！");
                return;
            }
            this.WindowState = FormWindowState.Minimized; //查询窗口最小化
            PerformAttributeSelect(); //自定义的查询函数，见下页
            this.WindowState = FormWindowState.Normal;
        }

        private void PerformAttributeSelect()
        {
            try
            {
                IQueryFilter pQueryFilter = new QueryFilterClass();
                IFeatureLayer pFeatureLayer;
                pQueryFilter.WhereClause = strWhereClause;
                pFeatureLayer = GetLayerByName(comboBoxLayers.SelectedItem.ToString()) as IFeatureLayer;
                pFeatureSelection = pFeatureLayer as IFeatureSelection;
                pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                //如果本次查询后，查询的结果数目0，则认为本次查询不到结果 
                if (pFeatureSelection.SelectionSet.Count == 0)
                {
                    MessageBox.Show("没有符合本次查询条件的结果！");
                    return;
                }
                //定位到选择结果 
                IEnumFeature pEnumFeature = mainForm.mainform.mainMapControl.Map.FeatureSelection as IEnumFeature;
                IFeature pFeature = pEnumFeature.Next();
                IEnvelope pEnvelope = new EnvelopeClass() as IEnvelope;
                while (pFeature != null)
                {
                    pEnvelope.Union(pFeature.Extent);
                    pFeature = pEnumFeature.Next();
                }
                mainForm.mainform.mainMapControl.ActiveView.Extent = pEnvelope;
                mainForm.mainform.mainMapControl.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("您的查询语句可能有误,请检查| " + ex.Message);
                return;
            }
        }
        //自定义的方法，通过名称找到图层
        private ILayer GetLayerByName(string strLayerName)
        {
            ILayer pLayer = null;
            for (int i = 0; i <= mainForm.mainform.mainMapControl.LayerCount - 1; i++)
            {
                if (strLayerName == mainForm.mainform.mainMapControl.get_Layer(i).Name)
                {
                    pLayer = mainForm.mainform.mainMapControl.get_Layer(i);
                    break;
                }
            }
            return pLayer;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string strSelectedFieldName = comboBoxFields.Text;
            listBoxValues.Items.Clear();
            IFeatureCursor pFeatureCursor;
            IFeatureClass pFeatureClass;
            IFeature pFeature;
            double i = 0;
            //记录总数 
            if (strSelectedFieldName != null)
            {
                ILayer pLayer = GetLayerByName(comboBoxLayers.Text);
                IFeatureLayer pFLayer = pLayer as IFeatureLayer;
                pFeatureClass = pFLayer.FeatureClass;
                pFeatureCursor = pFeatureClass.Search(null, true);
                pFeature = pFeatureCursor.NextFeature();

                int index = pFeatureClass.FindField(strSelectedFieldName);
                while (pFeature != null)
                {
                    i++;
                    string strValue = pFeature.get_Value(index).ToString();
                    if (pFeature.Fields.get_Field(index).Type == esriFieldType.esriFieldTypeString)
                    {
                        strValue = "'" + strValue + "'";
                    }
                    if (listBoxValues.FindStringExact(strValue) == ListBox.NoMatches)
                    {
                        listBoxValues.Items.Add(strValue);
                    }
                    pFeature = pFeatureCursor.NextFeature();
                }
            }
        }

        private void ComboBoxLayers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxFields.Items.Clear();
            listBoxValues.Items.Clear();
            string strSelectedLayerName = comboBoxLayers.Text; IFeatureLayer pFeatureLayer;

            IDisplayTable pDisPlayTable;
            try
            {
                for (int i = 0; i <= mainForm.mainform.mainMapControl.LayerCount - 1; i++)
                {
                    if (mainForm.mainform.mainMapControl.get_Layer(i).Name == strSelectedLayerName)
                    {
                        if (mainForm.mainform.mainMapControl.get_Layer(i) is IFeatureLayer)
                        {
                            pFeatureLayer = mainForm.mainform.mainMapControl.get_Layer(i) as IFeatureLayer;
                            pDisPlayTable = pFeatureLayer as IDisplayTable;

                            for (int j = 0; j <= pDisPlayTable.DisplayTable.Fields.FieldCount - 1; j++)
                            {
                                comboBoxFields.Items.Add(pDisPlayTable.DisplayTable.Fields.get_Field(j).Name);
                            }
                        }
                        else
                        {
                            MessageBox.Show("图层无法进行属性查询!请重选");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void ListBoxValues_SelectedValueChanged(object sender, EventArgs e)
        {
            textBoxValue.Text = listBoxValues.SelectedItem.ToString();
        }
    }
}