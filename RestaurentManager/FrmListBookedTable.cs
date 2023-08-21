using Microsoft.EntityFrameworkCore;
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
    public partial class FrmListBookedTable : Form
    {
        private readonly QuanLyNhaHangContext DBcontext = new();
        public FrmListBookedTable()
        {
            InitializeComponent();
        }

        private void FrmListBookedTable_Load(object sender, EventArgs e)
        {
            cbTable.DataSource = DBcontext.TableFoods.ToList();
            cbTable.DisplayMember = "Name";
        }
    }
}
