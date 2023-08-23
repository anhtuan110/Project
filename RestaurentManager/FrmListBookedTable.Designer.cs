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
			tbPhoneCustom = new TextBox();
			tbNameCustom = new TextBox();
			label5 = new Label();
			label2 = new Label();
			btnSearch = new Button();
			textSearch = new TextBox();
			btnUpdate = new Button();
			label3 = new Label();
			label4 = new Label();
			rdDinner = new RadioButton();
			rdLunch = new RadioButton();
			timeBook = new DateTimePicker();
			cbTable = new ComboBox();
			dgvListBookedTable = new DataGridView();
			label6 = new Label();
			((System.ComponentModel.ISupportInitialize)dgvListBookedTable).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(263, -50);
			label1.Name = "label1";
			label1.Size = new Size(300, 37);
			label1.TabIndex = 32;
			label1.Text = "Danh Sách Bàn Đã Đặt";
			// 
			// tbPhoneCustom
			// 
			tbPhoneCustom.Location = new Point(485, 247);
			tbPhoneCustom.Margin = new Padding(3, 4, 3, 4);
			tbPhoneCustom.Name = "tbPhoneCustom";
			tbPhoneCustom.Size = new Size(173, 27);
			tbPhoneCustom.TabIndex = 47;
			// 
			// tbNameCustom
			// 
			tbNameCustom.Location = new Point(485, 193);
			tbNameCustom.Margin = new Padding(3, 4, 3, 4);
			tbNameCustom.Name = "tbNameCustom";
			tbNameCustom.Size = new Size(173, 27);
			tbNameCustom.TabIndex = 46;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(379, 253);
			label5.Name = "label5";
			label5.Size = new Size(97, 20);
			label5.TabIndex = 45;
			label5.Text = "Số điện thoại";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(379, 197);
			label2.Name = "label2";
			label2.Size = new Size(101, 20);
			label2.TabIndex = 44;
			label2.Text = "Tên người đặt";
			// 
			// btnSearch
			// 
			btnSearch.Location = new Point(500, 137);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(94, 31);
			btnSearch.TabIndex = 43;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			// 
			// textSearch
			// 
			textSearch.Location = new Point(212, 137);
			textSearch.Name = "textSearch";
			textSearch.Size = new Size(257, 27);
			textSearch.TabIndex = 42;
			// 
			// btnUpdate
			// 
			btnUpdate.Location = new Point(379, 296);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(94, 29);
			btnUpdate.TabIndex = 41;
			btnUpdate.Text = "Update";
			btnUpdate.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(40, 251);
			label3.Name = "label3";
			label3.Size = new Size(69, 20);
			label3.TabIndex = 40;
			label3.Text = "Chọn giờ";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(40, 197);
			label4.Name = "label4";
			label4.Size = new Size(72, 20);
			label4.TabIndex = 39;
			label4.Text = "Chọn bàn";
			// 
			// rdDinner
			// 
			rdDinner.AutoSize = true;
			rdDinner.Location = new Point(238, 296);
			rdDinner.Margin = new Padding(3, 4, 3, 4);
			rdDinner.Name = "rdDinner";
			rdDinner.Size = new Size(81, 24);
			rdDinner.TabIndex = 38;
			rdDinner.TabStop = true;
			rdDinner.Text = "Bữa Tối";
			rdDinner.UseVisualStyleBackColor = true;
			// 
			// rdLunch
			// 
			rdLunch.AutoSize = true;
			rdLunch.Location = new Point(137, 296);
			rdLunch.Margin = new Padding(3, 4, 3, 4);
			rdLunch.Name = "rdLunch";
			rdLunch.Size = new Size(89, 24);
			rdLunch.TabIndex = 37;
			rdLunch.TabStop = true;
			rdLunch.Text = "Bữa Trưa";
			rdLunch.UseVisualStyleBackColor = true;
			// 
			// timeBook
			// 
			timeBook.Format = DateTimePickerFormat.Time;
			timeBook.Location = new Point(137, 243);
			timeBook.Margin = new Padding(3, 4, 3, 4);
			timeBook.Name = "timeBook";
			timeBook.Size = new Size(173, 27);
			timeBook.TabIndex = 36;
			// 
			// cbTable
			// 
			cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
			cbTable.FormattingEnabled = true;
			cbTable.Location = new Point(137, 193);
			cbTable.Margin = new Padding(3, 4, 3, 4);
			cbTable.Name = "cbTable";
			cbTable.Size = new Size(173, 28);
			cbTable.TabIndex = 35;
			// 
			// dgvListBookedTable
			// 
			dgvListBookedTable.AllowUserToAddRows = false;
			dgvListBookedTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgvListBookedTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvListBookedTable.Location = new Point(25, 351);
			dgvListBookedTable.Name = "dgvListBookedTable";
			dgvListBookedTable.RowHeadersWidth = 51;
			dgvListBookedTable.RowTemplate.Height = 29;
			dgvListBookedTable.Size = new Size(750, 280);
			dgvListBookedTable.TabIndex = 34;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
			label6.Location = new Point(263, 80);
			label6.Name = "label6";
			label6.Size = new Size(300, 37);
			label6.TabIndex = 33;
			label6.Text = "Danh Sách Bàn Đã Đặt";
			// 
			// FrmListBookedTable
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 711);
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
			Controls.Add(label6);
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
		private TextBox tbPhoneCustom;
		private TextBox tbNameCustom;
		private Label label5;
		private Label label2;
		private Button btnSearch;
		private TextBox textSearch;
		private Button btnUpdate;
		private Label label3;
		private Label label4;
		private RadioButton rdDinner;
		private RadioButton rdLunch;
		private DateTimePicker timeBook;
		private ComboBox cbTable;
		private DataGridView dgvListBookedTable;
		private Label label6;
	}
}