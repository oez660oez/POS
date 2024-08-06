using IceShop.ShavedSnowDetailFolder;
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
    public partial class ShavedSnow : Form
    {
        private Form1 mainForm;
        SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
        List<int> listId = new List<int>();
        List<string> listProductName = new List<string>();

        public ShavedSnow(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
        }
        private void ShavedSnow_Load(object sender, EventArgs e)
        {
            LoadProductDatabase();
        }

        void LoadProductDatabase()
        {
            try
            {
                SqlConnection con = new SqlConnection(GlobalVar.strDBConnectionString);
                con.Open();
                string strSQL = "select top 200 * from product where ProductCategory = 1;";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd.ExecuteReader();

                int count = 0;
                int xOffset = 5;
                int yOffset = 0;
                int buttonWidth = 198;
                int buttonHeight = 238;
                int buttonsPerRow = 4;

                while (reader.Read())
                {
                    listId.Add((int)reader["ProductId"]);
                    string image_name = (string)reader["ProductImage"];
                    string FullImagePath = $"{GlobalVar.image_dir}\\綿綿冰\\{image_name}";
                    Console.WriteLine(FullImagePath);

                    using (FileStream fs = File.OpenRead(FullImagePath))
                    {
                        Image imgProductImage = Image.FromStream(fs);

                        Button dbutton = new Button
                        {
                            BackColor = Color.Transparent,
                            BackgroundImage = imgProductImage,
                            BackgroundImageLayout = ImageLayout.Stretch,
                            FlatStyle = FlatStyle.Flat,
                            Text = "",
                            FlatAppearance = { BorderSize = 0 },
                            Size = new Size(buttonWidth, buttonHeight),
                            Location = new Point(xOffset + (count % buttonsPerRow) * (buttonWidth), yOffset + (count / buttonsPerRow) * (buttonHeight)),
                            Name = $"btn{count}",
                            Tag = listId[count]
                        };

                        dbutton.Click += new EventHandler(dbutton_Click);
                        Controls.Add(dbutton);
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
                OriginalMilkShavedSnow originalMilkShavedSnow = new OriginalMilkShavedSnow(mainForm, productId);
                mainForm.ShowProductDetail(originalMilkShavedSnow);
            }
        }
    }
}
