using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace IceShop
{
    public partial class ProductDetail : Form
    {
        private Form1 mainForm;
        private int productId;
        List<string> listAddIngredientsItems = new List<string>();
        List<string> listFlavorItems = new List<string>();
        private string previousSelectedFlavor = "";//儲存冰磚口味
        Panel myPanel;
        string IceName = "";
        int Price = 0;
        int Count = 0;
        int Totalprice = 0;
        string Flavor = "";
        string AddIngredients = "";

        // 新增接收 Form1 和 productId 的構造函式
        public ProductDetail(Form1 form, int productId)
        {
            InitializeComponent();
            mainForm = form;
            this.productId = productId;
        }

        private void OriginalMilkShavedSnow_Load(object sender, EventArgs e)
        {
            Count = 1;
            txtInput.Text = Count.ToString();
            LoadProductDetails();
            CalculateItemPrice();
            ProgrammingRadioButton();
            ProgrammingCheckBox();
        }
        private void OriginalMilkShavedSnow_Activated(object sender, EventArgs e)
        {
            LoadProductDetails();
            ProgrammingRadioButton();
            ProgrammingCheckBox();
        }

        private void LoadProductDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select * from product where ProductId = @ProductId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // 在這裡處理讀取到的產品資料，並更新表單顯示
                    string productName = reader["ProductName"].ToString();
                    string ProductDescribe = reader["ProductDescribe"].ToString();
                    string productPrice = reader["UnitPrice"].ToString();
                    // 根據資料庫中的資料更新表單的控件
                    lblProductName.Text = productName;
                    lblProductDescribe.Text = InsertLineBreaks(ProductDescribe, 21);
                    lblProductPrice.Text = productPrice.ToString();
                    string image_name = (string)reader["ProductImage"];
                    string FullImagePath = $"{GlobalVar.image_dir}\\細項\\{image_name}";
                    Console.WriteLine(FullImagePath);
                    FileStream fs = File.OpenRead(FullImagePath);
                    pictureBoxIce.Image = Image.FromStream(fs);
                }
                Price = Convert.ToInt32(lblProductPrice.Text);
                reader.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取產品資料時出現錯誤: " + ex.Message);
            }
        }
        void ProgrammingRadioButton()
        {
            myPanel = new Panel();
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(55, 394);
            myPanel.Size = new Size(700, 60);

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select top 200 * from Flavor;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read() && i < 3)
            {
                int FlavorId = Convert.ToInt32(reader["FlavorId"]);
                string FlavorName = reader["FlavorName"].ToString();
                RadioButton myRadioButton = new RadioButton();
                myRadioButton.BackColor = Color.Transparent;
                myRadioButton.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
                myRadioButton.Text = $"{FlavorName}";
                if (i == 0)
                {
                    myRadioButton.Location = new Point(50 + 160 * i, 0);
                }
                else if (i == 1)
                {
                    myRadioButton.Location = new Point(50 + 200 * i, 0); // 縮小第一個和第二個之間的距離
                }
                else
                {
                    myRadioButton.Location = new Point(50 + 220 * i, 0); // 保持第二個和第三個之間的距離
                }
                myRadioButton.Size = new Size(200, 35);
                myRadioButton.Name = $"radio{FlavorId}";
                myRadioButton.Click += new EventHandler(rbuttonFlavor_Click);
                myRadioButton.Tag = $"{FlavorId}";
                myPanel.Controls.Add(myRadioButton);
                if(myRadioButton.Name == "radio1")
                {
                    myRadioButton.Checked = true;
                    Flavor = myRadioButton.Text;
                    listFlavorItems.Add(Flavor);
                    foreach (var item in listFlavorItems) { Console.WriteLine($"{item}"); }
                }
                i++;
            }

            reader.Close();
            con.Close();

            Controls.Add(myPanel);
        }
        void ProgrammingCheckBox()
        {
            myPanel = new Panel();
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(55, 510);
            myPanel.Size = new Size(700, 230);

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "select top 200 * from AddIngredient;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            int columnCount = 4; // 每列顯示 4 個 CheckBox
            int rowCount = 4; // 總共 4 列
            int checkBoxWidth = 160;
            int checkBoxHeight = 35;
            int verticalSpacing = 20; // 垂直間距
            int horizontalSpacing = 20; // 水平間距

            while (reader.Read() && i < 16)
            {
                int addIngredientId = Convert.ToInt32(reader["AddIngredientId"]);
                string addIngredientName = reader["AddIngredientName"].ToString();
                CheckBox myCheckBox = new CheckBox();
                myCheckBox.BackColor = Color.Transparent;
                myCheckBox.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
                myCheckBox.Text = $"{addIngredientName}";

                int rowIndex = i / columnCount; // 計算當前 CheckBox 的行索引
                int columnIndex = i % columnCount; // 計算當前 CheckBox 的列索引

                myCheckBox.Location = new Point(10 + (checkBoxWidth + horizontalSpacing) * columnIndex,25 + (checkBoxHeight + verticalSpacing) * rowIndex);
                myCheckBox.Size = new Size(checkBoxWidth, checkBoxHeight);
                myCheckBox.Name = $"checkBox{addIngredientId}";
                myCheckBox.Click += new EventHandler(cboxAddIngredientsItems_Click);
                myCheckBox.Tag = $"{addIngredientId}";
                myPanel.Controls.Add(myCheckBox);
                i++;
            }

            reader.Close();
            con.Close();

            Controls.Add(myPanel);
        }
        private string InsertLineBreaks(string text, int interval)
        {
            if (string.IsNullOrEmpty(text) || interval <= 0)
                return text;

            for (int i = interval; i < text.Length; i += interval)
            {
                text = text.Insert(i, "\n");
                i++; // Adjust index due to the insertion of the newline character
            }
            return text;
        }
        private void rbuttonFlavor_Click(object sender, EventArgs e)
        {
            listFlavorItems.Clear();
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "SELECT UnitPrice FROM product WHERE ProductId = @ProductId;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            RadioButton myRadio = (RadioButton)sender;
            Flavor = myRadio.Text;

            if (reader.Read())
            {
                string productPrice = reader["UnitPrice"].ToString();
                if (previousSelectedFlavor == "")
                {
                    Price = Convert.ToInt32(productPrice);
                }
            }

            // 如果之前選擇的口味有額外費用，從價格中扣除
            if (!string.IsNullOrEmpty(previousSelectedFlavor) && previousSelectedFlavor.Contains("+"))
            {
                Price -= int.Parse(previousSelectedFlavor.Split('+')[1]);
            }

            // 如果新選擇的口味有額外費用，增加到價格中
            if (Flavor.Contains("+"))
            {
                Price += int.Parse(Flavor.Split('+')[1]);
            }

            previousSelectedFlavor = Flavor; // 更新之前選擇的口味
            listFlavorItems.Add(Flavor);
            foreach (var item in listFlavorItems) { Console.WriteLine($"{item}"); }
            CalculateItemPrice();
        }
        private void cboxAddIngredientsItems_Click(object sender, EventArgs e)
        {
            CheckBox myChekBox = (CheckBox)sender;
            string ingredient = myChekBox.Text;
            AddIngredients = myChekBox.Text;

            if (myChekBox.Checked)
            {
                if (listAddIngredientsItems.Count < 10)
                {
                    listAddIngredientsItems.Add(ingredient);
                    Price += int.Parse(AddIngredients.Split('+')[1]);
                }
                else
                {
                    myChekBox.Checked = false;
                    MessageBox.Show("您已選至加料上限");
                }
            }
            else
            {
                listAddIngredientsItems.Remove(ingredient);
                Price -= int.Parse(AddIngredients.Split('+')[1]);
            }
            foreach (var item in listAddIngredientsItems) { Console.Write($"{item}"); }
            CalculateItemPrice();
        }
        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                bool isCountInputCorrect = Int32.TryParse(txtInput.Text, out Count);
                if ((isCountInputCorrect) && (Count > 0) && (Count < 100))
                {//輸入正確

                }
                else
                {//輸入不正確
                    MessageBox.Show("數量輸入不正確！請重新輸入 (1-99) ");
                    Count = 1;
                    txtInput.Text = Count.ToString();
                }
                CalculateItemPrice();
            }

        }
        void CalculateItemPrice()
        {
                Totalprice = Price * Count;
                lblMoney.Text = $"{Totalprice}";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            mainForm.CheckShavedSnow();
            this.Close();
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Flavor))
            {
                MessageBox.Show("請選擇口味");
                return;
            }

            AddIngredients = string.Join(", ", listAddIngredientsItems);

            ArrayList OrderItemData = new ArrayList
            {
                IceName,
                Price,
                Count,
                Totalprice,
                Flavor,
                AddIngredients
            };

            GlobalVar.listOrderItemCollect.Add(OrderItemData);
            mainForm.CheckShavedSnow();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Count++;
            txtInput.Text = Count.ToString();
            CalculateItemPrice();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (Count <= 1)
            {
                MessageBox.Show("數量不能再減少了！");
                Count = 1;
                txtInput.Text = Count.ToString();
            }
            else
            {
                Count--;
                txtInput.Text = Count.ToString();
            }
            CalculateItemPrice();
        }

    }
}
