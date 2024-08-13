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
            this.btnMemberSearchPicture = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            // btnMemberSearchPicture
            // 
            this.btnMemberSearchPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(227)))));
            this.btnMemberSearchPicture.BackgroundImage = global::IceShop.Properties.Resources.會員資料查詢01;
            this.btnMemberSearchPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMemberSearchPicture.FlatAppearance.BorderSize = 0;
            this.btnMemberSearchPicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemberSearchPicture.Location = new System.Drawing.Point(37, 95);
            this.btnMemberSearchPicture.Name = "btnMemberSearchPicture";
            this.btnMemberSearchPicture.Size = new System.Drawing.Size(118, 118);
            this.btnMemberSearchPicture.TabIndex = 33;
            this.btnMemberSearchPicture.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 276);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 138);
            this.button1.TabIndex = 34;
            this.button1.Text = "回到主選單";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(496, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 138);
            this.button2.TabIndex = 35;
            this.button2.Text = "產品新刪修";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(58, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 138);
            this.button3.TabIndex = 36;
            this.button3.Text = "指定會員訂單查詢修改";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // StaffBackend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 530);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMemberSearchPicture);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StaffBackend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffBackend";
            this.pnlFormTitle.ResumeLayout(false);
            this.pnlFormTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCloseForm;
        private System.Windows.Forms.Panel pnlFormTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMemberSearchPicture;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}