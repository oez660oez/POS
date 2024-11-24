using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace IceShop
{
    internal class GlobalVar
    {
        public static string OrderingInfo = "";
        public static List<int> listChooseCategory = new List<int>();
        public static List<int> listShavedSnowAllId = new List<int>();
        public static List<ArrayList> listOrderItemCollect = new List<ArrayList>();
        public static string image_dir = Path.Combine(
            Application.StartupPath, "source"
        );
        public static string strDBConnectionString = "";
        public static SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        static GlobalVar()
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "myIceShop";
            scsb.IntegratedSecurity = true;
            strDBConnectionString = scsb.ConnectionString.ToString();
        }

        //檢查圖片資料夾
        private static void SetupImageDirectory()
        {
            // 取得應用程式執行檔所在路徑
            string basePath = Application.StartupPath;
            image_dir = Path.Combine(basePath, "source");

            // 確保資料夾存在
            if (!Directory.Exists(image_dir))
            {
                try
                {
                    Directory.CreateDirectory(image_dir);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"無法建立圖片資料夾: {ex.Message}", "錯誤",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //會員登入區
        public static bool isLoginSuccess = false;
        public static string UserName = "";
        public static int UserID = 0;
        public static int UserAuthority = 0;
        //public static int UserRole = 0;//會員:2, 員工:1
    }
}
