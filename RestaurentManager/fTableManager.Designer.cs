namespace RestaurentManager
{
    partial class fTableManager
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
            pnlTable = new Panel();
            flpTable = new FlowLayoutPanel();
            panel2 = new Panel();
            lsvBill = new ListView();
            adminToolStripMenuItem = new ToolStripMenuItem();
            infoToolStripMenuItem = new ToolStripMenuItem();
            personInfoToolStripMenuItem = new ToolStripMenuItem();
            signOutToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            panel3 = new Panel();
            cbSwitchTable = new ComboBox();
            btnSwitchTable = new Button();
            nmDisCount = new NumericUpDown();
            btnDisCount = new Button();
            btnCheckOut = new Button();
            panel4 = new Panel();
            nmFoodCount = new NumericUpDown();
            btnAddFood = new Button();
            cbFood = new ComboBox();
            cbCategory = new ComboBox();
            pnlTable.SuspendLayout();
            panel2.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmDisCount).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).BeginInit();
            SuspendLayout();
            // 
            // pnlTable
            // 
            pnlTable.Controls.Add(flpTable);
            pnlTable.Location = new Point(12, 31);
            pnlTable.Name = "pnlTable";
            pnlTable.Size = new Size(418, 527);
            pnlTable.TabIndex = 1;
            // 
            // flpTable
            // 
            flpTable.Location = new Point(3, 3);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(412, 521);
            flpTable.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lsvBill);
            panel2.Location = new Point(451, 119);
            panel2.Name = "panel2";
            panel2.Size = new Size(383, 354);
            panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            lsvBill.Location = new Point(3, 3);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(377, 348);
            lsvBill.TabIndex = 0;
            lsvBill.UseCompatibleStateImageBehavior = false;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(67, 24);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // infoToolStripMenuItem
            // 
            infoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { personInfoToolStripMenuItem, signOutToolStripMenuItem });
            infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            infoToolStripMenuItem.Size = new Size(151, 24);
            infoToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // personInfoToolStripMenuItem
            // 
            personInfoToolStripMenuItem.Name = "personInfoToolStripMenuItem";
            personInfoToolStripMenuItem.Size = new Size(224, 26);
            personInfoToolStripMenuItem.Text = "Thông tin cá nhân";
            personInfoToolStripMenuItem.Click += personInfoToolStripMenuItem_Click;
            // 
            // signOutToolStripMenuItem
            // 
            signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            signOutToolStripMenuItem.Size = new Size(224, 26);
            signOutToolStripMenuItem.Text = "Đăng Xuất";
            signOutToolStripMenuItem.Click += signOutToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, infoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(846, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // panel3
            // 
            panel3.Controls.Add(cbSwitchTable);
            panel3.Controls.Add(btnSwitchTable);
            panel3.Controls.Add(nmDisCount);
            panel3.Controls.Add(btnDisCount);
            panel3.Controls.Add(btnCheckOut);
            panel3.Location = new Point(451, 479);
            panel3.Name = "panel3";
            panel3.Size = new Size(383, 79);
            panel3.TabIndex = 3;
            // 
            // cbSwitchTable
            // 
            cbSwitchTable.FormattingEnabled = true;
            cbSwitchTable.Location = new Point(3, 48);
            cbSwitchTable.Name = "cbSwitchTable";
            cbSwitchTable.Size = new Size(109, 28);
            cbSwitchTable.TabIndex = 6;
            // 
            // btnSwitchTable
            // 
            btnSwitchTable.Location = new Point(3, 14);
            btnSwitchTable.Name = "btnSwitchTable";
            btnSwitchTable.Size = new Size(109, 29);
            btnSwitchTable.TabIndex = 5;
            btnSwitchTable.Text = "Chuyển Bàn";
            btnSwitchTable.UseVisualStyleBackColor = true;
            // 
            // nmDisCount
            // 
            nmDisCount.Location = new Point(134, 49);
            nmDisCount.Name = "nmDisCount";
            nmDisCount.Size = new Size(94, 27);
            nmDisCount.TabIndex = 4;
            nmDisCount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDisCount
            // 
            btnDisCount.Location = new Point(134, 14);
            btnDisCount.Name = "btnDisCount";
            btnDisCount.Size = new Size(94, 29);
            btnDisCount.TabIndex = 1;
            btnDisCount.Text = "Giảm giá";
            btnDisCount.UseVisualStyleBackColor = true;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(289, 14);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(94, 62);
            btnCheckOut.TabIndex = 0;
            btnCheckOut.Text = "Thanh Toán";
            btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(nmFoodCount);
            panel4.Controls.Add(btnAddFood);
            panel4.Controls.Add(cbFood);
            panel4.Controls.Add(cbCategory);
            panel4.Location = new Point(454, 31);
            panel4.Name = "panel4";
            panel4.Size = new Size(377, 82);
            panel4.TabIndex = 4;
            // 
            // nmFoodCount
            // 
            nmFoodCount.Location = new Point(328, 27);
            nmFoodCount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmFoodCount.Name = "nmFoodCount";
            nmFoodCount.Size = new Size(46, 27);
            nmFoodCount.TabIndex = 3;
            nmFoodCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(220, 7);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(94, 63);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm Món";
            btnAddFood.UseVisualStyleBackColor = true;
            // 
            // cbFood
            // 
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(7, 42);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(207, 28);
            cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(7, 7);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(207, 28);
            cbCategory.TabIndex = 0;
            // 
            // fTableManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 570);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "fTableManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm Quản lý nhà hàng";
            pnlTable.ResumeLayout(false);
            panel2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmDisCount).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nmFoodCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTable;
        private Panel panel2;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private ToolStripMenuItem personInfoToolStripMenuItem;
        private ToolStripMenuItem signOutToolStripMenuItem;
        private MenuStrip menuStrip1;
        private Panel panel3;
        private ListView lsvBill;
        private Panel panel4;
        private NumericUpDown nmFoodCount;
        private Button btnAddFood;
        private ComboBox cbFood;
        private ComboBox cbCategory;
        private FlowLayoutPanel flpTable;
        private ComboBox cbSwitchTable;
        private Button btnSwitchTable;
        private NumericUpDown nmDisCount;
        private Button btnDisCount;
        private Button btnCheckOut;
    }
}