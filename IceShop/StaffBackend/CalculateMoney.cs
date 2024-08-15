using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceShop
{
    public partial class CalculateMoney : Form
    {
        
        
        
        
        public CalculateMoney()
        {
            InitializeComponent(); // 初始化 UI 元件
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point loc1 = MousePosition;
                Location = loc1;
            }
        }
        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CalculateMoney_Load(object sender, EventArgs e)
        {
            // 設定 ComboBox (報告類型)
            comboBoxReportType.Items.Add("Year");
            comboBoxReportType.Items.Add("Month");
            comboBoxReportType.Items.Add("Day");
            comboBoxReportType.Items.Add("Custom");
            comboBoxReportType.SelectedIndex = 0; // 預設選擇第一個項目
        }
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = comboBoxReportType.SelectedItem.ToString();
            string sqlQuery = "";

            switch (reportType)
            {
                case "Year":
                    sqlQuery = "SELECT YEAR(OrderDate) AS Year, SUM(TotalAmount) AS TotalRevenue FROM \"Order\" GROUP BY YEAR(OrderDate) ORDER BY Year;";
                    break;
                case "Month":
                    sqlQuery = "SELECT YEAR(OrderDate) AS Year, MONTH(OrderDate) AS Month, SUM(TotalAmount) AS TotalRevenue FROM \"Order\" GROUP BY YEAR(OrderDate), MONTH(OrderDate) ORDER BY Year, Month;";
                    break;
                case "Day":
                    sqlQuery = "SELECT YEAR(OrderDate) AS Year, MONTH(OrderDate) AS Month, DAY(OrderDate) AS Day, SUM(TotalAmount) AS TotalRevenue FROM \"Order\" GROUP BY YEAR(OrderDate), MONTH(OrderDate), DAY(OrderDate) ORDER BY Year, Month, Day;";
                    break;
                case "Custom":
                    sqlQuery = "SELECT SUM(TotalAmount) AS TotalRevenue FROM \"Order\" WHERE OrderDate BETWEEN @StartDate AND @EndDate;";
                    break;
            }

            using (SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                if (reportType == "Custom")
                {
                    cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                    cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                // 建立 DataTable 來存放查詢結果
                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);

                // 將查詢結果顯示在 DataGridView 中
                dgvReport.DataSource = dt;

                reader.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StaffBackend StaffBackend = new StaffBackend();
            StaffBackend.Show();
            this.Hide();
        }
    }
}
