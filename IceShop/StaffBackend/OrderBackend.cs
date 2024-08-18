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
    public partial class OrderBackend : Form
    {
        List<int> SearchIDs = new List<int>();//搜尋結果
        List<int> OrderIDs = new List<int>();//訂單結果
        int selectId = 0;
        int selectOrderId = 0;
        public OrderBackend()
        {
            InitializeComponent();
        }

        private void OrderBackend_Load(object sender, EventArgs e)
        {
            DisplayText();
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
        void DisplayText()
        {
            lblOrderNumber.Text = "";
            lblOrderTime.Text = "";
            lblOrderPurchaser.Text = "";
            lblTotalMoney.Text = "";
            lblProductItemCount.Text = "";
            lblHowToEat.Text = "";
            lblBag.Text = "";
            lblOrderStatus.Text = "";

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
            if (lboxSearchResult.SelectedIndex >= 0 && lboxSearchResult.SelectedIndex < SearchIDs.Count)
            {
                selectId = 0;
                lboxSearchOrder.Items.Clear();
                pnlShowProduct.Controls.Clear();
                lblOrderNumber.Text = "";
                lblOrderTime.Text = "";
                lblOrderPurchaser.Text = "";
                lblTotalMoney.Text = "";
                lblProductItemCount.Text = "";
                lblHowToEat.Text = "";
                lblBag.Text = "";
                lblOrderStatus.Text = "";
                selectId = SearchIDs[lboxSearchResult.SelectedIndex];
                lboxOrderDisplay(selectId);
                Console.WriteLine(selectId);
            }
        }
        void lboxOrderDisplay(int myId)
        {
            lboxSearchOrder.Items.Clear();  // 清空列表框
            OrderIDs.Clear();  // 清空訂單結果

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" where CustomerId = @CustomerId and (OrderDate >= @StartBirth) and (OrderDate <= @EndBirth);";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@CustomerId", myId);
            cmd.Parameters.AddWithValue("@StartBirth", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@EndBirth", dateTimePicker1.Value);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lboxSearchOrder.Items.Add($"{reader["OrderDate"]} {reader["TotalAmount"]}");
                OrderIDs.Add((int)reader["OrderNumber"]);
            }

            reader.Close();
            con.Close();  // 關閉連線
        }

        private void lboxSearchOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lboxSearchOrder.SelectedIndex >= 0 && lboxSearchOrder.SelectedIndex < OrderIDs.Count)
            {
                selectOrderId = 0;
                pnlShowProduct.Controls.Clear();
                selectOrderId = OrderIDs[lboxSearchOrder.SelectedIndex];
                DisplayOrderItem(selectOrderId);
            }
        }
        void DisplayOrderItem(int Myid)
        {
            int yOffset = 10; // 初始Y偏移
            int xOffset = 10; // 初始X偏移

            this.Controls.Add(pnlShowProduct); // 確保將 newPanel 添加到 ShoppingCart 表單中
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();

            string strSQL = $"select * from \"Order\" o RIGHT JOIN OrderItem oi on oi.OrderNumber = o.OrderNumber RIGHT JOIN Product p on oi.ProductId = p.ProductId where oi.OrderNumber = @OrderNumber;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@OrderNumber", Myid);
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
                    Location = new Point(xOffset + 400, yOffset + 90),
                    Text = "$" + Price.ToString()
                };

                Label myLabelCount = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset + 500, yOffset + 90),
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

                pnlShowProduct.Controls.Add(myLabelProductName);
                pnlShowProduct.Controls.Add(myLabelProductDescribe);
                pnlShowProduct.Controls.Add(myLabelFlavor);
                pnlShowProduct.Controls.Add(myLabelAddIngredients);
                pnlShowProduct.Controls.Add(myLabelPrice);
                pnlShowProduct.Controls.Add(myLabelCount);
                pnlShowProduct.Controls.Add(myDivider);

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
            cmd2.Parameters.AddWithValue("@OrderNumber", Myid);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read() == true)
            {
                lblOrderNumber.Text = Convert.ToString(Myid);
                lblOrderTime.Text = Convert.ToDateTime(reader2["OrderDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                lblOrderPurchaser.Text = (string)reader2["UserName"];
                lblTotalMoney.Text = Convert.ToString(reader2["TotalAmount"]);
                lblHowToEat.Text = (string)reader2["DiningOption"];
                if ((bool)reader2["BagOption"] == true)
                {
                    lblBag.Text = "是";
                }
                else
                {
                    lblBag.Text = "否";
                }
                if((bool)reader2["OrderStatus"] == true)
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
            countCmd.Parameters.AddWithValue("@OrderNumber", Myid);
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
            StaffBackend StaffBackend = new StaffBackend();
            StaffBackend.Show();
            this.Hide();
        }

        private void btnOrderStatusModify_Click(object sender, EventArgs e)
        {
            if(selectOrderId != 0)
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();

                bool OrderStatus = true;
                if (lblOrderStatus.Text == "已完成")
                {
                    OrderStatus = false;
                    lblOrderStatus.Text = "處理中";
                }
                else if (lblOrderStatus.Text == "處理中")
                {
                    OrderStatus = true;
                    lblOrderStatus.Text = "已完成";
                }
                string strSQL = $"update \"Order\" set OrderStatus = '{OrderStatus}' where OrderNumber = @OrderNumber;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@OrderNumber", selectOrderId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Close(); // 關閉第二個 reader
                con.Close(); // 關閉連線
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            lboxOrderDisplay(selectId);
        }
    }
}
