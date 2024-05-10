namespace RestaurentManager
{
    partial class fAccountProfile
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
            panel2 = new Panel();
            txtUserName = new TextBox();
            lbUser = new Label();
            panel1 = new Panel();
            txtDisplayName = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            txtPassWord = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            txtNewPass = new TextBox();
            label3 = new Label();
            panel5 = new Panel();
            txtReEnterPass = new TextBox();
            label4 = new Label();
            btnUpdate = new Button();
            btnExit = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(lbUser);
            panel2.Location = new Point(21, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 54);
            panel2.TabIndex = 1;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(172, 16);
            txtUserName.Name = "txtUserName";
            txtUserName.ReadOnly = true;
            txtUserName.Size = new Size(455, 27);
            txtUserName.TabIndex = 1;
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Location = new Point(16, 19);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(119, 20);
            lbUser.TabIndex = 0;
            lbUser.Text = "Tên Đăng  Nhập:";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtDisplayName);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(21, 87);
            panel1.Name = "panel1";
            panel1.Size = new Size(676, 54);
            panel1.TabIndex = 2;
            // 
            // txtDisplayName
            // 
            txtDisplayName.Location = new Point(172, 16);
            txtDisplayName.Name = "txtDisplayName";
            txtDisplayName.Size = new Size(455, 27);
            txtDisplayName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 19);
            label1.Name = "label1";
            label1.Size = new Size(94, 20);
            label1.TabIndex = 0;
            label1.Text = "Tên Hiển Thị:";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPassWord);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(21, 160);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 54);
            panel3.TabIndex = 3;
            // 
            // txtPassWord
            // 
            txtPassWord.Location = new Point(172, 16);
            txtPassWord.Name = "txtPassWord";
            txtPassWord.Size = new Size(455, 27);
            txtPassWord.TabIndex = 1;
            txtPassWord.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 19);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 0;
            label2.Text = "Mật Khẩu:";
            // 
            // panel4
            // 
            panel4.Controls.Add(txtNewPass);
            panel4.Controls.Add(label3);
            panel4.Location = new Point(21, 236);
            panel4.Name = "panel4";
            panel4.Size = new Size(676, 54);
            panel4.TabIndex = 4;
            // 
            // txtNewPass
            // 
            txtNewPass.Location = new Point(172, 16);
            txtNewPass.Name = "txtNewPass";
            txtNewPass.Size = new Size(455, 27);
            txtNewPass.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 19);
            label3.Name = "label3";
            label3.Size = new Size(105, 20);
            label3.TabIndex = 0;
            label3.Text = "Mật Khẩu Mới:";
            // 
            // panel5
            // 
            panel5.Controls.Add(txtReEnterPass);
            panel5.Controls.Add(label4);
            panel5.Location = new Point(21, 308);
            panel5.Name = "panel5";
            panel5.Size = new Size(676, 54);
            panel5.TabIndex = 5;
            // 
            // txtReEnterPass
            // 
            txtReEnterPass.Location = new Point(172, 16);
            txtReEnterPass.Name = "txtReEnterPass";
            txtReEnterPass.Size = new Size(455, 27);
            txtReEnterPass.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 19);
            label4.Name = "label4";
            label4.Size = new Size(165, 20);
            label4.TabIndex = 0;
            label4.Text = "Nhập lại Mật Khẩu Mới:";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(539, 392);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Cập Nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(649, 392);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 7;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // fAccountProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnUpdate);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "fAccountProfile";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thông tin cá nhân";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox txtUserName;
        private Label lbUser;
        private Panel panel1;
        private TextBox txtDisplayName;
        private Label label1;
        private Panel panel3;
        private TextBox txtPassWord;
        private Label label2;
        private Panel panel4;
        private TextBox txtNewPass;
        private Label label3;
        private Panel panel5;
        private TextBox txtReEnterPass;
        private Label label4;
        private Button btnUpdate;
        private Button btnExit;
    }
}