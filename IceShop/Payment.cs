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
    public partial class Payment : Form
    {
        
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true; // 預設選擇內用
            UpdateTotalMoney(); // 初始時更新總價
            for (int i = 1; i <= 31; i += 1)
            {
                cBoxDate.Items.Add($"{i}");
            }
            cBoxDate.SelectedIndex = 0;
            for (int i = 1; i <= 23; i++)
            {
                cBoxHour.Items.Add($"{i}");
            }
            cBoxHour.SelectedIndex = 0;
            for (int i = 0; i <= 50; i+= 10)
            {
                cBoxMinute.Items.Add($"{i}");
            }
            cBoxMinute.SelectedIndex = 0;
        }

        private void Payment_Activated(object sender, EventArgs e)
        {
            UpdateTotalMoney(); // 當表單啟動時更新總價
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingcart = new ShoppingCart();
            shoppingcart.Show(); // 使用 Show 而不是 ShowDialog
            this.Hide();
        }

        private void checkBoxBag_CheckedChanged(object sender, EventArgs e)
        {
            UpdateTotalMoney(); // 每次勾選或取消勾選時更新總價
        }

        private void UpdateTotalMoney()
        {
            int totalMoney = 0;

            foreach (ArrayList item in GlobalVar.listOrderItemCollect)
            {
                int itemTotalPrice = (int)item[4]; // item[4] 是商品總價
                totalMoney += itemTotalPrice;
            }

            if (checkBoxBag.Checked)
            {
                totalMoney += 2; // 加上購物袋的費用
            }

            lblShoppingTotalCost.Text = totalMoney.ToString();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            string dineOption = radioButton1.Checked ? "內用" : "外帶";
            Random myRnd = new Random();
            int numRnd = myRnd.Next(1000, 10000);
            string strFileName = DateTime.Now.ToString("yyMMddHHmmss") + numRnd + "大碗公冰品訂購檔.txt";
            string strCompletePathFileName = GlobalVar.image_dir + @"\" + strFileName;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = GlobalVar.image_dir;
            sfd.FileName = strFileName;
            sfd.Filter = "文字檔 Text File|*.txt";
            DialogResult R = sfd.ShowDialog();

            if (R != DialogResult.OK)
            {
                return;
            }

            strCompletePathFileName = sfd.FileName;

            using (SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString))
            {
                con.Open();

                // 插入 Order 表並取得自動遞增的 OrderNumber
                string strSQL = "INSERT INTO [Order] (CustomerId, UserName, OrderDate, TotalAmount, BagOption, DiningOption) " +
                                "VALUES (@CustomerId, @UserName, @OrderDate, @TotalAmount, @BagOption, @DiningOption); " +
                                "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@CustomerId", GlobalVar.UserID);
                cmd.Parameters.AddWithValue("@UserName", GlobalVar.UserName.ToString());
                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                int totalMoney = int.Parse(lblShoppingTotalCost.Text);
                cmd.Parameters.AddWithValue("@TotalAmount", totalMoney);
                cmd.Parameters.AddWithValue("@BagOption", checkBoxBag.Checked);
                cmd.Parameters.AddWithValue("@DiningOption", dineOption);

                // 執行插入並取得 OrderNumber
                int newOrderNumber = Convert.ToInt32(cmd.ExecuteScalar());

                // 插入 OrderItem 表單
                string strSQL2 = "INSERT INTO OrderItem (OrderNumber, ProductId, Price, Quantity, Flavor, AddIngredients) " +
                                 "VALUES (@OrderNumber, @ProductId, @Price, @Quantity, @Flavor, @AddIngredients);";
                SqlCommand cmd2 = new SqlCommand(strSQL2, con);

                foreach (ArrayList item in GlobalVar.listOrderItemCollect)
                {
                    int productId = (int)item[7];
                    int price = (int)item[2];
                    int count = (int)item[3];
                    string flavor = (string)item[5];
                    string addIngredients = (string)item[6];

                    cmd2.Parameters.Clear();
                    cmd2.Parameters.AddWithValue("@OrderNumber", newOrderNumber);
                    cmd2.Parameters.AddWithValue("@ProductId", productId);
                    cmd2.Parameters.AddWithValue("@Price", price);
                    cmd2.Parameters.AddWithValue("@Quantity", count);
                    cmd2.Parameters.AddWithValue("@Flavor", flavor);
                    cmd2.Parameters.AddWithValue("@AddIngredients", addIngredients);

                    cmd2.ExecuteNonQuery();
                }

                con.Close();
            }

            // 訂單內容輸出
            List<string> listOrderExport = new List<string>();
            listOrderExport.Add("*********** 大碗公冰品訂購單 **********");
            listOrderExport.Add("--------------------------------");
            listOrderExport.Add($"訂購時間：{DateTime.Now}");
            listOrderExport.Add($"訂購人：{GlobalVar.UserName}");
            if (dineOption == "內用")
            {
                listOrderExport.Add($"內用");
            }
            else
            {
                listOrderExport.Add($"外帶");
            }
            if (checkBoxBag.Checked)
            {
                listOrderExport.Add($"加購購物袋+2元");
            }
            listOrderExport.Add($"預定日期： 2024年 8月 {cBoxDate.SelectedItem.ToString()}日 {cBoxHour.SelectedItem.ToString()}點 {cBoxMinute.SelectedItem.ToString()}分");
            listOrderExport.Add("========= << 訂購品項 >> =========");

            foreach (ArrayList item in GlobalVar.listOrderItemCollect)
            {
                string itemName = (string)item[0];
                string itemDescribe = (string)item[1];
                int price = (int)item[2];
                int count = (int)item[3];
                int totalPrice = (int)item[4];
                string flavor = (string)item[5];
                string addIngredients = (string)item[6];

                listOrderExport.Add($"{itemName}\n{itemDescribe}\n價格:{price}    數量:{count}    價格:{totalPrice}元\n{flavor}\n{addIngredients}");
                listOrderExport.Add("=================================");
            }

            listOrderExport.Add("----------------------------------");
            listOrderExport.Add($"           總金額：{lblShoppingTotalCost.Text}           ");
            listOrderExport.Add("=================================");
            listOrderExport.Add("************ 謝謝光臨 *************");

            System.IO.File.WriteAllLines(strCompletePathFileName, listOrderExport, Encoding.UTF8);
            MessageBox.Show("訂購單儲存成功");
        }
    }
}
