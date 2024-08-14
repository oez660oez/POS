namespace IceShop
{
    partial class StaffBackend
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
            this.btnMemberModify = new System.Windows.Forms.Button();
            this.btnProductAddModify = new System.Windows.Forms.Button();
            this.btnChooseMemberOrder = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCalculateMoney = new System.Windows.Forms.Button();
            this.pnlFormTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // 
            // pnlFormTitle
            // 
            this.pnlFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(51)))));
            this.pnlFormTitle.Controls.Add(this.lblCloseForm);
            this.pnlFormTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlFormTitle.Name = "pnlFormTitle";
            this.pnlFormTitle.Size = new System.Drawing.Size(800, 37);
            this.pnlFormTitle.TabIndex = 31;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IceShop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(322, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 124);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnMemberModify
            // 
            this.btnMemberModify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(227)))));
            this.btnMemberModify.BackgroundImage = global::IceShop.Properties.Resources.會員資料查詢01;
            this.btnMemberModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMemberModify.FlatAppearance.BorderSize = 0;
            this.btnMemberModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberModify.Location = new System.Drawing.Point(81, 98);
            this.btnMemberModify.Name = "btnMemberModify";
            this.btnMemberModify.Size = new System.Drawing.Size(118, 118);
            this.btnMemberModify.TabIndex = 33;
            this.btnMemberModify.UseVisualStyleBackColor = false;
            this.btnMemberModify.Click += new System.EventHandler(this.btnMemberModify_Click);
            // 
            // btnProductAddModify
            // 
            this.btnProductAddModify.Location = new System.Drawing.Point(554, 276);
            this.btnProductAddModify.Name = "btnProductAddModify";
            this.btnProductAddModify.Size = new System.Drawing.Size(167, 138);
            this.btnProductAddModify.TabIndex = 35;
            this.btnProductAddModify.Text = "產品新刪修";
            this.btnProductAddModify.UseVisualStyleBackColor = true;
            this.btnProductAddModify.Click += new System.EventHandler(this.btnProductAddModify_Click);
            // 
            // btnChooseMemberOrder
            // 
            this.btnChooseMemberOrder.Location = new System.Drawing.Point(58, 276);
            this.btnChooseMemberOrder.Name = "btnChooseMemberOrder";
            this.btnChooseMemberOrder.Size = new System.Drawing.Size(167, 138);
            this.btnChooseMemberOrder.TabIndex = 36;
            this.btnChooseMemberOrder.Text = "指定會員訂單查詢修改";
            this.btnChooseMemberOrder.UseVisualStyleBackColor = true;
            this.btnChooseMemberOrder.Click += new System.EventHandler(this.btnChooseMemberOrder_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.BackgroundImage = global::IceShop.Properties.Resources.返回按鈕;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(321, 276);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 125);
            this.btnBack.TabIndex = 111;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCalculateMoney
            // 
            this.btnCalculateMoney.Location = new System.Drawing.Point(554, 88);
            this.btnCalculateMoney.Name = "btnCalculateMoney";
            this.btnCalculateMoney.Size = new System.Drawing.Size(167, 138);
            this.btnCalculateMoney.TabIndex = 112;
            this.btnCalculateMoney.Text = "計算營業額";
            this.btnCalculateMoney.UseVisualStyleBackColor = true;
            this.btnCalculateMoney.Click += new System.EventHandler(this.btnCalculateMoney_Click);
            // 
            // StaffBackend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.btnCalculateMoney);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnChooseMemberOrder);
            this.Controls.Add(this.btnProductAddModify);
            this.Controls.Add(this.btnMemberModify);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffBackend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffBackend";
            this.Load += new System.EventHandler(this.StaffBackend_Load);
            this.pnlFormTitle.ResumeLayout(false);
            this.pnlFormTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCloseForm;
        private System.Windows.Forms.Panel pnlFormTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMemberModify;
        private System.Windows.Forms.Button btnProductAddModify;
        private System.Windows.Forms.Button btnChooseMemberOrder;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCalculateMoney;
    }
}