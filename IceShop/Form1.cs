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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageChange();
            ShowTotalCost();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            ShowTotalCost();
        }
        private void lblCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pnlFormTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point loc1 = MousePosition;
                Location = loc1;
            }
        }
        void ImageChange()
        {
            btnShavedSnow01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\綿綿冰系列01.png");
            btnShavedIce01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\刨冰系列01.png");
            btnGrassJelly01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\仙草系列01.png");
            btnSeasonal01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\季節限定01.png");
            btnDrinks01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\飲品系列01.png");
        }
        void ShowProductImage()
        {
            ProductThumbnails ProductThumbnails = new ProductThumbnails(this) { TopLevel = false, TopMost = false }; // 傳遞Form1的實例
            ProductThumbnails.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(ProductThumbnails);
            ProductThumbnails.Show();
        }
        private void pnlShavedSnow_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(1);
            ImageChange();
            btnShavedSnow01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\綿綿冰系列02.png");
            pnlShow.Controls.Clear();
            ShowProductImage();
        }
        private void pnlShavedIce_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(2);
            ImageChange();
            btnShavedIce01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\刨冰系列02.png");
            pnlShow.Controls.Clear();
            ShowProductImage();
        }
        private void pnlGrassJelly_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(3);
            ImageChange();
            btnGrassJelly01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\仙草系列02.png");
            pnlShow.Controls.Clear();
            ShowProductImage();
        }

        private void pnlSeasonal_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(4);
            ImageChange();
            btnSeasonal01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\季節限定02.png");
            pnlShow.Controls.Clear();
            ShowProductImage();
        }

        private void pnlDrinks_Click(object sender, EventArgs e)
        {
            GlobalVar.listChooseCategory.Clear();
            GlobalVar.listChooseCategory.Add(5);
            ImageChange();
            btnDrinks01.BackgroundImage = new Bitmap($"{GlobalVar.image_dir}\\飲品系列02.png");
            pnlShow.Controls.Clear();
            ShowProductImage();
        }
        public void ShowProductDetail(Form productDetailForm)
        {
            RemoveProductDetailForm();
            productDetailForm.TopLevel = false;
            productDetailForm.TopMost = false;
            productDetailForm.FormBorderStyle = FormBorderStyle.None;
            pnlShowDetail.Controls.Add(productDetailForm);
            productDetailForm.Show();
            panel1.Visible = false;
            pnlShow.Visible = false;
            panel4.Visible = false;
        }
        public void RemoveProductDetailForm()
        {
            if (pnlShowDetail.Controls.Count > 0)
            {
                var productDetailForm = pnlShowDetail.Controls[0] as Form;
                if (productDetailForm != null)
                {
                    pnlShowDetail.Controls.Remove(productDetailForm);
                    productDetailForm.Dispose();
                }
            }
        }
        public void CheckShavedSnow()
        {
            RemoveProductDetailForm();
            panel1.Visible = true;
            pnlShow.Visible = true;
            panel4.Visible = true;
            pnlShow.Controls.Clear();
            ShowTotalCost();
            ShowProductImage();
        }

        public void ShowTotalCost()
        {
            HashSet<int> uniqueProductIds = new HashSet<int>();
            int totalMoney = 0;

            foreach (ArrayList item in GlobalVar.listOrderItemCollect)
            {
                int productId = (int)item[7]; // 假設 productId 是 item 的第一個字段
                int itemTotalPrice = (int)item[4]; // item[4] 是商品總價

                uniqueProductIds.Add(productId);
                totalMoney += itemTotalPrice;
            }

            lblProductItemCount.Text = uniqueProductIds.Count.ToString();
            lblTotalMoney.Text = totalMoney.ToString();
        }
        private void btnPruchase_Click(object sender, EventArgs e)
        {
            ShoppingCart shoppingcart = new ShoppingCart();
            shoppingcart.Show(); // 使用 Show 而不是 ShowDialog
            this.Hide();
        }

        private void btnReChoose_Click(object sender, EventArgs e)
        {
            GlobalVar.listOrderItemCollect.Clear();
            ShowTotalCost();
        }
    }
}
