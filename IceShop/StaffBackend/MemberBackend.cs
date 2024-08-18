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
    public partial class MemberBackend : Form
    {
        
        List<int> SearchIDs = new List<int>();//搜尋結果
        int selectId = 0;
        public MemberBackend()
        {
            InitializeComponent();
        }

        private void OrderBackend_Load(object sender, EventArgs e)
        {
            radioMaritalStatusAll.Checked = true;
            cboxSearchCol.Items.Add("Name");
            cboxSearchCol.Items.Add("Phone");
            cboxSearchCol.Items.Add("Address");
            cboxSearchCol.Items.Add("Email");
            cboxSearchCol.Items.Add("CustomerId");
            cboxSearchCol.SelectedIndex = 0;

            lblSystemTime.Text = DateTime.Now.ToString();
            if (GlobalVar.UserAuthority == 2)
            {
                lblCategory.Text = "員工";
                btnDelete.Visible = false;
            }
            else if (GlobalVar.UserAuthority == 3)
            {
                lblCategory.Text = "會員";
                btnDelete.Visible = false;
            }
            else
            {
                lblCategory.Text = "店長";
                btnDelete.Visible = true;
            }
            lblUserName.Text = GlobalVar.UserName;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchKeyword.Text != "")
            {
                lboxSearchResult.Items.Clear();
                SearchIDs.Clear();

                string strColName = cboxSearchCol.SelectedItem.ToString();
                string sqlMaritalStatusCheckGrammar = "";//婚姻狀態查詢語法，假如不能用參數帶入的處理方式

                if (MaritalStatusSingle.Checked == true)
                {
                    sqlMaritalStatusCheckGrammar = "and (MaritalStatus = 0)";
                }
                else if (radioMaritalStatusMarried.Checked == true)
                {
                    sqlMaritalStatusCheckGrammar = "and (MaritalStatus = 1)";
                }
                else
                {
                    sqlMaritalStatusCheckGrammar = "";
                }

                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();

                string strSQL = $"select * from Customer where ({strColName} like @SearchKeyword) and (Birth > @StartBirth) and (Birth < @EndBirth) {sqlMaritalStatusCheckGrammar}";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchKeyword", $"%{txtSearchKeyword.Text.Trim()}%");
                cmd.Parameters.AddWithValue("@StartBirth", dtpStartTime.Value);
                cmd.Parameters.AddWithValue("@EndBirth", dtpEndTime.Value);
                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;
                while (reader.Read() == true)
                {
                    string strUserAuthority = "";
                    int UserAuthority = (int)reader["UserAuthority"];
                    if (UserAuthority == 3)
                    {
                        strUserAuthority = "會員";
                    }
                    else if (UserAuthority == 2)
                    {
                        strUserAuthority = "員工";
                    }
                    else
                    {
                        strUserAuthority = "店長";
                    }
                    lboxSearchResult.Items.Add($"編號:{reader["CustomerId"]} {reader["Name"]} 權限:{strUserAuthority}");
                    SearchIDs.Add((int)reader["CustomerId"]);//索引值對應(同while迴圈新增的關係)
                    count++;
                }
                if (count == 0)
                {
                    MessageBox.Show("查無此人");
                }
                reader.Close();
                con.Close();
            }
        }

        private void lboxSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxSearchResult.SelectedIndex >= 0)
            {
                selectId = SearchIDs[lboxSearchResult.SelectedIndex];
                MemberSearch(selectId);
            }
        }
        void MemberSearch(int myId)
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from Customer where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@CustomerId", selectId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                txtUserName.Text = (string)reader["Username"];
                txtPassword.Text = (string)reader["Password"];
                txtName.Text = (string)reader["Name"];
                txtPhone.Text = reader["Phone"].ToString();
                txtAddress.Text = reader["Address"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                dtpBirth.Value = (DateTime)reader["Birth"];
                chkMarry.Checked = (bool)reader["MaritalStatus"];
                int UserAuthority = (int)reader["UserAuthority"];
                if (UserAuthority == 3)
                {
                    radioMemberLogin.Checked = true;
                }
                else if (UserAuthority == 2)
                {
                    radioStaffLogin.Checked = true;
                }
                else
                {
                    radioManagerLogin.Checked = true;
                }
            }
            reader.Close();
            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
                StaffBackend StaffBackend = new StaffBackend();
                StaffBackend.Show();
                this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectId > 0)
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "delete from Customer where CustomerId = @DeleteId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@DeleteId", selectId);
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                txtUserName.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                dtpBirth.Value = DateTime.Now;
                chkMarry.Checked = false;
                radioMemberLogin.Checked = false;
                radioStaffLogin.Checked = false;
                radioManagerLogin.Checked = false;

                MessageBox.Show($"資料已刪除\n {rows}筆資料受影響");
            }
        }
    }
}
