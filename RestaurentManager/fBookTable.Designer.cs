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
			label2 = new Label();
			timeBook = new DateTimePicker();
			label1 = new Label();
			cbTable = new ComboBox();
			rdLunch = new RadioButton();
			rdDinner = new RadioButton();
			label3 = new Label();
			tbNameCustom = new TextBox();
			label4 = new Label();
			tbPhoneCustom = new TextBox();
			btnBookTableAcp = new Button();
			SuspendLayout();
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(51, 108);
			label2.Name = "label2";
			label2.Size = new Size(69, 20);
			label2.TabIndex = 2;
			label2.Text = "Chọn giờ";
			// 
			// timeBook
			// 
			timeBook.Format = DateTimePickerFormat.Time;
			timeBook.Location = new Point(165, 108);
			timeBook.Margin = new Padding(3, 4, 3, 4);
			timeBook.Name = "timeBook";
			timeBook.Size = new Size(138, 27);
			timeBook.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(51, 41);
			label1.Name = "label1";
			label1.Size = new Size(72, 20);
			label1.TabIndex = 5;
			label1.Text = "Chọn bàn";
			// 
			// cbTable
			// 
			cbTable.DropDownStyle = ComboBoxStyle.DropDownList;
			cbTable.FormattingEnabled = true;
			cbTable.Location = new Point(165, 41);
			cbTable.Margin = new Padding(3, 4, 3, 4);
			cbTable.Name = "cbTable";
			cbTable.Size = new Size(138, 28);
			cbTable.TabIndex = 6;
			// 
			// rdLunch
			// 
			rdLunch.AutoSize = true;
			rdLunch.Location = new Point(51, 176);
			rdLunch.Margin = new Padding(3, 4, 3, 4);
			rdLunch.Name = "rdLunch";
			rdLunch.Size = new Size(89, 24);
			rdLunch.TabIndex = 23;
			rdLunch.TabStop = true;
			rdLunch.Text = "Bữa Trưa";
			rdLunch.UseVisualStyleBackColor = true;
			// 
			// rdDinner
			// 
			rdDinner.AutoSize = true;
			rdDinner.Location = new Point(187, 176);
			rdDinner.Margin = new Padding(3, 4, 3, 4);
			rdDinner.Name = "rdDinner";
			rdDinner.Size = new Size(81, 24);
			rdDinner.TabIndex = 24;
			rdDinner.TabStop = true;
			rdDinner.Text = "Bữa Tối";
			rdDinner.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(51, 240);
			label3.Name = "label3";
			label3.Size = new Size(101, 20);
			label3.TabIndex = 25;
			label3.Text = "Tên người đặt";
			// 
			// tbNameCustom
			// 
			tbNameCustom.Location = new Point(165, 237);
			tbNameCustom.Margin = new Padding(3, 4, 3, 4);
			tbNameCustom.Name = "tbNameCustom";
			tbNameCustom.Size = new Size(138, 27);
			tbNameCustom.TabIndex = 26;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(55, 301);
			label4.Name = "label4";
			label4.Size = new Size(97, 20);
			label4.TabIndex = 27;
			label4.Text = "Số điện thoại";
			// 
			// tbPhoneCustom
			// 
			tbPhoneCustom.Location = new Point(165, 294);
			tbPhoneCustom.Margin = new Padding(3, 4, 3, 4);
			tbPhoneCustom.Name = "tbPhoneCustom";
			tbPhoneCustom.Size = new Size(138, 27);
			tbPhoneCustom.TabIndex = 28;
			// 
			// btnBookTableAcp
			// 
			btnBookTableAcp.Cursor = Cursors.Hand;
			btnBookTableAcp.Location = new Point(124, 366);
			btnBookTableAcp.Margin = new Padding(3, 4, 3, 4);
			btnBookTableAcp.Name = "btnBookTableAcp";
			btnBookTableAcp.Size = new Size(86, 31);
			btnBookTableAcp.TabIndex = 29;
			btnBookTableAcp.Text = "Xác Nhận";
			btnBookTableAcp.UseVisualStyleBackColor = true;
			btnBookTableAcp.Click += btnBookTableAcp_Click;
			// 
			// fBookTable
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(426, 450);
			Controls.Add(btnBookTableAcp);
			Controls.Add(tbPhoneCustom);
			Controls.Add(label4);
			Controls.Add(tbNameCustom);
			Controls.Add(label3);
			Controls.Add(rdDinner);
			Controls.Add(rdLunch);
			Controls.Add(cbTable);
			Controls.Add(label1);
			Controls.Add(timeBook);
			Controls.Add(label2);
			Name = "fBookTable";
			Text = "fBookTable";
			Load += fBookTable_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label2;
		private DateTimePicker timeBook;
		private Label label1;
		private ComboBox cbTable;
		private RadioButton rdLunch;
		private RadioButton rdDinner;
		private Label label3;
		private TextBox tbNameCustom;
		private Label label4;
		private TextBox tbPhoneCustom;
		private Button btnBookTableAcp;
	}
}