using ESRI.ArcGIS.Carto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MapOperation
{
    public partial class FormManageBookMarks : Form
    {
        private IMap _currentMap = null;
        private Dictionary<string, ISpatialBookmark> pDictionary = new Dictionary<string, ISpatialBookmark>();
        private IMapBookmarks mapBookmarks = null;

        public FormManageBookMarks(IMap pMap)
        {
            InitializeComponent();
            _currentMap = pMap;    //获取当前地图
            InitControl();
        }

        //获取空间书签，对tlstBookMark进行初始化
        private void InitControl()
        {
            mapBookmarks = _currentMap as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmarks = mapBookmarks.Bookmarks;
            enumSpatialBookmarks.Reset();
            ISpatialBookmark pSpatialBookmark = enumSpatialBookmarks.Next();

            string sBookMarkName = string.Empty;
            while (pSpatialBookmark != null)
            {
                sBookMarkName = pSpatialBookmark.Name;
                //增加树节点
                tviewBookMark.Nodes.Add(sBookMarkName);
                //添加到数据字典
                pDictionary.Add(sBookMarkName, pSpatialBookmark);
                pSpatialBookmark = enumSpatialBookmarks.Next();
            }
        }

        //定位
        private void btnLocate_Click(object sender, EventArgs e)
        {
            TreeNode pSelectedNode = tviewBookMark.SelectedNode;
            //获得选中的书签对象
            ISpatialBookmark pSpatialBM = pDictionary[pSelectedNode.Text];
            //缩放到选中书签的视图范围
            pSpatialBM.ZoomTo(_currentMap);
            IActiveView pActiveView = _currentMap as IActiveView;
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
        }

        //删除书签
        private void BtnDelete_Click_1(object sender, EventArgs e)
        {
            TreeNode pSelectedNode = tviewBookMark.SelectedNode;
            ISpatialBookmark pSpatialBookmark = pDictionary[pSelectedNode.Text];
            //删除选中的书签对象
            mapBookmarks.RemoveBookmark(pSpatialBookmark);
            //删除字典中数据
            pDictionary.Remove(pSelectedNode.Text);
            //删除树节点
            tviewBookMark.Nodes.Remove(pSelectedNode);
            tviewBookMark.Refresh();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}