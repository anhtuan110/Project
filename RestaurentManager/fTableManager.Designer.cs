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
            thôngTinToolStripMenuItem = new ToolStripMenuItem();
            thôngTinCáNhToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            panel3 = new Panel();
            label2 = new Label();
            tbOldTableID = new TextBox();
            tbTotalMoney = new TextBox();
            label1 = new Label();
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
            stt = new ColumnHeader();
            idFood = new ColumnHeader();
            foodName = new ColumnHeader();
            price = new ColumnHeader();
            quantity = new ColumnHeader();
            total = new ColumnHeader();
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
            flpTable.Margin = new Padding(10);
            flpTable.Name = "flpTable";
            flpTable.Size = new Size(412, 521);
            flpTable.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(lsvBill);
            panel2.Location = new Point(451, 119);
            panel2.Name = "panel2";
            panel2.Size = new Size(545, 354);
            panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            lsvBill.Columns.AddRange(new ColumnHeader[] { stt, idFood, foodName, price, quantity, total });
            lsvBill.GridLines = true;
            lsvBill.Location = new Point(0, 0);
            lsvBill.Name = "lsvBill";
            lsvBill.Size = new Size(542, 348);
            lsvBill.TabIndex = 0;
            lsvBill.TileSize = new Size(100, 100);
            lsvBill.UseCompatibleStateImageBehavior = false;
            lsvBill.View = View.Details;
            lsvBill.SelectedIndexChanged += lsvBill_SelectedIndexChanged;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(67, 24);
            adminToolStripMenuItem.Text = "Admin";
            adminToolStripMenuItem.Click += adminToolStripMenuItem_Click;
            // 
            // thôngTinToolStripMenuItem
            // 
            thôngTinToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thôngTinCáNhToolStripMenuItem, đăngXuấtToolStripMenuItem });
            thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            thôngTinToolStripMenuItem.Size = new Size(151, 24);
            thôngTinToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhToolStripMenuItem
            // 
            thôngTinCáNhToolStripMenuItem.Name = "thôngTinCáNhToolStripMenuItem";
            thôngTinCáNhToolStripMenuItem.Size = new Size(210, 26);
            thôngTinCáNhToolStripMenuItem.Text = "Thông tin cá nhân";
            thôngTinCáNhToolStripMenuItem.Click += thôngTinCáNhToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(210, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            đăngXuấtToolStripMenuItem.Click += đăngXuấtToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { adminToolStripMenuItem, thôngTinToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1020, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tbOldTableID);
            panel3.Controls.Add(tbTotalMoney);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(cbSwitchTable);
            panel3.Controls.Add(btnSwitchTable);
            panel3.Controls.Add(nmDisCount);
            panel3.Controls.Add(btnDisCount);
            panel3.Controls.Add(btnCheckOut);
            panel3.Cursor = Cursors.Hand;
            panel3.Location = new Point(451, 479);
            panel3.Name = "panel3";
            panel3.Size = new Size(545, 79);
            panel3.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(369, 23);
            label2.Name = "label2";
            label2.Size = new Size(62, 20);
            label2.TabIndex = 10;
            label2.Text = "Id table";
            // 
            // tbOldTableID
            // 
            tbOldTableID.Enabled = false;
            tbOldTableID.HideSelection = false;
            tbOldTableID.Location = new Point(376, 51);
            tbOldTableID.Name = "tbOldTableID";
            tbOldTableID.Size = new Size(53, 27);
            tbOldTableID.TabIndex = 9;
            // 
            // tbTotalMoney
            // 
            tbTotalMoney.Enabled = false;
            tbTotalMoney.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            tbTotalMoney.Location = new Point(215, 49);
            tbTotalMoney.Name = "tbTotalMoney";
            tbTotalMoney.Size = new Size(155, 30);
            tbTotalMoney.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(215, 18);
            label1.Name = "label1";
            label1.Size = new Size(123, 28);
            label1.TabIndex = 7;
            label1.Text = "Thành Tiền:";
            // 
            // cbSwitchTable
            // 
            cbSwitchTable.FormattingEnabled = true;
            cbSwitchTable.Location = new Point(0, 49);
            cbSwitchTable.Name = "cbSwitchTable";
            cbSwitchTable.Size = new Size(109, 28);
            cbSwitchTable.TabIndex = 6;
            // 
            // btnSwitchTable
            // 
            btnSwitchTable.Location = new Point(0, 14);
            btnSwitchTable.Name = "btnSwitchTable";
            btnSwitchTable.Size = new Size(109, 29);
            btnSwitchTable.TabIndex = 5;
            btnSwitchTable.Text = "Chuyển Bàn";
            btnSwitchTable.UseVisualStyleBackColor = true;
            btnSwitchTable.Click += btnSwitchTable_Click;
            // 
            // nmDisCount
            // 
            nmDisCount.Location = new Point(115, 52);
            nmDisCount.Name = "nmDisCount";
            nmDisCount.Size = new Size(94, 27);
            nmDisCount.TabIndex = 4;
            nmDisCount.TextAlign = HorizontalAlignment.Center;
            // 
            // btnDisCount
            // 
            btnDisCount.Location = new Point(115, 14);
            btnDisCount.Name = "btnDisCount";
            btnDisCount.Size = new Size(94, 29);
            btnDisCount.TabIndex = 1;
            btnDisCount.Text = "Giảm giá";
            btnDisCount.UseVisualStyleBackColor = true;
            btnDisCount.Click += btnDisCount_Click;
            // 
            // btnCheckOut
            // 
            btnCheckOut.Location = new Point(435, 18);
            btnCheckOut.Name = "btnCheckOut";
            btnCheckOut.Size = new Size(107, 61);
            btnCheckOut.TabIndex = 0;
            btnCheckOut.Text = "Thanh Toán";
            btnCheckOut.UseVisualStyleBackColor = true;
            btnCheckOut.Click += btnCheckOut_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(nmFoodCount);
            panel4.Controls.Add(btnAddFood);
            panel4.Controls.Add(cbFood);
            panel4.Controls.Add(cbCategory);
            panel4.Location = new Point(454, 31);
            panel4.Name = "panel4";
            panel4.Size = new Size(542, 82);
            panel4.TabIndex = 4;
            // 
            // nmFoodCount
            // 
            nmFoodCount.Location = new Point(454, 26);
            nmFoodCount.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            nmFoodCount.Name = "nmFoodCount";
            nmFoodCount.Size = new Size(75, 27);
            nmFoodCount.TabIndex = 3;
            nmFoodCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(301, 7);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(136, 63);
            btnAddFood.TabIndex = 2;
            btnAddFood.Text = "Thêm Món";
            btnAddFood.UseVisualStyleBackColor = true;
            // 
            // cbFood
            // 
            cbFood.FormattingEnabled = true;
            cbFood.Location = new Point(7, 42);
            cbFood.Name = "cbFood";
            cbFood.Size = new Size(263, 28);
            cbFood.TabIndex = 1;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(7, 7);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(263, 28);
            cbCategory.TabIndex = 0;
            // 
            // stt
            // 
            stt.Text = "STT";
            stt.Width = 40;
            // 
            // idFood
            // 
            idFood.Text = "ID Food";
            idFood.Width = 70;
            // 
            // foodName
            // 
            foodName.Text = "Food Name";
            foodName.Width = 180;
            // 
            // price
            // 
            price.Text = "Price";
            price.Width = 80;
            // 
            // quantity
            // 
            quantity.Text = "Quantity";
            // 
            // total
            // 
            total.Text = "Total Food";
            total.Width = 120;
            // 
            // fTableManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 570);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pnlTable);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "fTableManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phần mềm Quản lý quán Cafe";
            Load += fTableManager_Load;
            pnlTable.ResumeLayout(false);
            panel2.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private ToolStripMenuItem thôngTinToolStripMenuItem;
        private ToolStripMenuItem thôngTinCáNhToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
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
        private Label label1;
        private TextBox tbTotalMoney;
        private TextBox tbOldTableID;
        private Label label2;
        private ColumnHeader stt;
        private ColumnHeader idFood;
        private ColumnHeader foodName;
        private ColumnHeader price;
        private ColumnHeader quantity;
        private ColumnHeader total;
    }
}