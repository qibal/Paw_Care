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
using MySql.Data.MySqlClient;

namespace PawCare.View.hewan
{
    public partial class FormHewan : Form
    {
        private string imageFilePath;
        public FormHewan()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void btn_save_category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(category_name.Text))
            {
                MessageBox.Show("Please enter a category name.");
                return;
            }

            M_CategoryAnimal category = new M_CategoryAnimal();
            category.Category_id = Guid.NewGuid().ToString();
            category.Category_name = category_name.Text;
            category.Created_at = DateTime.Now;
            category.Updated_at = DateTime.Now;

            C_CategoryAnimal controller = new C_CategoryAnimal();
            controller.InsertCategory(category);

            MessageBox.Show("Category saved successfully.");
            category_name.Text = "";
            LoadCategories(); // Refresh the ComboBox
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
        }
        private void btn_simpan_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(animal_name.Text) ||
                string.IsNullOrEmpty(gender.Text) ||
                string.IsNullOrEmpty(age.Text) ||
                pictureBox1.Image == null ||
                category_id.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Create animal model
            M_Animal animal = new M_Animal();
            animal.Animal_id = Guid.NewGuid().ToString();
            animal.Animal_name = animal_name.Text;
            animal.Gender = gender.Text;
            animal.Age = int.Parse(age.Text);
            animal.Image_path = SaveImage();
            animal.Category_id = category_id.SelectedValue.ToString();
            animal.Created_at = DateTime.Now;
            animal.Updated_at = DateTime.Now;

            // Insert animal into database
            C_Animal controller = new C_Animal();
            controller.InsertAnimal(animal);

            MessageBox.Show("Data saved successfully.");
            ClearForm();
        }
        private void image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageFilePath = dialog.FileName;
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private string SaveImage()
        {
            string fileName = Path.GetFileName(imageFilePath);
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string imagesPath = Path.Combine(projectDirectory, "Images");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            string targetPath = Path.Combine(imagesPath, fileName);
            pictureBox1.Image.Save(targetPath);
            return targetPath;
        }
        private void animal_name_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearForm()
        {
            animal_name.Text = "";
            gender.Text = "";
            age.Text = "";
            pictureBox1.Image = null;
            category_id.SelectedIndex = -1;
        }
        private void LoadCategories()
        {
            C_CategoryAnimal categoryController = new C_CategoryAnimal();
            DataTable categories = categoryController.GetCategories();

            category_id.DataSource = categories;
            category_id.DisplayMember = "category_name";
            category_id.ValueMember = "category_id";
        }

     
    }
}
