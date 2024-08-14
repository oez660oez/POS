using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace IceShop
{
    public partial class ProductThumbnails : Form
    {
        private Form1 mainForm;
        private string filterProductName;
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<int> listId = new List<int>();
        List<string> listProductName = new List<string>();

        public ProductThumbnails(Form1 form, string productName = "")
        {
            InitializeComponent();
            mainForm = form;
            filterProductName = productName;
        }
        private void ShavedSnow_Load(object sender, EventArgs e)
        {
            LoadProductDatabase();
        }

        private void ProductThumbnails_Activated(object sender, EventArgs e)
        {
            LoadProductDatabase();
        }
        public void LoadProductDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select top 200 * from product where ProductCategory = @Category";
                if (!string.IsNullOrEmpty(filterProductName))
                {
                    strSQL += " AND ProductName LIKE @ProductName";
                }

                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@Category", GlobalVar.listChooseCategory[0]);

                if (!string.IsNullOrEmpty(filterProductName))
                {
                    cmd.Parameters.AddWithValue("@ProductName", "%" + filterProductName + "%");
                }

                SqlDataReader reader = cmd.ExecuteReader();

                // 清除現有的縮圖按鈕
                Controls.Clear();

                int count = 0;
                int xOffset = 5;
                int yOffset = 0;
                int buttonWidth = 198;
                int buttonHeight = 238;
                int buttonsPerRow = 4;

                while (reader.Read())
                {
                    bool ProductInventory = (bool)reader["Inventory"];
                    if (ProductInventory == false)
                    {
                        listId.Add((int)reader["ProductId"]);
                        string image_name = (string)reader["ProductInStockImage"];
                        string FullImagePath = $"{GlobalVar.image_dir}\\缺貨\\{image_name}";

                        using (FileStream fs = File.OpenRead(FullImagePath))
                        {
                            Image imgProductImage = Image.FromStream(fs);

                            Button dbutton = new Button
                            {
                                BackColor = Color.Transparent,
                                BackgroundImage = imgProductImage,
                                BackgroundImageLayout = ImageLayout.Zoom,
                                FlatStyle = FlatStyle.Flat,
                                Text = "",
                                FlatAppearance = { BorderSize = 0 },
                                Size = new Size(buttonWidth, buttonHeight),
                                Name = $"btn{count}",
                                Tag = listId[count],
                                Location = new Point(xOffset + (count % buttonsPerRow) * buttonWidth, yOffset + (count / buttonsPerRow) * buttonHeight),
                                Enabled = false
                            };

                            dbutton.Click += new EventHandler(dbutton_Click);
                            Controls.Add(dbutton); // 將按鈕添加到pnlShow面板中
                        }
                    }
                    else
                    {
                        listId.Add((int)reader["ProductId"]);
                        string image_name = (string)reader["ProductThumbnails"];
                        string FullImagePath = $"{GlobalVar.image_dir}\\商品縮圖\\{image_name}";

                        using (FileStream fs = File.OpenRead(FullImagePath))
                        {
                            Image imgProductImage = Image.FromStream(fs);

                            Button dbutton = new Button
                            {
                                BackColor = Color.Transparent,
                                BackgroundImage = imgProductImage,
                                BackgroundImageLayout = ImageLayout.Zoom,
                                FlatStyle = FlatStyle.Flat,
                                Text = "",
                                FlatAppearance = { BorderSize = 0 },
                                Size = new Size(buttonWidth, buttonHeight),
                                Name = $"btn{count}",
                                Tag = listId[count],
                                Location = new Point(xOffset + (count % buttonsPerRow) * buttonWidth, yOffset + (count / buttonsPerRow) * buttonHeight)
                            };

                            dbutton.Click += new EventHandler(dbutton_Click);
                            Controls.Add(dbutton); // 將按鈕添加到pnlShow面板中
                        }
                    }

                    count++;
                }

                reader.Close();
                con.Close();
                Console.WriteLine($"讀取{count}筆資料");
            }
            catch (Exception ex)
            {
                Console.WriteLine("出現錯誤: " + ex.Message);
            }
        }

        private void dbutton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int productId = (int)clickedButton.Tag;

                // 將 ProductId 傳遞給 OriginalMilkShavedSnow 表單
                ProductDetail originalMilkShavedSnow = new ProductDetail(mainForm, productId);
                mainForm.ShowProductDetail(originalMilkShavedSnow);
            }
        }

    }
}