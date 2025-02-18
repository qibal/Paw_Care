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
        private C_CategoryPeralatan categoryController = new C_CategoryPeralatan();

        public FormPeralatan()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void LoadCategories()
        {
            DataTable dt = categoryController.GetCategories();
            table_category.Controls.Clear();
            table_category.RowCount = 0;
            category_id.Items.Clear();

            foreach (DataRow row in dt.Rows)
            {
                table_category.RowCount++;
                table_category.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label lblCategoryName = new Label();
                lblCategoryName.Text = row["category_name"].ToString();
                lblCategoryName.Dock = DockStyle.Fill;
                table_category.Controls.Add(lblCategoryName, 0, table_category.RowCount - 1);

                Button btnDelete = new Button();
                btnDelete.Text = "Delete";
                btnDelete.Tag = row["category_id"].ToString();
                btnDelete.Click += BtnDelete_Click;
                table_category.Controls.Add(btnDelete, 1, table_category.RowCount - 1);

                // Add category to ComboBox
                category_id.Items.Add(new ComboBoxItem(row["category_name"].ToString(), row["category_id"].ToString()));
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = sender as Button;
            string categoryId = btnDelete.Tag.ToString();

            categoryController.DeleteCategory(categoryId);
            MessageBox.Show("Category deleted successfully!");

            // Refresh the category list
            LoadCategories();
        }
        private void btn_save_category_Click(object sender, EventArgs e)
        {
            string categoryName = category_name.Text; // Ensure category_name is a TextBox

            if (!string.IsNullOrEmpty(categoryName))
            {
                M_CategoryPeralatan newCategory = new M_CategoryPeralatan
                {
                    Category_id = Guid.NewGuid().ToString(),
                    Category_name = categoryName,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };

                categoryController.InsertCategory(newCategory);
                MessageBox.Show("Category added successfully!");

                // Refresh the category list
                LoadCategories();
            }
            else
            {
                MessageBox.Show("Category name cannot be empty.");
            }
        }
        private void btn_save_equipment_Click(object sender, EventArgs e)
        {
            string equipmentName = equipment_name.Text;
            int equipmentAmount;
            string imagePath = ""; // Add logic to get the image path
            ComboBoxItem selectedCategory = category_id.SelectedItem as ComboBoxItem;

            if (string.IsNullOrEmpty(equipmentName) || !int.TryParse(amount.Text, out equipmentAmount) || selectedCategory == null)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            M_Peralatan newEquipment = new M_Peralatan
            {
                Equipment_id = Guid.NewGuid().ToString(),
                Equipment_name = equipmentName,
                Amount = equipmentAmount,
                Image_path = imagePath,
                Category_id = selectedCategory.Value,
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };

            // Add logic to save the new equipment
            MessageBox.Show("Equipment added successfully!");
        }

        private void table_category_Paint(object sender, PaintEventArgs e)
        {

        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboBoxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }
    }
}
