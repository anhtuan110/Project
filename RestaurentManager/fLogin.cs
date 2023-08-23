using RestaurentManager.Models;

namespace RestaurentManager
{
	public partial class fLogin : Form
	{
		public fLogin()
		{
			InitializeComponent();
		}
		public Account GetAccountByUserName()
		{
			using (var db = new QuanLyNhaHangContext())
			{
				string userName = txtUserName.Text;
				var data = from infor in db.Accounts where infor.UserName == userName select infor;
				foreach (var item in data)
				{
					return item;
				}

			}
			return null;
		}

		private void btnLogin_Click(object sender, EventArgs e)
		{
			string a = txtUserName.Text;
			string b = txtPass.Text;
			using (var db = new QuanLyNhaHangContext())
			{
				var data = db.Accounts.SingleOrDefault(item => item.UserName == a && item.PassWord == b);
				if (data != null)
				{
					Account loginAccount = GetAccountByUserName();
					MessageBox.Show("Đăng nhập thành công");
					fTableManager fTableManager = new fTableManager(loginAccount);
					this.Hide();
					fTableManager.ShowDialog();
					this.Show();
				}
				else
				{
					MessageBox.Show("Tên người dùng hoặc mật khẩu không đúng.Vui lòng nhập lại");

				}
			}

		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
			{
				e.Cancel = true;
			}
		}
	}
}
