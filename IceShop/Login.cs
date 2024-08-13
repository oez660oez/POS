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
    public partial class Login : Form
    {
        private string placeholderUsername = "請輸入帳號";
        private string placeholderPassword = "請輸入密碼";
        public Login()
        {
            InitializeComponent();
            SetPlaceholder(txtUserName, placeholderUsername);
            SetPlaceholder(txtPassword, placeholderPassword);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Properties.Settings.Default.SavedUsername))
            {
                txtUserName.Text = Properties.Settings.Default.SavedUsername;
                txtUserName.ForeColor = SystemColors.WindowText;
                txtUserName.Font = new Font(txtUserName.Font, FontStyle.Regular);
                chkRememberme.Checked = true;
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

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string strUserName = txtUserName.Text.Trim();
                string strPassWord = txtPassword.Text.Trim();

                if ((strUserName != "") && (strPassWord != ""))
                {
                    SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                    con.Open();

                    string strSQL = $"select * from Customer where Username = @SearchUsername and Password = @SearchPassword";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchUsername", strUserName);
                    cmd.Parameters.AddWithValue("@SearchPassword", strPassWord);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // true，用if是因為理論一次只有一人登入
                    {
                        // 登入成功
                        GlobalVar.isLoginSuccess = true;
                        GlobalVar.UserID = (int)reader["CustomerId"]; // 假設資料表中客戶ID的欄位名為CustomerId
                        GlobalVar.UserName = reader["Name"].ToString();
                        GlobalVar.UserAuthority = (int)reader["UserAuthority"]; // 1-10:admin，11-20:店長，21-30:店員，101-200:會員，0:訪客
                        MessageBox.Show("登入成功");
                        reader.Close();
                        con.Close();
                        if (GlobalVar.UserAuthority == 3)
                        {
                            Form1 form1 = new Form1();
                            form1.Show(); // 使用 Show 而不是 ShowDialog
                        }
                        else
                        {
                            ProductBackend BackendSystem = new ProductBackend();
                            BackendSystem.Show(); // 使用 Show 而不是 ShowDialog
                        }

                        this.Hide();
                    }
                    if (GlobalVar.isLoginSuccess == false)//false
                    {
                        MessageBox.Show("登入資料有誤，請重新登入");
                    }
                    // 保存用户名
                    if (chkRememberme.Checked)
                    {
                        Properties.Settings.Default.SavedUsername = strUserName;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.SavedUsername = "";
                        Properties.Settings.Default.Save();
                    }

                    reader.Close();
                    con.Close();


                }
                else
                {
                    MessageBox.Show("登入欄必填！！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("出現錯誤: " + ex.Message);
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalVar.isLoginSuccess)
            {
                //登入成功

            }
            else
            {
                e.Cancel = true; //取消關閉事件
            }
        }
        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = placeholderText;
                textBox.ForeColor = Color.Gray;
                textBox.Font = new Font(textBox.Font, FontStyle.Italic);
                if (textBox == txtPassword)
                {
                    txtPassword.PasswordChar = '\0'; // 清除 PasswordChar
                }
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
                textBox.Font = new Font(textBox.Font, FontStyle.Regular);
                if (textBox == txtPassword)
                {
                    txtPassword.PasswordChar = '*'; // 设置 PasswordChar
                }
            }
        }

        private void txtUserName_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtUserName, placeholderUsername);
        }

        private void txtUserName_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(txtUserName, placeholderUsername);
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(txtPassword, placeholderPassword);
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            SetPlaceholder(txtPassword, placeholderPassword);
        }

        private void chkRememberme_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show(); // 使用 Show 而不是 ShowDialog
            this.Hide();
        }
    }
}
