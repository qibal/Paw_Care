using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawCare.Controller;
using PawCare.Model;


namespace PawCare.View.Peralatan
{
    public partial class FormPeralatan : Form
    {
        public FormPeralatan()
        {
            InitializeComponent();
        }
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            string categoryName = categoryNameTextBox.Text;
            if (!string.IsNullOrEmpty(categoryName))
            {
                M_CategoryPeralatan newCategory = new M_CategoryPeralatan
                {
                    Category_id = Guid.NewGuid().ToString(),
                    Category_name = categoryName,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };
                C_CategoryPeralatan controller = new C_CategoryPeralatan();
                controller.AddCategory(newCategory);
                MessageBox.Show("Category added successfully!");
            }
            else
            {
                MessageBox.Show("Category name cannot be empty.");
            }
        }


    }
}
