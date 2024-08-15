using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace IceShop
{
    public partial class ProductBackend : Form
    {
        List<int> listId = new List<int>();
        string strModifiedImageName = "";
        string strModifiedImageNameThumbnails = "";
        bool isModifyImage = false;
        int productId = 0;
        string filterProductName = "";
        public ProductBackend()
        {
            InitializeComponent();
        }

        private void ProductBackend_Load(object sender, EventArgs e)
        {
            ImageChange();
            HideAllButton();
        }
        void ImageChange()
        {
            btnShavedSnow01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\綿綿冰系列01.png");
            btnShavedIce01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\刨冰系列01.png");
            btnGrassJelly01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\仙草系列01.png");
            btnSeasonal01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\季節限定01.png");
            btnDrinks01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\飲品系列01.png");
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
        private void pnlShavedSnow_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(1);
            ImageChange();
            btnShavedSnow01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\綿綿冰系列02.png");
            pnlShow.Controls.Clear();
            LoadProductDatabase();
        }
        private void pnlShavedIce_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(2);
            ImageChange();
            btnShavedIce01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\刨冰系列02.png");
            pnlShow.Controls.Clear();
            LoadProductDatabase();
        }
        private void pnlGrassJelly_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(3);
            ImageChange();
            btnGrassJelly01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\仙草系列02.png");
            pnlShow.Controls.Clear();
            LoadProductDatabase();
        }

        private void pnlSeasonal_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(4);
            ImageChange();
            btnSeasonal01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\季節限定02.png");
            pnlShow.Controls.Clear();
            LoadProductDatabase();
        }

        private void pnlDrinks_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(5);
            ImageChange();
            btnDrinks01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\飲品系列02.png");
            pnlShow.Controls.Clear();
            LoadProductDatabase();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            filterProductName = txtSearch.Text;
            LoadProductDatabase();
        }
        void LoadProductDatabase()
        {
            try
            {
                listId.Clear();
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
                pnlShow.Controls.Clear();

                int count = 0;
                int xOffset = 5;
                int yOffset = 0;
                int buttonWidth = 198;
                int buttonHeight = 238;
                int buttonsPerRow = 3;

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
                                Location = new Point(xOffset + (count % buttonsPerRow) * buttonWidth, yOffset + (count / buttonsPerRow) * buttonHeight)
                            };

                            dbutton.Click += new EventHandler(dbutton_Click);
                            pnlShow.Controls.Add(dbutton); // 將按鈕添加到pnlShow面板中
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
                            pnlShow.Controls.Add(dbutton); // 將按鈕添加到pnlShow面板中
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
                productId = (int)clickedButton.Tag;
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();

                string strSQL = $"select * from Product where ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    strModifiedImageName = reader["ProductImage"].ToString();
                    string strFullImagePath = $"{GlobalVar.image_dir}\\細項\\{strModifiedImageName}";
                    System.IO.FileStream fs = System.IO.File.OpenRead(strFullImagePath);
                    pictureBoxIce.Image = Image.FromStream(fs);//fs被視為檔案，需要從檔案讀出圖片
                    fs.Close();
                    strModifiedImageNameThumbnails = reader["ProductThumbnails"].ToString();
                    string strFullImagePath2 = $"{GlobalVar.image_dir}\\商品縮圖\\{strModifiedImageNameThumbnails}";
                    System.IO.FileStream fs2 = System.IO.File.OpenRead(strFullImagePath2);
                    pictureBoxThumbnails.Image = Image.FromStream(fs2);//fs被視為檔案，需要從檔案讀出圖片
                    fs2.Close();
                    txtProductName.Text = (string)reader["ProductName"].ToString();
                    txtUnitPrice.Text = reader["UnitPrice"].ToString();
                    txtProductDescribe.Text = reader["ProductDescribe"].ToString();
                    int InventoryCheck = Convert.ToInt32(reader["Inventory"]);
                    if (InventoryCheck == 1)
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    int CustomizationId = (int)reader["CustomizationId"];
                    if(CustomizationId == 1)
                    {
                        radioButton3.Checked = true;
                    }
                    else if (CustomizationId == 2)
                    {
                        radioButton4.Checked = true;
                    }
                    else
                    {
                        radioButton5.Checked = true;
                    }
                    txtProductCategory.Text = reader["ProductCategory"].ToString();
                }
                reader.Close();
                con.Close();
            }
        }
        void SelectImage(PictureBox pictureBox, ref string modifiedImageName)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "檔案類型(JPEG, JPG, PNG)|*.jpeg;*.jpg;*.png";

            DialogResult R = ofd.ShowDialog();

            if (R == DialogResult.OK)
            {
                using (System.IO.FileStream fs = System.IO.File.OpenRead(ofd.FileName))
                {
                    pictureBox.Image = Image.FromStream(fs);
                    pictureBox.Tag = ofd.FileName;
                    string strImageSubName = System.IO.Path.GetExtension(ofd.SafeFileName).ToLower();
                    Random myRnd = new Random();
                    modifiedImageName = DateTime.Now.ToString("yyMMddHHmmss") + myRnd.Next(1000, 10000).ToString() + strImageSubName;
                    isModifyImage = true;
                    Console.WriteLine(modifiedImageName);
                }
            }
        }

        private void btnSelectImageModify_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBoxIce, ref strModifiedImageName);
        }

        private void btnSelectImageThumbnailModify_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBoxThumbnails, ref strModifiedImageNameThumbnails);
        }

        private void btnModifySave_Click(object sender, EventArgs e)
        {
            if ((txtProductName.Text != "") && (txtUnitPrice.Text != "") && (txtProductDescribe.Text != "") && (txtProductCategory.Text != "") && (pictureBoxIce.Image != null) && (pictureBoxThumbnails.Image != null))
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "update product set ProductName = @NewProductName, UnitPrice = @NewPrice, Inventory = @NewInventory, ProductImage = @NewProductImage, ProductThumbnails = @NewProductThumbnails, ProductDescribe = @NewProductDescribe, CustomizationId = @NewCustomizationId, ProductCategory = @ProductCategory where ProductId = @ProductId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@NewProductName", txtProductName.Text);
                int intPrice = 0;
                Int32.TryParse(txtUnitPrice.Text, out intPrice);
                cmd.Parameters.AddWithValue("@NewPrice", intPrice);

                if (radioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewInventory", 1);
                }
                else if (radioButton2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewInventory", 0);
                }

                cmd.Parameters.AddWithValue("@NewProductDescribe", txtProductDescribe.Text);
                cmd.Parameters.AddWithValue("@NewProductImage", strModifiedImageName);
                cmd.Parameters.AddWithValue("@NewProductThumbnails", strModifiedImageNameThumbnails);
                cmd.Parameters.AddWithValue("@ProductCategory", txtProductCategory.Text);

                if (radioButton3.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 1);
                }
                else if (radioButton4.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 3);
                }

                // 儲存圖片
                if (isModifyImage)
                {
                    // 儲存細項圖片
                    string fullImagePathIce = $"{GlobalVar.image_dir}\\細項\\{strModifiedImageName}";
                    pictureBoxIce.Image.Save(fullImagePathIce);

                    // 儲存縮圖圖片
                    string fullImagePathThumbnails = $"{GlobalVar.image_dir}\\商品縮圖\\{strModifiedImageNameThumbnails}";
                    pictureBoxThumbnails.Image.Save(fullImagePathThumbnails);

                    isModifyImage = false; // 重置圖片修改狀態
                }

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show($"資料修改成功，影響{rows}筆資料");
            }
            else
            {
                MessageBox.Show("所有欄位必填");
            }
        }

        private void btnSelectImageAdd_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBoxIce, ref strModifiedImageName);
        }

        private void btnSelectImageThumbnailAdd_Click(object sender, EventArgs e)
        {
            SelectImage(pictureBoxThumbnails, ref strModifiedImageNameThumbnails);
        }

        void ClearAllCol()
        {
            pictureBoxIce.Image = null;
            pictureBoxThumbnails.Image = null;
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
            txtProductDescribe.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            txtProductCategory.Text = "";
        }
        private void btnClearCol_Click(object sender, EventArgs e)
        {
            ClearAllCol();
        }

        private void btnAddSave_Click(object sender, EventArgs e)
        {
            if ((txtProductName.Text != "") && (txtUnitPrice.Text != "") && (txtProductDescribe.Text != "") && (txtProductCategory.Text != "") && (pictureBoxIce.Image != null) && (pictureBoxThumbnails.Image != null))
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "insert into Product (ProductName,UnitPrice,Inventory,ProductImage,ProductThumbnails,ProductDescribe,CustomizationId,ProductCategory)values (@NewProductName,@NewPrice,@NewInventory,@NewProductImage,@NewProductThumbnails,@NewProductDescribe,@NewCustomizationId,@ProductCategory);";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NewProductName", txtProductName.Text);
                int intPrice = 0;
                Int32.TryParse(txtUnitPrice.Text, out intPrice);
                cmd.Parameters.AddWithValue("@NewPrice", intPrice);

                if (radioButton1.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewInventory", 1);
                }
                else if (radioButton2.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewInventory", 0);
                }

                cmd.Parameters.AddWithValue("@NewProductDescribe", txtProductDescribe.Text);
                cmd.Parameters.AddWithValue("@NewProductImage", strModifiedImageName);
                cmd.Parameters.AddWithValue("@NewProductThumbnails", strModifiedImageNameThumbnails);
                cmd.Parameters.AddWithValue("@ProductCategory", txtProductCategory.Text);

                if (radioButton3.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 1);
                }
                else if (radioButton4.Checked == true)
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@NewCustomizationId", 3);
                }

                // 儲存圖片
                if (isModifyImage)
                {
                    // 儲存細項圖片
                    string fullImagePathIce = $"{GlobalVar.image_dir}\\細項\\{strModifiedImageName}";
                    pictureBoxIce.Image.Save(fullImagePathIce);

                    // 儲存縮圖圖片
                    string fullImagePathThumbnails = $"{GlobalVar.image_dir}\\商品縮圖\\{strModifiedImageNameThumbnails}";
                    pictureBoxThumbnails.Image.Save(fullImagePathThumbnails);

                    isModifyImage = false; // 重置圖片修改狀態
                }

                int rows = cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show($"資料新增成功，影響{rows}筆資料");
            }
            else
            {
                MessageBox.Show("所有欄位必填");
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (productId > 0)
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "delete from Product where ProductId = @DeleteId;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@DeleteId", productId);
                int rows = cmd.ExecuteNonQuery();
                con.Close();

                System.IO.File.Delete($"{GlobalVar.image_dir}\\細項\\{strModifiedImageName}");//之前有把完整檔案路徑藏在tag中
                System.IO.File.Delete($"{GlobalVar.image_dir}\\商品縮圖\\{strModifiedImageNameThumbnails}");
                ClearAllCol();
                MessageBox.Show($"資料已刪除\n {rows}筆資料受影響");
            }
        }
        void HideAllButton()
        {
            btnSelectImageAdd.Visible = false;
            btnSelectImageThumbnailAdd.Visible = false;
            btnAddSave.Visible = false;
            btnClearCol.Visible = false;
            btnSelectImageModify.Visible = false;
            btnSelectImageThumbnailModify.Visible = false;
            btnModifySave.Visible = false;
        }
        private void btnAddProductDisplay_Click(object sender, EventArgs e)
        {
            HideAllButton();
            btnAddProductDisplay.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\新增產品02.png");
            buttonModifyDisplay.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\修改產品01.png");
            btnSelectImageAdd.Visible = true;
            btnSelectImageThumbnailAdd.Visible = true;
            btnAddSave.Visible = true;
            btnClearCol.Visible = true;
        }
        private void buttonModifyDisplay_Click(object sender, EventArgs e)
        {
            HideAllButton();
            btnAddProductDisplay.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\新增產品01.png");
            buttonModifyDisplay.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\修改產品02.png");
            btnSelectImageModify.Visible = true;
            btnSelectImageThumbnailModify.Visible = true;
            btnModifySave.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
                StaffBackend StaffBackend = new StaffBackend();
                StaffBackend.Show();
                this.Hide();
        }
    }
}
