using RestaurentManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManager
{
	public partial class fAccountProfile : Form
	{
		public Account loginAccount { get; set; }
		void ChangeAccount(Account acc)
		{
			txtUserName.Text = loginAccount.UserName;
			txtDisplayName.Text = loginAccount.DisplayName;
		}

		void UpdateAccountInfo()
		{

			using (var db = new QuanLyNhaHangContext())
			{
				string userName = txtUserName.Text;
				var data = (from infor in db.Accounts
							where infor.UserName == userName
							select new
							{
								pass = infor.PassWord
							}).SingleOrDefault();



				if (txtDisplayName.Text.Equals(string.Empty))

				{
					MessageBox.Show("Vui lòng nhập tên hiển thị");

				}
				else
				{
					if (txtPassWord.Text.Equals(string.Empty) || data.pass != txtPassWord.Text)
					{
						MessageBox.Show("Vui lòng nhập mật khẩu");
					}
					else
					{
						if (txtNewPass.Text.Equals(string.Empty))
						{
							MessageBox.Show("Vui lòng nhập mật khẩu mới");
						}
						else
						{
							if (txtReEnterPass.Text.Equals(string.Empty))
							{
								MessageBox.Show("Vui lòng nhập lại mật khẩu mới");
							}
							else
							{
								if (!txtReEnterPass.Text.Equals(txtNewPass.Text))
								{
									MessageBox.Show("Vui lòng nhập lại đúng với mật khẩu mới");
								}
								else
								{
									var up = (from ac in db.Accounts where ac.UserName == userName select ac).SingleOrDefault();
									up.DisplayName = txtDisplayName.Text;
									up.PassWord = txtNewPass.Text;
									db.SaveChanges();
									MessageBox.Show("Cập nhật thành công");

								}

							}

						}

					}
				}

			}
		}
		public fAccountProfile(Account acc)
		{
			InitializeComponent();
			this.loginAccount = acc;
			ChangeAccount(loginAccount);
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnUpdate_Click_1(object sender, EventArgs e)
		{
			UpdateAccountInfo();

		}
	}
}
