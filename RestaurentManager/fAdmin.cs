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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RestaurentManager
{
    public partial class fAdmin : Form
    {
        private string LoadFilePath;
        public fAdmin()
        {
            InitializeComponent();
        }

        private void Load()
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


        private void btnShowFood_Click(object sender, EventArgs e)
        {
            Load();
        }

        private void tpFood_Click(object sender, EventArgs e)
        {
            Load();
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
                        Load();
                    }
                }
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

        private void btnEditFood_Click(object sender, EventArgs e)
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
                Load();

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
                        Load();
                    }
                }
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
                MessageBox.Show("Error");
            }
        }
    }
}
