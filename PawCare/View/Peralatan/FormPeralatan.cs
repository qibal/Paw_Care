using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private string imageFilePath;
        private string imageFileName;
        private string existingImagePath = null; // To store existing image path
        private Peralatan parentForm;
        private string existingEquipmentId = null;

        public FormPeralatan(Peralatan parent, string equipmentId)
        {
            InitializeComponent();
            LoadCategories();
            parentForm = parent;

            if (!string.IsNullOrEmpty(equipmentId))
            {
                existingEquipmentId = equipmentId;
                LoadEquipmentData(equipmentId);
            }
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

        private void LoadEquipmentData(string equipmentId)
        {
            C_Peralatan peralatanController = new C_Peralatan();
            M_Peralatan equipment = peralatanController.GetEquipmentById(equipmentId);

            if (equipment != null)
            {
                equipment_name.Text = equipment.Equipment_name;
                amount.Text = equipment.Amount.ToString();

                // Set the selected category
                foreach (ComboBoxItem item in category_id.Items)
                {
                    if (item.Value == equipment.Category_id)
                    {
                        category_id.SelectedItem = item;
                        break;
                    }
                }

                // Store existing image path
                existingImagePath = equipment.Image_path;

                // Load the image
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string imagePath = Path.Combine(projectDirectory, equipment.Image_path);

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox1.Image = Properties.Resources.placeholder_image;
                }
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
            ComboBoxItem selectedCategory = category_id.SelectedItem as ComboBoxItem;

            if (string.IsNullOrEmpty(equipmentName) || !int.TryParse(amount.Text, out equipmentAmount) || selectedCategory == null)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            string imagePath;

            // Check if a new image is selected
            if (!string.IsNullOrEmpty(imageFilePath))
            {
                // Save the new image and get the relative path
                imagePath = SaveImage();
            }
            else
            {
                // Use the existing image path
                imagePath = existingImagePath;
            }

            M_Peralatan newEquipment = new M_Peralatan
            {
                Equipment_id = string.IsNullOrEmpty(existingEquipmentId) ? Guid.NewGuid().ToString() : existingEquipmentId,
                Equipment_name = equipmentName,
                Amount = equipmentAmount,
                Image_path = imagePath,
                Category_id = selectedCategory.Value,
                Created_at = string.IsNullOrEmpty(existingEquipmentId) ? DateTime.Now : GetExistingEquipmentCreatedAt(existingEquipmentId),
                Updated_at = DateTime.Now
            };

            C_Peralatan controller = new C_Peralatan();

            try
            {
                if (string.IsNullOrEmpty(existingEquipmentId))
                {
                    // Insert operation
                    controller.InsertEquipment(newEquipment);
                    MessageBox.Show("Equipment added successfully!");
                }
                else
                {
                    // Update operation
                    controller.UpdateEquipment(newEquipment);
                    MessageBox.Show("Equipment updated successfully!");
                }

                ClearForm();
                parentForm.LoadEquipment();
                this.Close(); // Optionally close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving equipment data: {ex.Message}");
            }
        }

        private DateTime GetExistingEquipmentCreatedAt(string equipmentId)
        {
            C_Peralatan controller = new C_Peralatan();
            M_Peralatan existingEquipment = controller.GetEquipmentById(equipmentId);
            return existingEquipment != null ? existingEquipment.Created_at : DateTime.Now;
        }

        private string SaveImage()
        {
            if (string.IsNullOrEmpty(imageFilePath))
            {
                throw new ArgumentNullException(nameof(imageFilePath), "Image file path is null or empty.");
            }

            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string imagesPath = Path.Combine(projectDirectory, "Image");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            // Generate a unique filename using GUID
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFileName);
            string targetPath = Path.Combine(imagesPath, uniqueFileName);

            try
            {
                // Copy the selected image to the project's Image folder
                File.Copy(imageFilePath, targetPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}");
                return existingImagePath; // Return existing path if image saving fails
            }

            // Return the relative path to store in the database
            return Path.Combine("Image", uniqueFileName);
        }

        private void image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFilePath = openFileDialog.FileName;
                    imageFileName = Path.GetFileName(imageFilePath);
                    pictureBox1.Image = Image.FromFile(imageFilePath);
                }
            }
        }

        private void ClearForm()
        {
            equipment_name.Text = "";
            amount.Text = "";
            pictureBox1.Image = null;
            category_id.SelectedIndex = -1;
            imageFilePath = null;
            imageFileName = null;
            existingImagePath = null;
            existingEquipmentId = null;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void equipment_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void image_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imageFilePath = openFileDialog.FileName;
                    imageFileName = Path.GetFileName(imageFilePath);
                    pictureBox1.Image = Image.FromFile(imageFilePath);
                }
            }
        }

        private void btn_save_equipment_Click_1(object sender, EventArgs e)
        {
            string equipmentName = equipment_name.Text;
            int equipmentAmount;
            ComboBoxItem selectedCategory = category_id.SelectedItem as ComboBoxItem;

            if (string.IsNullOrEmpty(equipmentName) || !int.TryParse(amount.Text, out equipmentAmount) || selectedCategory == null)
            {
                MessageBox.Show("Please fill in all fields correctly.");
                return;
            }

            string imagePath;

            // Check if a new image is selected
            if (!string.IsNullOrEmpty(imageFilePath))
            {
                // Save the new image and get the relative path
                imagePath = SaveImage();
            }
            else
            {
                // Use the existing image path
                imagePath = existingImagePath;
            }

            M_Peralatan newEquipment = new M_Peralatan
            {
                Equipment_id = string.IsNullOrEmpty(existingEquipmentId) ? Guid.NewGuid().ToString() : existingEquipmentId,
                Equipment_name = equipmentName,
                Amount = equipmentAmount,
                Image_path = imagePath,
                Category_id = selectedCategory.Value,
                Created_at = string.IsNullOrEmpty(existingEquipmentId) ? DateTime.Now : GetExistingEquipmentCreatedAt(existingEquipmentId),
                Updated_at = DateTime.Now
            };

            C_Peralatan controller = new C_Peralatan();

            try
            {
                if (string.IsNullOrEmpty(existingEquipmentId))
                {
                    // Insert operation
                    controller.InsertEquipment(newEquipment);
                    MessageBox.Show("Equipment added successfully!");
                }
                else
                {
                    // Update operation
                    controller.UpdateEquipment(newEquipment);
                    MessageBox.Show("Equipment updated successfully!");
                }

                ClearForm();
                parentForm.LoadEquipment();
                this.Close(); // Optionally close the form after saving
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving equipment data: {ex.Message}");
            }
        }

        private void category_id_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

