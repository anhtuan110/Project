namespace RestaurentManager
{
    partial class FrmListBookedTable
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
            label1 = new Label();
            dgvListBookedTable = new DataGridView();
            cbTable = new ComboBox();
            timeBook = new DateTimePicker();
            rdLunch = new RadioButton();
            rdDinner = new RadioButton();
            label4 = new Label();
            label3 = new Label();
            btnUpdate = new Button();
            textSearch = new TextBox();
            btnSearch = new Button();
            label2 = new Label();
            label5 = new Label();
            tbNameCustom = new TextBox();
            tbPhoneCustom = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListBookedTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(218, 9);
            label1.Name = "label1";
            label1.Size = new Size(232, 30);
            label1.TabIndex = 0;
            label1.Text = "Danh Sách Bàn Đã Đặt";
            // 
            // dgvListBookedTable
            // 
            dgvListBookedTable.AllowUserToAddRows = false;
            dgvListBookedTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListBookedTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListBookedTable.Location = new Point(10, 212);
            dgvListBookedTable.Margin = new Padding(3, 2, 3, 2);
            dgvListBookedTable.Name = "dgvListBookedTable";
            dgvListBookedTable.RowHeadersWidth = 51;
            dgvListBookedTable.RowTemplate.Height = 29;
            dgvListBookedTable.Size = new Size(656, 210);
            dgvListBookedTable.TabIndex = 18;
            // 
            // cbTable
            // 
            cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTable.FormattingEnabled = true;
            cbTable.Location = new Point(108, 94);
            cbTable.Name = "cbTable";
            cbTable.Size = new Size(152, 23);
            cbTable.TabIndex = 19;
            // 
            // timeBook
            // 
            timeBook.Format = DateTimePickerFormat.Time;
            timeBook.Location = new Point(108, 131);
            timeBook.Name = "timeBook";
            timeBook.Size = new Size(152, 23);
            timeBook.TabIndex = 20;
            // 
            // rdLunch
            // 
            rdLunch.AutoSize = true;
            rdLunch.Location = new Point(108, 171);
            rdLunch.Name = "rdLunch";
            rdLunch.Size = new Size(70, 19);
            rdLunch.TabIndex = 21;
            rdLunch.TabStop = true;
            rdLunch.Text = "Bữa Trưa";
            rdLunch.UseVisualStyleBackColor = true;
            // 
            // rdDinner
            // 
            rdDinner.AutoSize = true;
            rdDinner.Location = new Point(196, 171);
            rdDinner.Name = "rdDinner";
            rdDinner.Size = new Size(64, 19);
            rdDinner.TabIndex = 22;
            rdDinner.TabStop = true;
            rdDinner.Text = "Bữa Tối";
            rdDinner.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 97);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 23;
            label4.Text = "Chọn bàn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 137);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 24;
            label3.Text = "Chọn giờ";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(319, 171);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(82, 22);
            btnUpdate.TabIndex = 25;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            textSearch.Location = new Point(173, 52);
            textSearch.Margin = new Padding(3, 2, 3, 2);
            textSearch.Name = "textSearch";
            textSearch.Size = new Size(225, 23);
            textSearch.TabIndex = 26;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(425, 52);
            btnSearch.Margin = new Padding(3, 2, 3, 2);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(82, 23);
            btnSearch.TabIndex = 27;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(319, 97);
            label2.Name = "label2";
            label2.Size = new Size(79, 15);
            label2.TabIndex = 28;
            label2.Text = "Tên người đặt";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(319, 139);
            label5.Name = "label5";
            label5.Size = new Size(76, 15);
            label5.TabIndex = 29;
            label5.Text = "Số điện thoại";
            // 
            // tbNameCustom
            // 
            tbNameCustom.Location = new Point(412, 94);
            tbNameCustom.Name = "tbNameCustom";
            tbNameCustom.Size = new Size(152, 23);
            tbNameCustom.TabIndex = 30;
            // 
            // tbPhoneCustom
            // 
            tbPhoneCustom.Location = new Point(412, 134);
            tbPhoneCustom.Name = "tbPhoneCustom";
            tbPhoneCustom.Size = new Size(152, 23);
            tbPhoneCustom.TabIndex = 31;
            // 
            // FrmListBookedTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 426);
            Controls.Add(tbPhoneCustom);
            Controls.Add(tbNameCustom);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(btnSearch);
            Controls.Add(textSearch);
            Controls.Add(btnUpdate);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(rdDinner);
            Controls.Add(rdLunch);
            Controls.Add(timeBook);
            Controls.Add(cbTable);
            Controls.Add(dgvListBookedTable);
            Controls.Add(label1);
            Name = "FrmListBookedTable";
            Text = "FrmListBookedTable";
            Load += FrmListBookedTable_Load;
            ((System.ComponentModel.ISupportInitialize)dgvListBookedTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvListBookedTable;
        private ComboBox cbTable;
        private DateTimePicker timeBook;
        private RadioButton rdLunch;
        private RadioButton rdDinner;
        private Label label4;
        private Label label3;
        private Button btnUpdate;
        private TextBox textSearch;
        private Button btnSearch;
        private Label label2;
        private Label label5;
        private TextBox tbNameCustom;
        private TextBox tbPhoneCustom;
    }
}