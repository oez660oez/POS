using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IceShop
{
    internal class GlobalVar
    {
        public static string OrderingInfo = "";
        public static List<int> listChooseCategory = new List<int>();
        public static List<int> listShavedSnowAllId = new List<int>();
        public static List<ArrayList> listOrderItemCollect = new List<ArrayList>();
        //C:\Users\iSpan\Desktop\Code\LiYuan\C#_AdoDotNet\Practice\20240730_ListView\Source
        public static string image_dir = @"C:\Users\LiYuan\Desktop\期中專題\source";
        //public static string image_dir = @"C:\Users\ISpan\Desktop\期中專題\source";
        public static string strDBConnectionString = "";
        public static SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

        static GlobalVar()
        {
            scsb.DataSource = @".";
            scsb.InitialCatalog = "myIceShop";
            scsb.IntegratedSecurity = true;
            strDBConnectionString = scsb.ConnectionString.ToString();
        }

        //會員登入區
        public static bool isLoginSuccess = false;
        public static string UserName = "";
        public static int UserID = 0;
        public static int UserAuthority = 0;
        public static int UserRole = 0;//會員:2, 員工:1
    }
}
