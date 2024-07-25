using System;
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
            btnShavedIce02.Visible = false;
            btnShavedSnow02.Visible = false;
            btnGrassJelly02.Visible = false;
            btnSeasonal02.Visible = false;
            btnDrinks02.Visible = false;
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

        private void pnlShavedIce_Click(object sender, EventArgs e)
        {
            btnShavedIce01.Visible = false;
            btnShavedIce02.Visible = true;
            btnShavedSnow01.Visible = true;
            btnShavedSnow02.Visible = false;
            btnGrassJelly01.Visible = true;
            btnGrassJelly02.Visible = false;
            btnSeasonal01.Visible = true;
            btnSeasonal02.Visible = false;
            btnDrinks01.Visible = true;
            btnDrinks02.Visible = false;
            pnlShow.Controls.Clear();
            ShavedIce shavedIce = new ShavedIce() { TopLevel = false, TopMost = false };
            shavedIce.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(shavedIce);
            shavedIce.Show();
        }

        private void pnlShavedSnow_Click(object sender, EventArgs e)
        {
            btnShavedIce01.Visible = true;
            btnShavedIce02.Visible = false;
            btnShavedSnow01.Visible = false;
            btnShavedSnow02.Visible = true;
            btnGrassJelly01.Visible = true;
            btnGrassJelly02.Visible = false;
            btnSeasonal01.Visible = true;
            btnSeasonal02.Visible = false;
            btnDrinks01.Visible = true;
            btnDrinks02.Visible = false;
            pnlShow.Controls.Clear();
            ShavedSnow ShavedSnow = new ShavedSnow() { TopLevel = false, TopMost = false };
            ShavedSnow.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(ShavedSnow);
            ShavedSnow.Show();
        }
        private void pnlGrassJelly_Click(object sender, EventArgs e)
        {
            btnShavedIce01.Visible = true;
            btnShavedIce02.Visible = false;
            btnShavedSnow01.Visible = true;
            btnShavedSnow02.Visible = false;
            btnGrassJelly01.Visible = false;
            btnGrassJelly02.Visible = true;
            btnSeasonal01.Visible = true;
            btnSeasonal02.Visible = false;
            btnDrinks01.Visible = true;
            btnDrinks02.Visible = false;
            pnlShow.Controls.Clear();
            GrassJelly GrassJelly = new GrassJelly() { TopLevel = false, TopMost = false };
            GrassJelly.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(GrassJelly);
            GrassJelly.Show();
        }

        private void pnlSeasonal_Click(object sender, EventArgs e)
        {
            btnShavedIce01.Visible = true;
            btnShavedIce02.Visible = false;
            btnShavedSnow01.Visible = true;
            btnShavedSnow02.Visible = false;
            btnGrassJelly01.Visible = true;
            btnGrassJelly02.Visible = false;
            btnSeasonal01.Visible = false;
            btnSeasonal02.Visible = true;
            btnDrinks01.Visible = true;
            btnDrinks02.Visible = false;
            pnlShow.Controls.Clear();
            Seasonal Seasonal = new Seasonal() { TopLevel = false, TopMost = false };
            Seasonal.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(Seasonal);
            Seasonal.Show();
        }

        private void pnlDrinks_Click(object sender, EventArgs e)
        {
            btnShavedIce01.Visible = true;
            btnShavedIce02.Visible = false;
            btnShavedSnow01.Visible = true;
            btnShavedSnow02.Visible = false;
            btnGrassJelly01.Visible = true;
            btnGrassJelly02.Visible = false;
            btnSeasonal01.Visible = true;
            btnSeasonal02.Visible = false;
            btnDrinks01.Visible = false;
            btnDrinks02.Visible = true;
            pnlShow.Controls.Clear();
            Drinks Drinks = new Drinks() { TopLevel = false, TopMost = false };
            Drinks.FormBorderStyle = FormBorderStyle.None;
            pnlShow.Controls.Add(Drinks);
            Drinks.Show();
        }
    }
}
