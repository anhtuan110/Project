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
        public fTableManager()
        {
            InitializeComponent();
            LoadBtnTableFood();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile fAccountProfile = new fAccountProfile();
            fAccountProfile.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
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
    }
}
