namespace RestaurentManager
{
    partial class fLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnExit = new Button();
            btnLogin = new Button();
            panel3 = new Panel();
            txtPass = new TextBox();
            lbPass = new Label();
            panel2 = new Panel();
            txtUserName = new TextBox();
            lbUser = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(742, 281);
            panel1.TabIndex = 0;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(584, 202);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 3;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(440, 198);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(94, 29);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPass);
            panel3.Controls.Add(lbPass);
            panel3.Location = new Point(25, 93);
            panel3.Name = "panel3";
            panel3.Size = new Size(676, 62);
            panel3.TabIndex = 1;
            // 
            // txtPass
            // 
            txtPass.Location = new Point(172, 18);
            txtPass.Name = "txtPass";
            txtPass.Size = new Size(455, 27);
            txtPass.TabIndex = 1;
            txtPass.UseSystemPasswordChar = true;
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.Location = new Point(29, 21);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(75, 20);
            lbPass.TabIndex = 0;
            lbPass.Text = "Mật Khẩu:";
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUserName);
            panel2.Controls.Add(lbUser);
            panel2.Location = new Point(25, 24);
            panel2.Name = "panel2";
            panel2.Size = new Size(676, 54);
            panel2.TabIndex = 0;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(172, 16);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(455, 27);
            txtUserName.TabIndex = 1;
            // 
            // lbUser
            // 
            lbUser.AutoSize = true;
            lbUser.Location = new Point(17, 19);
            lbUser.Name = "lbUser";
            lbUser.Size = new Size(119, 20);
            lbUser.TabIndex = 0;
            lbUser.Text = "Tên Đăng  Nhập:";
            // 
            // fLogin
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnExit;
            ClientSize = new Size(766, 305);
            Controls.Add(panel1);
            Name = "fLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "fLogin";
            FormClosing += Form1_FormClosing;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private TextBox txtPass;
        private Label lbPass;
        private Panel panel2;
        private TextBox txtUserName;
        private Label lbUser;
        private Button btnExit;
        private Button btnLogin;
    }
}