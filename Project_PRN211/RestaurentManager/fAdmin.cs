using RestaurentManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RestaurentManager
{
    public partial class fAdmin : Form
    {
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            dtgvCategory.DataSource = categoryList;
            dgvTable.DataSource = tableList;
            binddingCategory();
            binddingTable();
            BindTableStatusToComboBox();
            loadCategory();
            loadTable();

            dgvTable.CellClick += dgvTable_CellClick;
        }

        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory().Select(x => new
            {
                id = x.Id,
                name = x.Name,
            });
        }

        void binddingCategory()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }
        void binddingTable()
        {

            txtTableID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            
        }
        private void BindTableStatusToComboBox()
        {
            List<string> statusList = new List<string> { "Vắng", "Bận"};
            cbTableStatus.DataSource = statusList;
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTable.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvTable.Rows[e.RowIndex];
                string selectedStatus = selectedRow.Cells["Status"].Value.ToString();
                cbTableStatus.SelectedItem = selectedStatus;
            }
        }


        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            addCategory(name);
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

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryID.Text);

            deleleCategory(id);
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

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryID.Text);
            string name = txtCategoryName.Text;
            updateCategory(id, name);
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

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            loadCategory();
        }

        // quản lí bàn 

        void loadTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable().Select(x => new
            {
                id = x.Id,
                name = x.Name,
                status = x.Status,
            });
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;
            string status = cbTableStatus.Text; // Thay bằng trạng thái mặc định
            addTable(name, status);
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

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableID.Text);
            deleleTable(id);
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

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableID.Text);
            string name = txtTableName.Text;
            string status = cbTableStatus.Text;
            updateTable(id, name, status);
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

        private void btnShowTable_Click(object sender, EventArgs e)
        {
           loadTable();
        }
    }
}
