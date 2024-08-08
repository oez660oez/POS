namespace IceShop
{
    partial class ShoppingCart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCloseForm = new System.Windows.Forms.Label();
            this.pnlFormTitle = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblShoppingTotalCost = new System.Windows.Forms.Label();
            this.btnPruchase = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReChoose = new System.Windows.Forms.Button();
            this.pnlFormTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCloseForm
            // 
            this.lblCloseForm.AutoSize = true;
            this.lblCloseForm.BackColor = System.Drawing.Color.Transparent;
            this.lblCloseForm.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCloseForm.ForeColor = System.Drawing.Color.White;
            this.lblCloseForm.Location = new System.Drawing.Point(762, 7);
            this.lblCloseForm.Name = "lblCloseForm";
            this.lblCloseForm.Size = new System.Drawing.Size(26, 26);
            this.lblCloseForm.TabIndex = 1;
            this.lblCloseForm.Text = "X";
            this.lblCloseForm.Click += new System.EventHandler(this.lblCloseForm_Click);
            // 
            // pnlFormTitle
            // 
            this.pnlFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.pnlFormTitle.Controls.Add(this.lblCloseForm);
            this.pnlFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlFormTitle.Name = "pnlFormTitle";
            this.pnlFormTitle.Size = new System.Drawing.Size(800, 37);
            this.pnlFormTitle.TabIndex = 1;
            this.pnlFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlFormTitle_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IceShop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(338, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 124);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblProductName
            // 
            this.lblProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.lblProductName.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.ForeColor = System.Drawing.Color.White;
            this.lblProductName.Location = new System.Drawing.Point(0, 187);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(800, 68);
            this.lblProductName.TabIndex = 28;
            this.lblProductName.Text = "已選商品";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(230, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 42);
            this.label2.TabIndex = 30;
            this.label2.Text = "總金額";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(334, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 42);
            this.label3.TabIndex = 31;
            this.label3.Text = "$";
            // 
            // lblShoppingTotalCost
            // 
            this.lblShoppingTotalCost.AutoSize = true;
            this.lblShoppingTotalCost.BackColor = System.Drawing.Color.Transparent;
            this.lblShoppingTotalCost.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoppingTotalCost.ForeColor = System.Drawing.Color.White;
            this.lblShoppingTotalCost.Location = new System.Drawing.Point(363, 0);
            this.lblShoppingTotalCost.Name = "lblShoppingTotalCost";
            this.lblShoppingTotalCost.Size = new System.Drawing.Size(38, 42);
            this.lblShoppingTotalCost.TabIndex = 32;
            this.lblShoppingTotalCost.Text = "0";
            // 
            // btnPruchase
            // 
            this.btnPruchase.BackgroundImage = global::IceShop.Properties.Resources.付款按鈕;
            this.btnPruchase.FlatAppearance.BorderSize = 0;
            this.btnPruchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPruchase.Location = new System.Drawing.Point(637, 877);
            this.btnPruchase.Name = "btnPruchase";
            this.btnPruchase.Size = new System.Drawing.Size(152, 146);
            this.btnPruchase.TabIndex = 33;
            this.btnPruchase.UseVisualStyleBackColor = true;
            this.btnPruchase.Click += new System.EventHandler(this.btnPruchase_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.panel1.Controls.Add(this.lblShoppingTotalCost);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 930);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 44);
            this.panel1.TabIndex = 34;
            // 
            // btnReChoose
            // 
            this.btnReChoose.BackgroundImage = global::IceShop.Properties.Resources.重新選購按鈕;
            this.btnReChoose.FlatAppearance.BorderSize = 0;
            this.btnReChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReChoose.Location = new System.Drawing.Point(0, 59);
            this.btnReChoose.Name = "btnReChoose";
            this.btnReChoose.Size = new System.Drawing.Size(75, 106);
            this.btnReChoose.TabIndex = 35;
            this.btnReChoose.UseVisualStyleBackColor = true;
            this.btnReChoose.Click += new System.EventHandler(this.btnReChoose_Click);
            // 
            // ShoppingCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 1030);
            this.Controls.Add(this.btnReChoose);
            this.Controls.Add(this.btnPruchase);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlFormTitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ShoppingCart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShoppingCart";
            this.Activated += new System.EventHandler(this.ShoppingCart_Activated);
            this.Load += new System.EventHandler(this.ShoppingCart_Load);
            this.pnlFormTitle.ResumeLayout(false);
            this.pnlFormTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCloseForm;
        private System.Windows.Forms.Panel pnlFormTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblShoppingTotalCost;
        private System.Windows.Forms.Button btnPruchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnReChoose;
    }
}