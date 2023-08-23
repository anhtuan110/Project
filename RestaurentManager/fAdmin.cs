using RestaurentManager.DAO;
using RestaurentManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManager
{
	public partial class fAdmin : Form
	{
		private string LoadFilePath;
		public fAdmin()
		{
			InitializeComponent();
			dtgvCategory.DataSource = categoryList;
			dgvTable.DataSource = tableList;
			binddingCategory();
			binddingTable();
			BindTableStatusToComboBox();
			loadTable();
			loadCategory();

			dgvTable.CellContentClick += dgvTable_CellContentClick;

		}
		void LoadAccount()
		{
			using (var db = new QuanLyNhaHangContext())
			{
				var list = (from data in db.Accounts
							select new
							{
								user = data.UserName,
								disPlayName = data.DisplayName,
								type = data.Type,
							}).ToList();
				dtgvAccount.DataSource = list;

			}
		}
		void loadCategory()
		{
			categoryList.DataSource = CategoryDAO.Instance.GetListCategory().Select(x => new
			{
				id = x.Id,
				name = x.Name,
			});
		}
		private void LoadFood()
		{
			using (var db = new QuanLyNhaHangContext())
			{
				dtgvFood.AutoGenerateColumns = false;
				dtgvFood.Columns.Clear();
				dtgvFood.DataSource = null;
				var foodList = db.Foods.Select(e => new
				{
					Id = e.Id,
					Name = e.Name,
					Category = e.IdCategoryNavigation.Name,
					Price = e.Price,
				}).ToList();

				dtgvFood.DataSource = foodList;


				DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
				id.Name = "id";
				id.HeaderText = " ID";
				id.DataPropertyName = "Id";

				DataGridViewTextBoxColumn name = new DataGridViewTextBoxColumn();
				name.Name = "name";
				name.HeaderText = "Food Name";
				name.DataPropertyName = "Name";

				DataGridViewTextBoxColumn category = new DataGridViewTextBoxColumn();
				category.Name = "category";
				category.HeaderText = "Category";
				category.DataPropertyName = "Category";

				DataGridViewTextBoxColumn price = new DataGridViewTextBoxColumn();
				price.Name = "price";
				price.HeaderText = "Price";
				price.DataPropertyName = "Price";

				dtgvFood.Columns.Add(id);
				dtgvFood.Columns.Add(name);
				dtgvFood.Columns.Add(category);
				dtgvFood.Columns.Add(price);

				cbFoodCategory.DataSource = db.FoodCategories.ToList();
				cbFoodCategory.DisplayMember = "name";
				cbFoodCategory.ValueMember = "id";
			}
		}

		void binddingCategory()
		{
			txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "id", true, DataSourceUpdateMode.Never));
			txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "name", true, DataSourceUpdateMode.Never));
		}
		void binddingTable()
		{

			txtTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "id", true, DataSourceUpdateMode.Never));
			txtTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "name", true, DataSourceUpdateMode.Never));

		}
		void addCategory(string name)
		{

			if (CategoryDAO.Instance.AddCategory(name))
			{
				MessageBox.Show("Add category successfully");
				loadCategory();
			}
			else
			{
				MessageBox.Show("Add category failed");
			}
		}
		void deleleCategory(int id)
		{
			if (CategoryDAO.Instance.DeleteCategory(id))
			{
				MessageBox.Show("Delete category successfully");
				loadCategory();
			}
			else
			{
				MessageBox.Show("Delete category failed");

			}
		}
		void updateCategory(int id, string name)
		{
			if (CategoryDAO.Instance.UpdateCategory(id, name))
			{
				MessageBox.Show("Update category successfully");
				loadCategory();
			}
			else
			{
				MessageBox.Show("Update category failed");

			}
		}
		void loadTable()
		{
			tableList.DataSource = TableDAO.Instance.GetListTable().Select(x => new
			{
				id = x.Id,
				name = x.Name,
				status = x.Status,
			});
		}
		void addTable(string name, string status)
		{

			if (TableDAO.Instance.AddTable(name, status))
			{
				MessageBox.Show("Add table successfully");
				loadTable();
			}
			else
			{
				MessageBox.Show("Add table failed");
			}
		}
		void deleleTable(int id)
		{
			if (TableDAO.Instance.DeleteTable(id))
			{
				MessageBox.Show("Delete category successfully");
				loadTable();
			}
			else
			{
				MessageBox.Show("Delete category failed");

			}
		}
		void updateTable(int id, string name, string status)
		{
			if (TableDAO.Instance.UpdateTable(id, name, status))
			{
				MessageBox.Show("Update category successfully");
				loadTable();
			}
			else
			{
				MessageBox.Show("Update category failed");
			}
		}
		private void BindTableStatusToComboBox()
		{
			List<string> statusList = new List<string> { "Available", "Unavailable" };
			cbTableStatus.DataSource = statusList;
		}
		private void btnShowAccount_Click_1(object sender, EventArgs e)
		{
			txtUserName.ReadOnly = true;
			LoadAccount();
		}

		private void btnAddAccount_Click_1(object sender, EventArgs e)
		{
			using (var db = new QuanLyNhaHangContext())
			{
				var account = new Account
				{

					UserName = txtUserName.Text,
					DisplayName = txtDisplayName.Text,
					Type = int.Parse(nudType.Text)
				};
				db.Accounts.Add(account);
				db.SaveChanges();
				MessageBox.Show("Thêm tài khoản thành công");
				LoadAccount();

			}
		}

		private void btnEditAccount_Click_1(object sender, EventArgs e)
		{
			txtUserName.ReadOnly = true;
			using (var db = new QuanLyNhaHangContext())
			{

				string userName = txtUserName.Text;
				var list = (from data in db.Accounts where data.UserName == userName select data).SingleOrDefault();
				if (list != null)
				{
					list.DisplayName = txtDisplayName.Text;
					list.Type = int.Parse(nudType.Text);
					db.SaveChanges();
					LoadAccount();
					MessageBox.Show("Cập nhật thành công");
				}
				else
				{
					MessageBox.Show("Không thể để trống");
				}
			}
		}

		private void dtgvAccount_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
		{
			txtUserName.DataBindings.Clear();
			txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "user"));
			txtDisplayName.DataBindings.Clear();
			txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "disPlayName"));
			nudType.DataBindings.Clear();
			nudType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "type"));
		}
		BindingSource categoryList = new BindingSource();
		BindingSource tableList = new BindingSource();

		private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dgvTable.Rows.Count)
			{
				DataGridViewRow selectedRow = dgvTable.Rows[e.RowIndex];
				string selectedStatus = selectedRow.Cells["status"].Value.ToString();
				cbTableStatus.SelectedItem = selectedStatus;
			}
		}

		private void btnAddCategory_Click(object sender, EventArgs e)
		{
			string name = txtCategoryName.Text;
			addCategory(name);
		}

		private void btnDeleteCategory_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(txtCategoryID.Text);

			deleleCategory(id);
		}

		private void btnEditCategory_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(txtCategoryID.Text);
			string name = txtCategoryName.Text;
			updateCategory(id, name);
		}

		private void btnShowCategory_Click(object sender, EventArgs e)
		{
			loadCategory();
		}

		private void btnAddTable_Click(object sender, EventArgs e)
		{
			string name = txtTableName.Text;
			string status = cbTableStatus.Text; // Thay bằng trạng thái mặc định
			addTable(name, status);
		}

		private void btnDeleteTable_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(txtTableID.Text);
			deleleTable(id);
		}

		private void btnEditTable_Click(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(txtTableID.Text);
			string name = txtTableName.Text;
			string status = cbTableStatus.Text;
			updateTable(id, name, status);
		}

		private void btnShowTable_Click(object sender, EventArgs e)
		{
			loadTable();
		}

		private void btnShowFood_Click(object sender, EventArgs e)
		{
			LoadFood();
		}
		private void tpFood_Click(object sender, EventArgs e)
		{
			LoadFood();
			txtFoodID.Enabled = false;
			dtgvCategory.CellClick += dtgvFood_CellClick;
		}

		private void dtgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dtgvFood.Rows.Count && e.ColumnIndex >= 0)
			{
				txtFoodID.Enabled = false;
				var id = dtgvFood.Rows[e.RowIndex].Cells["id"].Value.ToString();
				var name = dtgvFood.Rows[e.RowIndex].Cells["name"].Value.ToString();
				var category = dtgvFood.Rows[e.RowIndex].Cells["category"].Value.ToString();
				var price = dtgvFood.Rows[e.RowIndex].Cells["price"].Value.ToString();

				txtFoodID.Text = id;
				txtFoodName.Text = name;
				var selectedCategory = cbFoodCategory.Items.Cast<FoodCategory>().FirstOrDefault(c => c.Name == category);
				if (selectedCategory != null)
					cbFoodCategory.SelectedItem = selectedCategory;
				nmFoodPrice.Text = price;
			}
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dtgvFood.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
			{
				dtgvFood.EndEdit();
			}
		}
		private bool IsValid()
		{
			bool flag = true;
			string msg = "";
			if (txtFoodName.Text.Length == 0)
			{
				flag = false;
				msg += "FoodName is required.\n";
			}
			if ((int)nmFoodPrice.Value == 0)
			{
				flag = false;
				msg += "Price must greater than 0";
			}
			if (flag == false)
			{
				MessageBox.Show(msg);
			}
			return flag;
		}

		private void btnAddFood_Click(object sender, EventArgs e)
		{
			if (IsValid())
			{
				using (var db = new QuanLyNhaHangContext())
				{
					var foodNew = new Food
					{
						Name = txtFoodName.Text,
						IdCategory = int.Parse(cbFoodCategory.SelectedValue.ToString()),
						Price = double.Parse(nmFoodPrice.Text),
					};
					db.Foods.Add(foodNew);
					if (db.SaveChanges() > 0)
					{
						MessageBox.Show("Add success");
						LoadFood();
					}
				}
			}
		}

		private void btnEditFood_Click(object sender, EventArgs e)
		{
			if(txtFoodID.Text.Length != 0)
			{
				var id = int.Parse(txtFoodID.Text);
				var name = txtFoodName.Text;
				var price = (double)nmFoodPrice.Value;

				using (var db = new QuanLyNhaHangContext())
				{
					var fd = (from t in db.Foods where t.Id == id select t).SingleOrDefault();
					fd.Name = name;
					fd.IdCategory = int.Parse(cbFoodCategory.SelectedValue.ToString());
					fd.Price = price;
					db.SaveChanges();
					MessageBox.Show("Update Success");
					LoadFood();

				}
				
				
			}
			else
			{
				MessageBox.Show("Not Found Id");
			}

		}

		private void btnSearchFood_Click(object sender, EventArgs e)
		{
			using (var db = new QuanLyNhaHangContext())
			{
				var search = db.Foods
								.Where(p => p.Name.Contains(txtSearchFoodName.Text))
								.Select(e => new
								{
									Id = e.Id,
									Name = e.Name,
									Category = e.IdCategoryNavigation.Name,
									Price = (double)e.Price,
								})
								.ToList();

				dtgvFood.DataSource = search;
			}
		}

		private void btnDeleteFood_Click(object sender, EventArgs e)
		{
			if (txtFoodID.Text.Length != 0)
			{
				var id = int.Parse(txtFoodID.Text);
				using (var db = new QuanLyNhaHangContext())
				{
					var x = db.Foods.Find(id);
					if (x == null)
					{
						MessageBox.Show($"Khong ton tai thuc an co Id = {id}");
					}
					else
					{
						var dig = MessageBox.Show($"Do you want to delete food with id = {id}",
							"Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dig == DialogResult.Yes)
						{
							db.Foods.Remove(x);
							db.SaveChanges();
							LoadFood();
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Not Found ID");
			}
		}
		private void LoadBill(DateTime fromDate, DateTime toDate)
		{
			using (var db = new QuanLyNhaHangContext())
			{
				dtgvBill.AutoGenerateColumns = false;
				dtgvBill.Columns.Clear();
				dtgvBill.DataSource = null;


				var billList = db.Bills
			.Where(e => e.DateCheckIn >= fromDate && e.DateCheckOut <= toDate)  // Lọc theo khoảng thời gian
			.Select(e => new
			{
				Id = e.Id,
				IdTable = e.IdTable,
				TotalBill = e.TotalBill,
				Discount = e.Discount,
				DateCheckIn = e.DateCheckIn.Value,
				DateCheckOut = e.DateCheckOut.Value,
			}).ToList();

				dtgvBill.DataSource = billList;


				DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
				id.Name = "id";
				id.HeaderText = " ID";
				id.DataPropertyName = "Id";

				DataGridViewTextBoxColumn idtable = new DataGridViewTextBoxColumn();
				idtable.Name = "idtable";
				idtable.HeaderText = "IdTable";
				idtable.DataPropertyName = "IdTable";

				DataGridViewTextBoxColumn totalBill = new DataGridViewTextBoxColumn();
				totalBill.Name = "totalbill";
				totalBill.HeaderText = "Total Bill";
				totalBill.DataPropertyName = "TotalBill";

				DataGridViewTextBoxColumn discount = new DataGridViewTextBoxColumn();
				discount.Name = "discount";
				discount.HeaderText = "Discount";
				discount.DataPropertyName = "Discount";

				DataGridViewTextBoxColumn datecheckin = new DataGridViewTextBoxColumn();
				datecheckin.Name = "datecheckin";
				datecheckin.HeaderText = "Datecheckin";
				datecheckin.DataPropertyName = "DateCheckIn";

				DataGridViewTextBoxColumn datecheckout = new DataGridViewTextBoxColumn();
				datecheckout.Name = "datecheckout";
				datecheckout.HeaderText = "Datecheckout";
				datecheckout.DataPropertyName = "DateCheckOut";

				dtgvBill.Columns.Add(id);
				dtgvBill.Columns.Add(idtable);
				dtgvBill.Columns.Add(totalBill);
				dtgvBill.Columns.Add(discount);
				dtgvBill.Columns.Add(datecheckin);
				dtgvBill.Columns.Add(datecheckout);




			}
		}

		private bool IsDateRangeValid(DateTime fromDate, DateTime toDate)
		{
			return toDate >= fromDate;
		}

		private void btnViewBill_Click(object sender, EventArgs e)
		{
			DateTime fromDate = dtpkFromDate.Value.Date;  // Lấy ngày từ dtpicker và loại bỏ phần giờ phút
			DateTime toDate = dtpkToDate.Value.Date.AddDays(1).AddSeconds(-1);  // Lấy ngày từ dtpicker, cộng thêm 1 ngày và trừ đi 1 giây

			if (IsDateRangeValid(fromDate, toDate))
			{
				LoadBill(fromDate, toDate);
			}
			else
			{
				MessageBox.Show("Error Date");
			}
		}


	}
}