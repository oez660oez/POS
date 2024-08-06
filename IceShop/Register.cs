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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private void Register_Load(object sender, EventArgs e)
        {
            radioMemberLogin.Checked = true;
        }
        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlFormTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point loc1 = MousePosition;
                Location = loc1;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((txtName.Text != "") && (txtPhone.Text != "") && (txtEmail.Text != ""))
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "INSERT INTO Customer (Name, Phone, Address, Email, Birth, MaritalStatus, Username, Password) VALUES (@NewName, @NewPhone, @NewAddress, @NewEmail, @NewBirth, @NewMarital, @Username, @Password);";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                //新增資料不用ID
                cmd.Parameters.AddWithValue("@NewName", txtName.Text);
                cmd.Parameters.AddWithValue("@NewPhone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@NewAddress", txtAddress.Text);
                cmd.Parameters.AddWithValue("@NewEmail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@NewBirth", dtpBirth.Value);
                cmd.Parameters.AddWithValue("@NewMarital", chkMarry.Checked);
                cmd.Parameters.AddWithValue("@Username", txtUserName.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                int rows = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"資料新增成功，{rows} 列資料受影響。");
                Login login = new Login();
                login.Show(); // 使用 Show 而不是 ShowDialog
                this.Hide();
            }
            else
            {
                MessageBox.Show("欄位資料不齊全");
            }
        }
    }
}
