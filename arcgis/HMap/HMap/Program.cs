using System;
using System.Windows.Forms;

namespace HMap
{
    internal static class Program
    {
        /// <summary>        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {//使用系统自带符号选择器使用上面的
            //ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
}