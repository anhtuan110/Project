namespace RestaurentManager
{
    partial class fBookTable
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
            label2 = new Label();
            timeBook = new DateTimePicker();
            cbTable = new ComboBox();
            btnBookTableAcp = new Button();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            rdLunch = new RadioButton();
            rdDinner = new RadioButton();
            tbNameCustom = new TextBox();
            label4 = new Label();
            tbPhoneCustom = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 0;
            label1.Text = "Chọn bàn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Chọn giờ";
            // 
            // timeBook
            // 
            timeBook.Format = DateTimePickerFormat.Time;
            timeBook.Location = new Point(105, 58);
            timeBook.Name = "timeBook";
            timeBook.Size = new Size(121, 23);
            timeBook.TabIndex = 3;
            // 
            // cbTable
            // 
            cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTable.FormattingEnabled = true;
            cbTable.Location = new Point(105, 18);
            cbTable.Name = "cbTable";
            cbTable.Size = new Size(121, 23);
            cbTable.TabIndex = 5;
            // 
            // btnBookTableAcp
            // 
            btnBookTableAcp.Cursor = Cursors.Hand;
            btnBookTableAcp.Location = new Point(86, 217);
            btnBookTableAcp.Name = "btnBookTableAcp";
            btnBookTableAcp.Size = new Size(75, 23);
            btnBookTableAcp.TabIndex = 6;
            btnBookTableAcp.Text = "Xác Nhận";
            btnBookTableAcp.UseVisualStyleBackColor = true;
            btnBookTableAcp.Click += btnBookTableAcp_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.Connection = null;
            sqlCommand1.Notification = null;
            sqlCommand1.Transaction = null;
            // 
            // rdLunch
            // 
            rdLunch.AutoSize = true;
            rdLunch.Location = new Point(12, 103);
            rdLunch.Name = "rdLunch";
            rdLunch.Size = new Size(70, 19);
            rdLunch.TabIndex = 22;
            rdLunch.TabStop = true;
            rdLunch.Text = "Bữa Trưa";
            rdLunch.UseVisualStyleBackColor = true;
            // 
            // rdDinner
            // 
            rdDinner.AutoSize = true;
            rdDinner.Location = new Point(105, 104);
            rdDinner.Name = "rdDinner";
            rdDinner.Size = new Size(64, 19);
            rdDinner.TabIndex = 23;
            rdDinner.TabStop = true;
            rdDinner.Text = "Bữa Tối";
            rdDinner.UseVisualStyleBackColor = true;
            // 
            // tbNameCustom
            // 
            tbNameCustom.Location = new Point(105, 129);
            tbNameCustom.Name = "tbNameCustom";
            tbNameCustom.Size = new Size(121, 23);
            tbNameCustom.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 174);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 26;
            label4.Text = "Số điện thoại";
            // 
            // tbPhoneCustom
            // 
            tbPhoneCustom.Location = new Point(105, 171);
            tbPhoneCustom.Name = "tbPhoneCustom";
            tbPhoneCustom.Size = new Size(121, 23);
            tbPhoneCustom.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 132);
            label3.Name = "label3";
            label3.Size = new Size(79, 15);
            label3.TabIndex = 24;
            label3.Text = "Tên người đặt";
            // 
            // fBookTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 252);
            Controls.Add(tbPhoneCustom);
            Controls.Add(label4);
            Controls.Add(tbNameCustom);
            Controls.Add(label3);
            Controls.Add(rdDinner);
            Controls.Add(rdLunch);
            Controls.Add(btnBookTableAcp);
            Controls.Add(cbTable);
            Controls.Add(timeBook);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fBookTable";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookTableFrm";
            Load += fBookTable_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker timeBook;
        private ComboBox cbTable;
        private Button btnBookTableAcp;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private RadioButton rdLunch;
        private RadioButton rdDinner;
        private TextBox tbNameCustom;
        private Label label4;
        private TextBox tbPhoneCustom;
        private Label label3;
    }
}