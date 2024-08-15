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
    public partial class StaffBackend : Form
    {
        public StaffBackend()
        {
            InitializeComponent();
        }

        private void StaffBackend_Load(object sender, EventArgs e)
        {
            if (GlobalVar.UserAuthority == 2)
            {
                btnCalculateMoney.Visible = false;
            }
            else if (GlobalVar.UserAuthority == 3)
            {
                btnCalculateMoney.Visible = false;
            }
            else
            {
                btnCalculateMoney.Visible = true;
            }
        }
        private void pnlFormTitle_MouseMove(object sender, MouseEventArgs e)
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

        private void btnMemberModify_Click(object sender, EventArgs e)
        {
            MemberBackend MemberBackend = new MemberBackend();
            MemberBackend.Show();
            this.Hide();
        }

        private void btnProductAddModify_Click(object sender, EventArgs e)
        {
            ProductBackend BackendSystem = new ProductBackend();
            BackendSystem.Show(); // 使用 Show 而不是 ShowDialog
            this.Hide();
        }

        private void btnChooseMemberOrder_Click(object sender, EventArgs e)
        {
            OrderBackend OrderBackend = new OrderBackend();
            OrderBackend.Show();
            this.Hide();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void btnCalculateMoney_Click(object sender, EventArgs e)
        {
            CalculateMoney CalculateMoney = new CalculateMoney();
            CalculateMoney.Show();
            this.Hide();
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            if (GlobalVar.UserAuthority == 2)
            {
                using (SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString))
                {
                    con.Open();

                    // 查詢當天是否已有打卡記錄
                    string strSQL = @"
            SELECT ClockStartTime, ClockEndTime 
            FROM Clock 
            WHERE CustomerId = @CustomerId 
            AND CAST(ClockStartTime AS DATE) = CAST(GETDATE() AS DATE)";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // 已經有上班打卡紀錄，檢查下班打卡
                        if (reader["ClockEndTime"] == DBNull.Value)
                        {
                            // 更新下班打卡時間
                            reader.Close();
                            strSQL = @"
                    UPDATE Clock 
                    SET ClockEndTime = GETDATE() 
                    WHERE CustomerId = @CustomerId 
                    AND CAST(ClockStartTime AS DATE) = CAST(GETDATE() AS DATE)";
                            cmd = new SqlCommand(strSQL, con);
                            cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("今天下班打卡成功");
                        }
                        else
                        {
                            // 今日已完成上下班打卡
                            MessageBox.Show("今日已經打卡過，不需重複打卡");
                        }
                    }
                    else
                    {
                        // 沒有上班打卡記錄，新增打卡記錄
                        reader.Close();
                        strSQL = @"
                INSERT INTO Clock (CustomerId, Name, ClockStartTime) 
                VALUES (@CustomerId, @Name, GETDATE())";
                        cmd = new SqlCommand(strSQL, con);
                        cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
                        cmd.Parameters.AddWithValue("@Name", GlobalVar.UserName); // 假設你有一個全域變數存放使用者名稱
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("今天上班打卡成功");
                    }
                    reader.Close();
                    con.Close();
                }
            }
            else if (GlobalVar.UserAuthority == 1) // 管理員檢查
            {
                using (SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString))
                {
                    con.Open();

                    // 查詢所有 UserAuthority 為 2 (員工) 的用戶
                    string strSQL = @"
            SELECT CU.CustomerId, CU.Name, ClockStartTime, ClockEndTime 
            FROM Customer AS CU
            LEFT JOIN Clock AS C ON CU.CustomerId = C.CustomerId
            AND CAST(ClockStartTime AS DATE) = CAST(GETDATE() AS DATE)
            WHERE CU.UserAuthority = 2";

                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> notClockedIn = new List<string>();
                    List<string> notClockedOut = new List<string>();

                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();

                        if (reader["ClockStartTime"] == DBNull.Value)
                        {
                            // 尚未上班打卡
                            notClockedIn.Add(name);
                            // 如果沒有上班打卡，也算是下班沒打卡
                            notClockedOut.Add(name);
                        }
                        else if (reader["ClockEndTime"] == DBNull.Value)
                        {
                            // 尚未下班打卡
                            notClockedOut.Add(name);
                        }
                    }
                    reader.Close();
                    con.Close();

                    // 顯示尚未上班打卡的員工
                    if (notClockedIn.Count > 0)
                    {
                        MessageBox.Show("尚未上班打卡的員工: " + string.Join(", ", notClockedIn));
                    }
                    else
                    {
                        MessageBox.Show("所有員工均已上班打卡。");
                    }

                    // 顯示尚未下班打卡的員工
                    if (notClockedOut.Count > 0)
                    {
                        MessageBox.Show("尚未下班打卡的員工: " + string.Join(", ", notClockedOut));
                    }
                    else
                    {
                        MessageBox.Show("所有員工均已下班打卡。");
                    }
                }
            }
        }
    }
}
