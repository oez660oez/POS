using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IceShop
{
    public partial class ShoppingCart : Form
    {
        public ShoppingCart()
        {
            InitializeComponent();
        }

        private void ShoppingCart_Load(object sender, EventArgs e)
        {
            DisplayShoppingProduct();
            ShoppingCartTotalMoney();

        }
        private void ShoppingCart_Activated(object sender, EventArgs e)
        {
            DisplayShoppingProduct();
            ShoppingCartTotalMoney();
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

        void DisplayShoppingProduct()
        {
            int yOffset = 10; // 初始Y偏移
            int xOffset = 10; // 初始X偏移

            Panel newPanel = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Left,
                Location = new Point(9, 266),
                Size = new Size(780, 605),
                BackColor = Color.Transparent,
                AutoScroll = true
            };

            this.Controls.Add(newPanel); // 確保將 newPanel 添加到 ShoppingCart 表單中

            foreach (ArrayList item in GlobalVar.listOrderItemCollect)
            {
                string itemName = (string)item[0];
                string itemDescribe = (string)item[1];
                int price = (int)item[2];
                int count = (int)item[3];
                int totalPrice = (int)item[4];
                string flavor = (string)item[5];
                string addIngredients = (string)item[6];

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
                    Text = "$" + totalPrice.ToString()
                };

                Label myLabelCount = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset + 600, yOffset + 90),
                    Text = "X" + count.ToString()
                };

                Button deleteButton = new Button
                {
                    Text = "",
                    Location = new Point(xOffset + 700, yOffset + 80),
                    Size = new Size(44, 44),
                    BackColor = Color.Transparent,
                    FlatStyle = FlatStyle.Flat,
                    BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\刪除按鈕.png"),
                    BackgroundImageLayout = ImageLayout.Stretch
                };
                deleteButton.FlatAppearance.BorderSize = 0;

                deleteButton.Click += (s, e) => DeleteItem(item);

                Label myDivider = new Label
                {
                    BackColor = Color.Transparent,
                    Font = new Font("Microsoft YaHei UI", 14, FontStyle.Bold),
                    ForeColor = Color.FromArgb(0, 0, 51),
                    Location = new Point(xOffset, yOffset + 200),
                    Size = new Size(600, 30),
                    Text = "----------------------------------------------"
                };

                newPanel.Controls.Add(myLabelProductName);
                newPanel.Controls.Add(myLabelProductDescribe);
                newPanel.Controls.Add(myLabelFlavor);
                newPanel.Controls.Add(myLabelAddIngredients);
                newPanel.Controls.Add(myLabelPrice);
                newPanel.Controls.Add(myLabelCount);
                newPanel.Controls.Add(deleteButton);
                newPanel.Controls.Add(myDivider);

                // Bring controls to front
                myLabelProductName.BringToFront();
                myLabelProductDescribe.BringToFront();
                myLabelFlavor.BringToFront();
                myLabelAddIngredients.BringToFront();
                myLabelPrice.BringToFront();
                myLabelCount.BringToFront();
                deleteButton.BringToFront();
                myDivider.BringToFront();

                yOffset += 250; // 更新Y偏移，以顯示下一個產品
            }
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

        public void ShoppingCartTotalMoney()
        {

            int totalMoney = 0;

            foreach (ArrayList item in GlobalVar.listOrderItemCollect)
            {
                int itemTotalPrice = (int)item[4]; // item[3] 是商品總價

                totalMoney += itemTotalPrice;
            }

            lblShoppingTotalCost.Text = totalMoney.ToString();
        }
        private void DeleteItem(ArrayList item)
        {
            GlobalVar.listOrderItemCollect.Remove(item);
            Controls.Clear();
            InitializeComponent();
            DisplayShoppingProduct();
            ShoppingCartTotalMoney();
        }

        private void btnPruchase_Click(object sender, EventArgs e)
        {
            Payment Payment = new Payment();
            Payment.Show();
            this.Hide();
        }

        private void btnReChoose_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
