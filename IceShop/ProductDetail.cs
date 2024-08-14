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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace IceShop
{
    public partial class ProductDetail : Form
    {
        private Form1 mainForm;
        private int productId;
        List<string> listAddIngredientsItems = new List<string>();
        List<string> listFlavorItems = new List<string>();
        Panel myPanel;
        string IceName = "";
        string IceDescribe = "";
        int Price = 0;
        int Count = 0;
        int Totalprice = 0;
        string Flavor = "";
        string AddIngredients = "";
        int SwitchAdd = 0;
        int UseCustomizationId = 0;
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

            DecideAdd();
            GenerateOptionsForCategory();
        }
        void DecideAdd()
        {
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = @"
                    SELECT * 
                    FROM Product
                    WHERE ProductId = @ProductId";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                UseCustomizationId = (int)reader["CustomizationId"];
                Console.WriteLine(UseCustomizationId);
            }
            reader.Close();
            con.Close();
        }
        private void OriginalMilkShavedSnow_Activated(object sender, EventArgs e)
        {
            DecideAdd();
            GenerateOptionsForCategory();
        }
        private void GenerateOptionsForCategory()
        {
            if (UseCustomizationId == 1) { 
                    lblFlavorTitle.Text = "綿綿冰口味";
                    lblFlavorSubTitle.Text = "只能選1個";
                    lblAddTitle.Text = "加料";
                    lblAddSubTitle.Text = "最少選0個，最多選10個";
                    lblFlavorSubTitle.Location = new Point(220, 313);
                    SwitchAdd = 0;
                    CreateRadioButton();
                    CreateCheckBox();
            }else if (UseCustomizationId == 2)
            {
                lblFlavorTitle.Text = "加料";
                lblFlavorSubTitle.Text = "最少選0個，最多選10個";
                lblAddTitle.Text = "";
                lblAddSubTitle.Text = "";
                lblFlavorSubTitle.Location = new Point(118, 313);
                SwitchAdd = 1;
                CreateCheckBox();
            }
            else
            {
                lblFlavorTitle.Text = "甜度";
                lblFlavorSubTitle.Text = "只能選1個";
                lblAddTitle.Text = "";
                lblAddSubTitle.Text = "";
                lblFlavorSubTitle.Location = new Point(118, 313);
                SwitchAdd = 0;
                CreateRadioButton();
            }
        }
        private void LoadProductDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = @"
        SELECT * 
        FROM Product 
        WHERE ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string productName = reader["ProductName"].ToString();
                    string productDescribe = reader["ProductDescribe"].ToString();
                    string productPrice = reader["UnitPrice"].ToString();

                    lblProductName.Text = productName;
                    lblProductDescribe.Text = InsertLineBreaks(productDescribe, 21);
                    lblProductPrice.Text = productPrice.ToString();

                    string image_name = (string)reader["ProductImage"];
                    string FullImagePath = $"{GlobalVar.image_dir}\\細項\\{image_name}";
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

        void CreateRadioButton()
        {
            myPanel = new Panel();
            myPanel.BackColor = Color.Transparent;
            myPanel.Location = new Point(55, 394);
            myPanel.Size = new Size(700, 40);

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = @"
            SELECT f.FlavorId, f.FlavorName, s.SweetnessId, s.SweetnessLevel
            FROM Product p
            LEFT JOIN Flavor f ON p.CustomizationId = f.CustomizationId
            LEFT JOIN Sweetness s ON p.CustomizationId = s.CustomizationId
            WHERE p.ProductId = @ProductId;";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            while (reader.Read() && i < 3)
            {
                int SweetnessId = reader["SweetnessId"] != DBNull.Value ? Convert.ToInt32(reader["SweetnessId"]) : 0;
                string SweetnessLevel = reader["SweetnessLevel"].ToString();
                int FlavorId = reader["FlavorId"] != DBNull.Value ? Convert.ToInt32(reader["FlavorId"]) : 0;
                string FlavorName = reader["FlavorName"].ToString();
                System.Windows.Forms.RadioButton myRadioButton = new System.Windows.Forms.RadioButton();
                        myRadioButton.BackColor = Color.Transparent;
                        myRadioButton.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
                if (UseCustomizationId == 3)
                {
                    myRadioButton.Text = $"{SweetnessLevel}";
                    if (i == 0)
                    {
                        myRadioButton.Location = new Point(50 + 160 * i, 0);
                    }
                    else if (i == 1)
                    {
                        myRadioButton.Location = new Point(50 + 260 * i, 0); // 縮小第一個和第二個之間的距離
                    }
                    else
                    {
                        myRadioButton.Location = new Point(50 + 260 * i, 0); // 保持第二個和第三個之間的距離
                    }
                    myRadioButton.Size = new Size(200, 35);
                    myRadioButton.Name = $"radio{SweetnessId}";
                    myRadioButton.Click += new EventHandler(rbuttonFlavor_Click);
                    myRadioButton.Tag = $"{SweetnessId}";
                    myPanel.Controls.Add(myRadioButton);
                    if (myRadioButton.Name == "radio1")
                    {
                        myRadioButton.Checked = true;
                        Flavor = myRadioButton.Text;
                        listFlavorItems.Add(Flavor);
                    }
                    i++;
                }
                else
                {
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
                    if (myRadioButton.Name == "radio1")
                    {
                        myRadioButton.Checked = true;
                        Flavor = myRadioButton.Text;
                        listFlavorItems.Add(Flavor);
                    }
                    i++;
                }
                
            }
                    reader.Close();
                    con.Close();
            Controls.Add(myPanel);
        }
        void CreateCheckBox()
        {
            myPanel = new Panel();
            myPanel.BackColor = Color.Transparent;
            if(SwitchAdd == 0)
            {
                myPanel.Location = new Point(55, 510);
            }
            else
            {
                myPanel.Location = new Point(55, 394);
            }
            myPanel.Size = new Size(700, 230);

            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = @"
            SELECT p.ProductName, p.ProductId, ai.AddIngredientId, ai.AddIngredientName
            FROM Product p
            LEFT JOIN AddIngredient ai ON p.CustomizationId = ai.CustomizationId
            WHERE p.ProductId = @ProductId and ai.AddIngredientId is not null;";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = cmd.ExecuteReader();

            int i = 0;
            int columnCount = 4; // 每列顯示 4 個 CheckBox
                    int checkBoxWidth = 160;
                    int checkBoxHeight = 35;
                    int verticalSpacing = 20; // 垂直間距
                    int horizontalSpacing = 20; // 水平間距

                    while (reader.Read() && i < 16)
                    {
                        int addIngredientId = Convert.ToInt32(reader["addIngredientId"]);
                        string addIngredientName = reader["AddIngredientName"].ToString();
                        System.Windows.Forms.CheckBox myCheckBox = new System.Windows.Forms.CheckBox();
                        myCheckBox.BackColor = Color.Transparent;
                        myCheckBox.Font = new Font("Microsoft YaHei UI", 18, FontStyle.Bold);
                        myCheckBox.Text = $"{addIngredientName}";

                        int rowIndex = i / columnCount; // 計算當前 CheckBox 的行索引
                        int columnIndex = i % columnCount; // 計算當前 CheckBox 的列索引

                        myCheckBox.Location = new Point(10 + (checkBoxWidth + horizontalSpacing) * columnIndex, 25 + (checkBoxHeight + verticalSpacing) * rowIndex);
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
            System.Windows.Forms.RadioButton myRadio = (System.Windows.Forms.RadioButton)sender;
            Flavor = myRadio.Text;

            UpdatePrice();
            CalculateItemPrice();
        }
        private void cboxAddIngredientsItems_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox myChekBox = (System.Windows.Forms.CheckBox)sender;
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
            UpdatePrice();
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
        private void UpdatePrice()
        {
            // 根據選項更新價格的邏輯
            Price = GetBasePrice() + CalculateAdditionalCost();
        }
        private int GetBasePrice()
        {
            // 獲取基礎價格
            SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
            con.Open();
            string strSQL = "SELECT UnitPrice FROM Product WHERE ProductId = @ProductId;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ProductId", productId);
            SqlDataReader reader = cmd.ExecuteReader();
            int basePrice = 0;

            if (reader.Read())
            {
                basePrice = Convert.ToInt32(reader["UnitPrice"]);
            }
            reader.Close();
            con.Close();

            return basePrice;
        }

        private int CalculateAdditionalCost()
        {
            int additionalCost = 0;
            // 計算選擇的額外口味或加料的費用
            foreach (var ingredient in listAddIngredientsItems)
            {
                additionalCost += int.Parse(ingredient.Split('+')[1]);
            }

            if (Flavor.Contains("+"))
            {
                additionalCost += int.Parse(Flavor.Split('+')[1]);
            }

            return additionalCost;
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
            foreach (var item in GlobalVar.listChooseCategory)
            {
                if (string.IsNullOrEmpty(Flavor) && item == 1)
                {
                    MessageBox.Show("請選擇口味");
                    return;
                }
            }

            AddIngredients = string.Join(", ", listAddIngredientsItems);
            IceName = lblProductName.Text;
            IceDescribe = lblProductDescribe.Text;

            // 檢查是否已經存在相同的產品
            bool itemExists = false;
            for (int i = 0; i < GlobalVar.listOrderItemCollect.Count; i++)
            {
                var existingItem = (ArrayList)GlobalVar.listOrderItemCollect[i];
                int existingProductId = (int)existingItem[7]; // productId

                // 比較商品ID及其他屬性是否相同
                if (existingProductId == productId &&
                    (int)existingItem[3] == Count &&
                    (string)existingItem[5] == Flavor &&
                    (string)existingItem[6] == AddIngredients)
                {
                    // 如果所有屬性都相同，則不做任何動作
                    itemExists = true;
                    break;
                }
            }

            // 如果沒有完全相同的商品，則新增一筆新資料
            if (!itemExists)
            {
                ArrayList OrderItemData = new ArrayList
        {
            IceName,
            IceDescribe,
            Price,
            Count,
            Totalprice,
            Flavor,
            AddIngredients,
            productId
        };

                GlobalVar.listOrderItemCollect.Add(OrderItemData);
            }

            mainForm.ShowTotalCost(); // 更新 Form1 的總計
            mainForm.CheckShavedSnow();
            this.Close();
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