using Microsoft.EntityFrameworkCore;
using RestaurentManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManager
{
    public partial class fBookTable : Form
    {
        private readonly QuanLyNhaHangContext DBcontext = new();
        public fBookTable()
        {
            InitializeComponent();
        }
        Dictionary<int, TimeSpan> bookTableMap = new Dictionary<int, TimeSpan>();
        private void fBookTable_Load(object sender, EventArgs e)
        {
            cbTable.DataSource = DBcontext.TableFoods.ToList();
            cbTable.DisplayMember = "Name";
        }

        private void btnBookTableAcp_Click(object sender, EventArgs e)
        {

            DateTime selectedTimeTableBook = timeBook.Value;
            TimeSpan timeTableBook = selectedTimeTableBook.TimeOfDay;
            DateTime dateTableBook = DateTime.Now;
            int idTable = (cbTable.SelectedItem as TableFood).Id;
            bool isLunch = rdLunch.Checked ? true : false;
            string nameCustomer = tbNameCustom.Text.ToString();
            string phoneCustomer = tbPhoneCustom.Text;
            if (!IsValidPhoneNumber(phoneCustomer))
            {
                MessageBox.Show("Invalid Phone Number!", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPhoneCustom.Focus();
                return;
            }
            AddBookTable(idTable, timeTableBook, dateTableBook, isLunch, nameCustomer, phoneCustomer);
        }
        public static bool IsValidPhoneNumber(string input)
        {
            string pattern = @"^(\+|0|84)?[1-9][0-9-]{8,14}$";
            return Regex.IsMatch(input, pattern);
        }
        private void AddBookTable(int idTable, TimeSpan timeTableBook, DateTime dateTableBook, bool brunch, string nameCustomer, string phoneCustomer)
        {
            // Khai báo tên tệp tin và đường dẫn
            string fileName = "reservations.txt";

            // List để lưu thông tin đặt bàn
            List<string> reservations = new List<string>();

            // Đọc từ tệp tin (nếu tồn tại)
            if (File.Exists(fileName))
            {
                reservations.AddRange(File.ReadAllLines(fileName));
            }

            // Thêm thông tin đặt bàn
            reservations.Add($"{idTable},{timeTableBook},{dateTableBook},{brunch},{nameCustomer},{phoneCustomer}");

            // Ghi vào tệp tin
            File.WriteAllLines(fileName, reservations);

            // Truy cập thông tin đặt bàn
            foreach (var reservation in reservations)
            {
                string[] parts = reservation.Split(',');
                int reservedTableId = int.Parse(parts[0]);
                DateTime reservedTime = DateTime.Parse(parts[1]);

                Console.WriteLine($"Bàn số {reservedTableId} đã đặt lịch vào lúc {reservedTime}.");
            }
        }

        private void AddBillToBookTable(DateTime dateCheckIn, int idTable)
        {
            var newBill = new Bill
            {
                DateCheckIn = dateCheckIn,
                DateCheckOut = DateTime.Now,
                IdTable = idTable,
                Discount = 0,
                TotalBill = 0,
                Status = 1
            };
            DBcontext.Bills.Add(newBill);
            DBcontext.SaveChanges();
        }
    }
}
