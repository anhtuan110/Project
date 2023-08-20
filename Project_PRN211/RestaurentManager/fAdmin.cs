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
using System.Xml.Linq;

namespace RestaurentManager
{
    public partial class fAdmin : Form
    {
        BindingSource categoryList = new BindingSource();

        public fAdmin()
        {
            InitializeComponent();
            dtgvCategory.DataSource = categoryList;
            binddingCategory();
            loadCategory();
        }

        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory().Select(x => new
            {
                id = x.Id, name = x.Name,
            });

        }

        void binddingCategory()
        {
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));


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
    }
}
