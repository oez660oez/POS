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
        private ComboBox comboBoxReportType;
        private Label lblStart;
        private Label lblEnd;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerateReport;
        private DataGridView dgvReport;
        public CalculateMoney()
        {
            // 設定表單標題和尺寸
            this.Text = "營業額報告";
            this.Size = new System.Drawing.Size(600, 400);

            // 初始化UI元件
            comboBoxReportType = new ComboBox();
            lblStart = new Label();
            lblEnd = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            btnGenerateReport = new Button();
            dgvReport = new DataGridView();

            // 設定 ComboBox (報告類型)
            comboBoxReportType.Items.AddRange(new string[] { "Year", "Month", "Day", "Custom" });
            comboBoxReportType.Location = new System.Drawing.Point(20, 20);
            comboBoxReportType.SelectedIndex = 0; // 預設選擇第一個項目
            //新增給日期的字，開始與結束
            lblStart.Text = "從";
            lblStart.BackColor = Color.Transparent;
            lblStart.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
            lblStart.ForeColor = Color.FromArgb(0, 0, 51);
            lblStart.Location = new System.Drawing.Point(20, 60);
            lblEnd.Text = "到";
            lblEnd.BackColor = Color.Transparent;
            lblEnd.Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold);
            lblEnd.ForeColor = Color.FromArgb(0, 0, 51);
            lblEnd.Location = new System.Drawing.Point(270, 60);
            // 設定 DateTimePickers (開始日期和結束日期)
            dtpStartDate.Location = new System.Drawing.Point(50, 60);
            dtpEndDate.Location = new System.Drawing.Point(300, 60);

            // 設定 Button (生成報告)
            btnGenerateReport.Text = "生成報告";
            btnGenerateReport.Location = new System.Drawing.Point(20, 100);
            btnGenerateReport.Click += new EventHandler(btnGenerateReport_Click);

            // 設定 DataGridView (顯示報告)
            dgvReport.Location = new System.Drawing.Point(20, 140);
            dgvReport.Size = new System.Drawing.Size(540, 200);

            // 將UI元件加入表單
            this.Controls.Add(comboBoxReportType);
            this.Controls.Add(dtpStartDate);
            this.Controls.Add(dtpEndDate);
            this.Controls.Add(btnGenerateReport);
            this.Controls.Add(dgvReport);
            this.Controls.Add(lblStart);
            this.Controls.Add(lblEnd);
        }
        private void CalculateMoney_Load(object sender, EventArgs e)
        {

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

        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new CalculateMoney());
        //}
    }
}
