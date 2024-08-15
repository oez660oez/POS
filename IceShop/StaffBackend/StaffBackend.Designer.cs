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
            this.btnClock = new System.Windows.Forms.Button();
            this.btnCalculateMoney = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnChooseMemberOrder = new System.Windows.Forms.Button();
            this.btnProductAddModify = new System.Windows.Forms.Button();
            this.btnMemberModify = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.pnlFormTitle.TabIndex = 31;
            this.pnlFormTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlFormTitle_MouseMove);
            // 
            // btnClock
            // 
            this.btnClock.BackgroundImage = global::IceShop.Properties.Resources.打卡系統;
            this.btnClock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClock.FlatAppearance.BorderSize = 0;
            this.btnClock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClock.Location = new System.Drawing.Point(343, 394);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(125, 125);
            this.btnClock.TabIndex = 113;
            this.btnClock.UseVisualStyleBackColor = true;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // btnCalculateMoney
            // 
            this.btnCalculateMoney.BackgroundImage = global::IceShop.Properties.Resources.計算營業額按鈕;
            this.btnCalculateMoney.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCalculateMoney.FlatAppearance.BorderSize = 0;
            this.btnCalculateMoney.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculateMoney.Location = new System.Drawing.Point(602, 217);
            this.btnCalculateMoney.Name = "btnCalculateMoney";
            this.btnCalculateMoney.Size = new System.Drawing.Size(125, 125);
            this.btnCalculateMoney.TabIndex = 112;
            this.btnCalculateMoney.UseVisualStyleBackColor = true;
            this.btnCalculateMoney.Click += new System.EventHandler(this.btnCalculateMoney_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.BackgroundImage = global::IceShop.Properties.Resources.返回按鈕;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(602, 394);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 125);
            this.btnBack.TabIndex = 111;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnChooseMemberOrder
            // 
            this.btnChooseMemberOrder.BackgroundImage = global::IceShop.Properties.Resources.會員訂單查詢按鈕;
            this.btnChooseMemberOrder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnChooseMemberOrder.FlatAppearance.BorderSize = 0;
            this.btnChooseMemberOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChooseMemberOrder.Location = new System.Drawing.Point(71, 394);
            this.btnChooseMemberOrder.Name = "btnChooseMemberOrder";
            this.btnChooseMemberOrder.Size = new System.Drawing.Size(125, 125);
            this.btnChooseMemberOrder.TabIndex = 36;
            this.btnChooseMemberOrder.UseVisualStyleBackColor = true;
            this.btnChooseMemberOrder.Click += new System.EventHandler(this.btnChooseMemberOrder_Click);
            // 
            // btnProductAddModify
            // 
            this.btnProductAddModify.BackgroundImage = global::IceShop.Properties.Resources.產品新刪修按鈕;
            this.btnProductAddModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProductAddModify.FlatAppearance.BorderSize = 0;
            this.btnProductAddModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductAddModify.Location = new System.Drawing.Point(343, 217);
            this.btnProductAddModify.Name = "btnProductAddModify";
            this.btnProductAddModify.Size = new System.Drawing.Size(125, 125);
            this.btnProductAddModify.TabIndex = 35;
            this.btnProductAddModify.UseVisualStyleBackColor = true;
            this.btnProductAddModify.Click += new System.EventHandler(this.btnProductAddModify_Click);
            // 
            // btnMemberModify
            // 
            this.btnMemberModify.BackColor = System.Drawing.Color.White;
            this.btnMemberModify.BackgroundImage = global::IceShop.Properties.Resources.會員查詢修改按鈕;
            this.btnMemberModify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMemberModify.FlatAppearance.BorderSize = 0;
            this.btnMemberModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberModify.Location = new System.Drawing.Point(71, 217);
            this.btnMemberModify.Name = "btnMemberModify";
            this.btnMemberModify.Size = new System.Drawing.Size(125, 125);
            this.btnMemberModify.TabIndex = 33;
            this.btnMemberModify.UseVisualStyleBackColor = false;
            this.btnMemberModify.Click += new System.EventHandler(this.btnMemberModify_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::IceShop.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(343, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 124);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // StaffBackend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 578);
            this.Controls.Add(this.btnClock);
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
        private System.Windows.Forms.Button btnClock;
    }
}