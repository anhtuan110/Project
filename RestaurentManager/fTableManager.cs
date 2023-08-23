using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
	public partial class fTableManager : Form
	{
		private readonly QuanLyNhaHangContext DBcontext = new();
		private Account loginAccount { get; set; }
		void ChangeAccount(int type)
		{
			adminToolStripMenuItem.Enabled = type == 1;
			InforAccountToolStripMenuItem.Text += "(" + loginAccount.DisplayName + ")";
		}

		public fTableManager(Account acc)
		{
			InitializeComponent();
			this.loginAccount = acc;
			ChangeAccount(loginAccount.Type);
			LoadBtnTableFood();
		}


		private void adminToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAdmin fAdmin = new fAdmin();

			fAdmin.ShowDialog();
		}
		private void PersonalInfoToolStripMenuItem_Click(object sender, EventArgs e)
		{
			fAccountProfile fAccountProfile = new fAccountProfile(loginAccount);
			fAccountProfile.ShowDialog();
		}

		private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void LoadBtnTableFood()
		{
			flpTable.Controls.Clear();
			List<TableFood> listTableFood = new List<TableFood>();
			listTableFood = DBcontext.TableFoods.ToList();
			int i = 1;
			foreach (TableFood t in listTableFood)
			{
				Button bt = new()
				{
					Size = new Size(90, 90),
					Text = t.Name + "- Id:" + t.Id + "\n" + t.Status,
					Name = $"btnTable{i}",
					Location = new Point(3, i * 3)
				};
				bt.Tag = t;
				bt.Click += Bt_Click;
				switch (t.Status)
				{
					case "Available":
						bt.BackColor = Color.YellowGreen;
						break;
					case "Occupied":
						bt.BackColor = Color.Red;
						break;
					case "Booked":
						bt.BackColor = Color.Yellow;
						break;
				}
				i++;
				flpTable.Controls.Add(bt);
			}
		}
		private void fTableManager_Load(object sender, EventArgs e)
		{
			cbSwitchTable.DataSource = DBcontext.TableFoods.ToList();
			cbSwitchTable.DisplayMember = "Name";
			cbCategory.DataSource = DBcontext.FoodCategories.ToList();

		}

		private void Bt_Click(object? sender, EventArgs e)
		{
			int tableID = ((sender as Button).Tag as TableFood).Id;
			ShowBill(tableID);
			ShowTotalAmount(tableID);
		}
		private void ShowTotalAmount(int tableID)
		{
			var totalAmount = (from b in DBcontext.Bills
							   join bi in DBcontext.BillInfos on b.Id equals bi.IdBill
							   join f in DBcontext.Foods on bi.IdFood equals f.Id
							   where b.IdTable == tableID && b.Status == 1
							   select f.Price * bi.Count)
						   .Sum();

			tbTotalMoney.Text = totalAmount.ToString("N0") + " VND";
			tbTotalMoney.Tag = totalAmount;
		}
		void ShowBill(int id)
		{
			var query = from b in DBcontext.Bills
						join bi in DBcontext.BillInfos on b.Id equals bi.IdBill
						join f in DBcontext.Foods on bi.IdFood equals f.Id
						where b.Status == 1 && b.IdTable == id
						group new { bi, f } by new { bi.IdFood, f.Name, f.Price } into grouped
						select new
						{
							IdFood = grouped.Key.IdFood,
							Name = grouped.Key.Name,
							Price = grouped.Key.Price,
							Quantity = grouped.Sum(item => item.bi.Count),
							Total = grouped.Key.Price * grouped.Sum(item => item.bi.Count)
						};

			lsvBill.Items.Clear();
			int i = 1;
			foreach (var item in query)
			{
				ListViewItem listViewItem = new ListViewItem(i.ToString());
				listViewItem.SubItems.Add(item.IdFood.ToString());
				listViewItem.SubItems.Add(item.Name.ToString());
				listViewItem.SubItems.Add(item.Price.ToString());
				listViewItem.SubItems.Add(item.Quantity.ToString());
				listViewItem.SubItems.Add(item.Total.ToString());
				lsvBill.Items.Add(listViewItem);
				i++;
			}

			tbOldTableID.Text = id.ToString();
		}
		private void btnSwitchTable_Click(object sender, EventArgs e)
		{
			if (tbOldTableID.Text != "")
			{
				int oldTableID = Convert.ToInt32(tbOldTableID.Text.ToString());
				int newTableID = (cbSwitchTable.SelectedItem as TableFood).Id;
				DialogResult dlr = MessageBox.Show("Are you sure you want to switch from table " + oldTableID + " to table " + newTableID + " ?", "Notification",
							   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (dlr == DialogResult.OK)
				{
					var billsToUpdate = (from b in DBcontext.Bills
										 where b.IdTable == oldTableID && b.Status == 1
										 select b).ToList();
					var oldTableToUpdate = (from tb in DBcontext.TableFoods
											where tb.Id == oldTableID
											select tb).ToList();
					var newTableToUpdate = (from tb in DBcontext.TableFoods
											where tb.Id == newTableID
											select tb).ToList();

					foreach (var otb in oldTableToUpdate)
					{
						if (otb.Status.Equals("Available"))
						{
							MessageBox.Show("Table " + " has not been used");
							return;
						}
						else if (otb.Status.Equals("Occupied"))
						{
							otb.Status = "Available";
							foreach (var ntb in newTableToUpdate)
							{
								ntb.Status = "Occupied";
							}
							foreach (var bill in billsToUpdate)
							{
								bill.IdTable = newTableID;
							}
						}
					}
					DBcontext.SaveChanges();
					//re-load after switch
					ShowBill(oldTableID);
					tbTotalMoney.Text = 0 + " VND";
					LoadBtnTableFood();
				}
			}
		}

		private void btnDisCount_Click(object sender, EventArgs e)
		{
			int discount = Convert.ToInt32(nmDisCount.Value);
			if (tbTotalMoney.Tag != null && double.TryParse(tbTotalMoney.Tag.ToString(), out double totalAmount))
			{
				totalAmount = totalAmount - totalAmount * discount / 100;
				tbTotalMoney.Text = totalAmount.ToString("N0") + " VND";
			}
		}

		private void btnCheckOut_Click(object sender, EventArgs e)
		{
			if (tbOldTableID.Text != "")
			{
				int tableID = Convert.ToInt32(tbOldTableID.Text.ToString());

				string moneyText = tbTotalMoney.Text.Replace(" VND", "").Replace(",", "");
				decimal totalBill = Convert.ToDecimal(moneyText);
				double discount = Convert.ToDouble(nmDisCount.Value);
				DialogResult dlr = MessageBox.Show("Are you sure you want to checkout table " + tableID + " with total money is: " + tbTotalMoney.Text + " ?", "Notification",
							   MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (dlr == DialogResult.OK)
				{

					var billsToUpdate = (from b in DBcontext.Bills
										 where b.IdTable == tableID && b.Status == 1
										 select b).ToList();
					var tableToUpdate = (from tb in DBcontext.TableFoods
										 where tb.Id == tableID
										 select tb).ToList();
					foreach (var ntb in tableToUpdate)
					{
						ntb.Status = "Available";
					}
					foreach (var bill in billsToUpdate)
					{
						bill.Status = 2;
						bill.Discount = discount;
						bill.TotalBill = totalBill;
						bill.DateCheckOut = DateTime.Now;
					}
					DBcontext.SaveChanges();
					//re-load after switch
					ShowBill(tableID);
					tbTotalMoney.Text = 0 + " VND";
					LoadBtnTableFood();
				}
			}
		}

		private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
		{
			int categoryFoodId = (cbCategory.SelectedItem as FoodCategory).Id;
			LoadFood(categoryFoodId);
		}
		private void LoadFood(int id)
		{
			cbFood.DataSource = DBcontext.Foods.Where(food => food.IdCategory == id).ToList();
			cbFood.DisplayMember = "Name";
		}

		private void btnAddFood_Click(object sender, EventArgs e)
		{
			if (tbOldTableID.Text != "")
			{
				int quantityFood = Convert.ToInt32(nmFoodCount.Value);
				int categoryFoodId = (cbCategory.SelectedItem as FoodCategory).Id;
				int foodId = (cbFood.SelectedItem as Food).Id;

				int tableID = int.Parse(tbOldTableID.Text.ToString());
				var bills = DBcontext.Bills
					.Where(bill => bill.IdTable == tableID && bill.Status == 1)
					.ToList();

				//Add bill and billInfo neu bill chua ton tai
				if (!bills.Any())
				{
					if (quantityFood <= 0)
					{
						MessageBox.Show("Số lượng món thêm vào phải lớn hơn 0");
					}
					else
					{
						AddBill(DateTime.Now, DateTime.Now, tableID, 0, 0, 1);
						int latestInsertedBillId = DBcontext.Bills
						.OrderByDescending(bill => bill.Id)
						.Select(bill => bill.Id)
						.FirstOrDefault();
						AddBillInfo(latestInsertedBillId, foodId, quantityFood);
						var tableToUpdate = DBcontext.TableFoods.FirstOrDefault(table => table.Id == tableID);
						if (tableToUpdate != null)
						{
							tableToUpdate.Status = "Occupied";
						}
						DBcontext.SaveChanges();
						//re-load after change
						ShowBill(tableID);
						ShowTotalAmount(tableID);
						LoadBtnTableFood();
						MessageBox.Show("Thêm món thành công!");
					}
				}
				//add them mon neu bill da ton tai
				else
				{
					foreach (var bill in bills)
					{
						var billInfos = DBcontext.BillInfos
									.Where(bi => bi.IdBill == bill.Id && bi.IdFood == foodId)
									.ToList();
						//add them mon neu mon do chua dc order
						if (!billInfos.Any())
						{
							if (quantityFood <= 0)
							{
								MessageBox.Show("Số lượng món thêm vào phải lớn hơn 0");
							}
							else
							{
								AddBillInfo(bill.Id, foodId, quantityFood);
								DBcontext.SaveChanges();
								//re-load after change
								ShowBill(tableID);
								ShowTotalAmount(tableID);
								MessageBox.Show("Thêm món thành công!");
							}
						}
						//them so luong neu mon do da dc order
						else
						{
							foreach (var billInfo in billInfos)
							{
								int quantityUpdate = quantityFood + billInfo.Count;
								if (quantityUpdate < 0)
								{
									MessageBox.Show("Số lượng món không thể âm");
								}
								//xoa mon an
								else if (quantityUpdate == 0)
								{
									DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xóa món ăn này?", "WARNING",
									MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
									if (dlr == DialogResult.OK)
									{
										DBcontext.BillInfos.Remove(billInfo);
										DBcontext.SaveChanges();
										//re-load after change
										ShowBill(tableID);
										ShowTotalAmount(tableID);
										MessageBox.Show("Món ăn đã được xóa khỏi bill");
									}
								}
								else
								{
									billInfo.Count = quantityUpdate;
									DBcontext.SaveChanges();
									//re-load after change
									ShowBill(tableID);
									ShowTotalAmount(tableID);
									MessageBox.Show("Cập nhật số lượng món thành công!");
								}
							}
						}
					}
				}
			}
		}
		private void AddBill(DateTime dateCheckIn, DateTime dateCheckOut, int idTable, double discount, decimal totalBill, int status)
		{
			var newBill = new Bill
			{
				DateCheckIn = dateCheckIn,
				DateCheckOut = dateCheckOut,
				IdTable = idTable,
				Discount = discount,
				TotalBill = totalBill,
				Status = status
			};

			DBcontext.Bills.Add(newBill);
			DBcontext.SaveChanges();
		}
		private void AddBillInfo(int idBill, int idFood, int count)
		{
			var newBillInfo = new BillInfo
			{
				IdBill = idBill,
				IdFood = idFood,
				Count = count
			};
			DBcontext.BillInfos.Add(newBillInfo);
			DBcontext.SaveChanges();
		}


		private void btnBookTable_Click(object sender, EventArgs e)
		{
			fBookTable bookTable = new fBookTable();
			bookTable.ShowDialog();
		}
		private void pdBill_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			if (tbOldTableID.Text != "")
			{
				int tableID = Convert.ToInt32(tbOldTableID.Text.ToString());
				var query = from b in DBcontext.Bills
							join bi in DBcontext.BillInfos on b.Id equals bi.IdBill
							join f in DBcontext.Foods on bi.IdFood equals f.Id
							where b.Status == 1 && b.IdTable == tableID
							group new { bi, f } by new { bi.IdFood, f.Name, f.Price } into grouped
							select new
							{
								Name = grouped.Key.Name,
								Price = grouped.Key.Price,
								Quantity = grouped.Sum(item => item.bi.Count),
								Total = grouped.Key.Price * grouped.Sum(item => item.bi.Count)
							};
				e.Graphics.DrawString("==========Hóa Đơn Thanh Toán Của Bàn " + tableID + "==========", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(50));
				int startX = 10;
				int startY = 150;
				int columnSpacing = 50;
				int rowHeight = 40;

				e.Graphics.DrawString("Tên Món", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Blue, new Point(startX, startY));
				e.Graphics.DrawString("Giá", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + 300 + columnSpacing, startY));
				e.Graphics.DrawString("Số Lượng", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + columnSpacing + 500, startY));
				e.Graphics.DrawString("Tổng", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Blue, new Point(startX + columnSpacing + 600 + columnSpacing, startY));
				foreach (var item in query)
				{
					startY += rowHeight;

					e.Graphics.DrawString(item.Name, new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(startX, startY));
					e.Graphics.DrawString(item.Price.ToString("N0") + " VND", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(startX + 300 + columnSpacing, startY));
					e.Graphics.DrawString(item.Quantity.ToString(), new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(startX + columnSpacing + 500, startY));
					e.Graphics.DrawString(item.Total.ToString("N0") + " VND", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Black, new Point(startX + columnSpacing + 600 + columnSpacing, startY));
				}
				e.Graphics.DrawString("================================================================================", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(20, startY + rowHeight));

				int discount = Convert.ToInt32(nmDisCount.Value);
				if (tbTotalMoney.Tag != null && double.TryParse(tbTotalMoney.Tag.ToString(), out double totalAmount))
				{
					e.Graphics.DrawString("Tổng: " + totalAmount.ToString("N0") + " VND", new Font("Century Gothic", 14, FontStyle.Bold), Brushes.Black, new Point(500, startY + rowHeight * 2));
					double totalAmountDiscount = totalAmount - totalAmount * discount / 100;
					e.Graphics.DrawString("Giảm giá: " + discount + " %", new Font("Century Gothic", 14, FontStyle.Bold), Brushes.Black, new Point(500, startY + rowHeight * 3));
					e.Graphics.DrawString("Thành Tiền: " + totalAmountDiscount.ToString("N0") + " VND", new Font("Century Gothic", 14, FontStyle.Bold), Brushes.Black, new Point(500, startY + rowHeight * 4));
				}
			}
		}
		
		private void btnListBookTable_Click(object sender, EventArgs e)
		{
			PrintPreviewDialog ppdBill = new PrintPreviewDialog();
			if (ppdBill.ShowDialog() == DialogResult.OK)
			{
				pdBill.Print();
			}
		}

		private void btnBill_Click(object sender, EventArgs e)
		{
			PrintPreviewDialog ppdBill = new PrintPreviewDialog();
			if (ppdBill.ShowDialog() == DialogResult.OK)
			{
				pdBill.Print();
			}
		}
	}
}
