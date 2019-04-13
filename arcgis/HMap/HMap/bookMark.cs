using ESRI.ArcGIS.Carto;
using System;
using System.Windows.Forms;

namespace HMap
{
    public partial class bookMark : Form
    {
        public bookMark()
        {
            InitializeComponent();
        }

        //关闭
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //添加书签
        private void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text)) return;

            //书签进行重名判断
            IMapBookmarks mapBookmarks = mainForm.mainform.mainMapControl.Map as IMapBookmarks;
            IEnumSpatialBookmark enumSpatialBookmarks = mapBookmarks.Bookmarks;
            enumSpatialBookmarks.Reset();
            ISpatialBookmark pSpatialBookmark;

            while ((pSpatialBookmark = enumSpatialBookmarks.Next()) != null)
            {
                if (this.textBox1.Text == pSpatialBookmark.Name)
                {
                    DialogResult dr = MessageBox.Show("此书签名已存在！是否替换？", "提示", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        mapBookmarks.RemoveBookmark(pSpatialBookmark);
                    }
                    else if (dr == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            //获取当前地图的对象
            IActiveView pActiveView = mainForm.mainform.mainMapControl.Map as IActiveView;
            //创建一个新的书签并设置其位置范围为当前视图的范围
            IAOIBookmark pBookmark = new AOIBookmarkClass();
            pBookmark.Location = pActiveView.Extent;
            //获得书签名
            pBookmark.Name = this.textBox1.Text;
            //通过IMapBookmarks接口访问当前地图书签集，添加书签到地图的书签集中
            IMapBookmarks pMapBookmarks = mainForm.mainform.mainMapControl.Map as IMapBookmarks;
            pMapBookmarks.AddBookmark(pBookmark);
            this.Close();
        }
    }
}