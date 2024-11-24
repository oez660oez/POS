using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IceShop
{
    public partial class CustomBackend : Form
    {
        List<int> SearchIDs = new List<int>();//搜尋結果
        int selectId = 0;
        private Panel productPanel;
        public CustomBackend()
        {
            InitializeComponent();
            productPanel = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(297, 114),
                Size = new Size(1203, 701),
                BackColor = Color.Transparent,
                AutoScroll = true
            };
            this.Controls.Add(productPanel);
        }
        private void BackendSystem_Load(object sender, EventArgs e)
        {
            pnlShowMember.Visible = false;
            LoadLoginData();
        }
        private void BackendSystem_Activated(object sender, EventArgs e)
        {
            LoadLoginData();
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
        void LoadLoginData()
        {
            lblSystemTime.Text = DateTime.Now.ToString();
            if (GlobalVar.UserAuthority == 2)
            {
                lblCategory.Text = "員工";
            }
            else if (GlobalVar.UserAuthority == 3)
            {
                lblCategory.Text = "會員";
            }
            else
            {
                lblCategory.Text = "店長";
            }
            lblUserName.Text = GlobalVar.UserName;
        }
        private void btnMemberSearchPicture_Click(object sender, EventArgs e)
        {
            btnMemberSearchPicture.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\會員資料查詢02.png");
            btnSearchOrder.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\訂單查詢01.png");
            lboxSearchResult.Items.Clear();
            pnlShowMember.Visible = true;
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from Customer where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
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
            lblOrderNumber.Text = "";
            lblOrderTime.Text = "";
            lblOrderPurchaser.Text = "";
            lblTotalMoney.Text = "";
            lblProductItemCount.Text = "";
            reader.Close();
            con.Close();
        }

        private void btnSearchOrder_Click(object sender, EventArgs e)
        {
            pnlShowMember.Visible = false;
            lboxSearchResult.Items.Clear();
            btnSearchOrder.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\訂單查詢02.png");
            btnMemberSearchPicture.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\會員資料查詢01.png");
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" where CustomerId = @CustomerId";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                lboxSearchResult.Items.Add($"{reader["OrderDate"]} {reader["TotalAmount"]}");
                SearchIDs.Add((int)reader["OrderNumber"]);
            }
            reader.Close();
            con.Close();
        }

        private void lboxSearchResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lboxSearchResult.SelectedIndex >= 0)
            {
                selectId = SearchIDs[lboxSearchResult.SelectedIndex];
                DisplayShoppingProduct(selectId);
            }
        }
        void DisplayMemberData()
        {

            Panel newPanel = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(297, 114),
                Size = new Size(1203, 701),
                BackColor = Color.Transparent,
                AutoScroll = true
            };

            this.Controls.Add(newPanel); // 確保將 newPanel 添加到 ShoppingCart 表單中
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" o RIGHT JOIN OrderItem oi on oi.OrderNumber = o.OrderNumber RIGHT JOIN Product p on oi.ProductId = p.ProductId where oi.OrderNumber = @OrderNumber;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@OrderNumber", selectId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                string itemName = (string)reader["ProductName"];
                string itemDescribe = (string)reader["ProductDescribe"];
                int Price = (int)reader["Price"];
                int count = (int)reader["Quantity"];
                int totalPrice = (int)reader["TotalAmount"];
                string flavor = (string)reader["Flavor"];
                string addIngredients = (string)reader["AddIngredients"];
            }
            reader.Close();
            con.Close();
        }
        private void dtpTime_ValueChanged(object sender, EventArgs e)
        {
            DateSearch();
        }
        void DateSearch()
        {
            lboxSearchResult.Items.Clear();  // 清空列表框

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" where CustomerId = @CustomerId and (OrderDate >= @StartBirth) and (OrderDate <= @EndBirth);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
            cmd.Parameters.AddWithValue("@StartBirth", dtpStartTime.Value);
            cmd.Parameters.AddWithValue("@EndBirth", dtpEndTime.Value);

            SqlDataReader reader = cmd.ExecuteReader();
            SearchIDs.Clear();  // 清空之前的搜尋結果
            while (reader.Read())
            {
                lboxSearchResult.Items.Add($"{reader["OrderDate"]} {reader["TotalAmount"]}");
                SearchIDs.Add((int)reader["OrderNumber"]);
            }

            reader.Close();
            con.Close();  // 關閉連線
        }
        void DisplayShoppingProduct(int myId)
        {
            int yOffset = 10; // 初始Y偏移
            int xOffset = 10; // 初始X偏移

            productPanel.Controls.Clear();

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" o RIGHT JOIN OrderItem oi on oi.OrderNumber = o.OrderNumber RIGHT JOIN Product p on oi.ProductId = p.ProductId where oi.OrderNumber = @OrderNumber;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@OrderNumber", selectId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() == true)
            {
                string itemName = (string)reader["ProductName"];
                string itemDescribe = (string)reader["ProductDescribe"];
                int Price = (int)reader["Price"];
                int count = (int)reader["Quantity"];
                int totalPrice = (int)reader["TotalAmount"];
                string flavor = (string)reader["Flavor"];
                string addIngredients = (string)reader["AddIngredients"];

                Label myLabelProductName = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 22, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset, yOffset),
                    Size = new Size(400, 40),
                    Text = itemName
                };

                Label myLabelProductDescribe = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 12, FontStyle.Bold),
                    ForeColor = Color.FromArgb(84, 84, 124),
                    Location = new Point(xOffset, yOffset + 40),
                    Size = new Size(600, 60),
                    Text = itemDescribe
                };

                Label myLabelFlavor = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(42, 42, 139),
                    Location = new Point(xOffset, yOffset + 100),
                    Size = new Size(600, 30),
                    Text = flavor
                };

                // 处理加料数量超过5个的情况
                string formattedAddIngredients = FormatAddIngredients(addIngredients);

                Label myLabelAddIngredients = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(42, 42, 139),
                    Location = new Point(xOffset, yOffset + 130),
                    Size = new Size(600, 60), // 调整大小以适应可能的多行
                    Text = formattedAddIngredients
                };

                Label myLabelPrice = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset + 500, yOffset + 90),
                    Text = "$" + Price.ToString()
                };

                Label myLabelCount = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset + 600, yOffset + 90),
                    Text = "X" + count.ToString()
                };

                Label myDivider = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset, yOffset + 200),
                    Size = new Size(600, 30),
                    Text = "----------------------------------------------"
                };

                productPanel.Controls.Add(myLabelProductName);
                productPanel.Controls.Add(myLabelProductDescribe);
                productPanel.Controls.Add(myLabelFlavor);
                productPanel.Controls.Add(myLabelAddIngredients);
                productPanel.Controls.Add(myLabelPrice);
                productPanel.Controls.Add(myLabelCount);
                productPanel.Controls.Add(myDivider);

                // Bring controls to front
                myLabelProductName.BringToFront();
                myLabelProductDescribe.BringToFront();
                myLabelFlavor.BringToFront();
                myLabelAddIngredients.BringToFront();
                myLabelPrice.BringToFront();
                myLabelCount.BringToFront();
                myDivider.BringToFront();

                yOffset += 250; // 更新Y偏移，以顯示下一個產品
            }
            reader.Close(); // 關閉第一個 reader

            // 第二次查詢，這次用不同的 SqlCommand 和 SqlDataReader
            string strSQL2 = $"select * from \"Order\" o RIGHT JOIN OrderItem oi on oi.OrderNumber = o.OrderNumber RIGHT JOIN Product p on oi.ProductId = p.ProductId where oi.OrderNumber = @OrderNumber;";
            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
            cmd2.Parameters.AddWithValue("@OrderNumber", selectId);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read() == true)
            {
                lblOrderNumber.Text = Convert.ToString(selectId);
                lblOrderTime.Text = Convert.ToDateTime(reader2["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblOrderPurchaser.Text = (string)reader2["UserName"];
                lblTotalMoney.Text = Convert.ToString(reader2["TotalAmount"]);
                if ((bool)reader2["OrderStatus"] == true)
                {
                    lblOrderStatus.Text = "已完成";
                }
                else
                {
                    lblOrderStatus.Text = "處理中";
                }
            }
            reader2.Close(); // 關閉第二個 reader

            // 最後的查詢，用於計算商品種類數量
            string countSQL = "select COUNT(oi.OrderNumber) as ProductCount from OrderItem oi where oi.OrderNumber = @OrderNumber;";
            SqlCommand countCmd = new SqlCommand(countSQL, con);
            countCmd.Parameters.AddWithValue("@OrderNumber", myId);
            int productCount = (int)countCmd.ExecuteScalar();

            // 將計算的商品種類數顯示在 lblProductItemCount
            lblProductItemCount.Text = productCount.ToString();

            con.Close(); // 關閉連線
        }
        private string FormatAddIngredients(string addIngredients)
        {
            string[] ingredientsArray = addIngredients.Split(',');
            StringBuilder formattedIngredients = new StringBuilder();
            int count = 0;

            foreach (string ingredient in ingredientsArray)
            {
                if (count > 0 && count % 5 == 0)
                {
                    formattedIngredients.AppendLine();
                }

                formattedIngredients.Append(ingredient.Trim() + ", "); // 使用Trim()去除前後多餘的空格
                count++;
            }

            return formattedIngredients.ToString().TrimEnd(',', ' ');
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
