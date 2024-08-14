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
    public partial class StaffBackend : Form
    {
        public StaffBackend()
        {
            InitializeComponent();
        }

        private void StaffBackend_Load(object sender, EventArgs e)
        {

        }

        private void btnMemberModify_Click(object sender, EventArgs e)
        {
            MemberBackend MemberBackend = new MemberBackend();
            MemberBackend.Show();
            this.Hide();
        }

        private void btnProductAddModify_Click(object sender, EventArgs e)
        {
            ProductBackend BackendSystem = new ProductBackend();
            BackendSystem.Show(); // 使用 Show 而不是 ShowDialog
            this.Hide();
        }

        private void btnChooseMemberOrder_Click(object sender, EventArgs e)
        {
            OrderBackend OrderBackend = new OrderBackend();
            OrderBackend.Show();
            this.Hide();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();
            this.Hide();
        }

        private void btnCalculateMoney_Click(object sender, EventArgs e)
        {
            CalculateMoney CalculateMoney = new CalculateMoney();
            CalculateMoney.Show();
            this.Hide();
        }
    }
}
