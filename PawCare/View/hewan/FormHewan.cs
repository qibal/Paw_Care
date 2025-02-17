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
        private string imageFileName;
        private Hewan parentForm;

        public FormHewan(Hewan parent, string animalId)
        {
            InitializeComponent();
            LoadCategories();
            parentForm = parent;

            // Add gender options
            CB_gender.Items.Clear();
            CB_gender.Items.Add("Jantan");
            CB_gender.Items.Add("Betina");

            LoadAnimalData(animalId);
        }
        private void LoadAnimalData(string animalId)
        {
            C_Animal animalController = new C_Animal();
            M_Animal animal = animalController.GetAnimalById(animalId);

            if (animal != null)
            {
                animal_name.Text = animal.Animal_name;
                CB_gender.SelectedItem = MapGenderToDisplay(animal.Gender);
                age.Text = animal.Age.ToString();
                category_id.SelectedValue = animal.Category_id;

                // Load the image
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string imagePath = Path.Combine(projectDirectory, animal.Image_path);

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

        /// <summary>
        /// Maps the gender value from the database to the display value.
        /// </summary>
        /// <param name="gender">Gender value from the database ('male' or 'female').</param>
        /// <returns>Display gender value ('Jantan' or 'Betina').</returns>
        private string MapGenderToDisplay(string gender)
        {
            switch (gender.ToLower())
            {
                case "jantan":
                    return "Jantan";
                case "betina":
                    return "Betina";
                default:
                    return string.Empty;
            }
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
            // Open file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageFilePath = openFileDialog.FileName;
                imageFileName = Path.GetFileName(imageFilePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }
        }

        private void btn_simpan_Click(object sender, EventArgs e)
        {
          
        }

        private void image_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imageFilePath = dialog.FileName;
                imageFileName = Path.GetFileName(imageFilePath);
                pictureBox1.Image = Image.FromFile(imageFilePath);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private string SaveImage()
        {
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string imagesPath = Path.Combine(projectDirectory, "Image");

            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            // Generate a unique filename using GUID
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFileName);
            string targetPath = Path.Combine(imagesPath, uniqueFileName);

            // Copy the selected image to the project's Image folder
            File.Copy(imageFilePath, targetPath, true);

            // Return the relative path to store in the database
            return Path.Combine("Image", uniqueFileName);
        }
        private void animal_name_TextChanged(object sender, EventArgs e)
        {

        }
        private void ClearForm()
        {
            animal_name.Text = "";
            CB_gender.SelectedIndex = -1;
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

        private void btn_save_animal_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrEmpty(animal_name.Text) ||
                CB_gender.SelectedItem == null ||
                string.IsNullOrEmpty(age.Text) ||
                pictureBox1.Image == null ||
                category_id.SelectedValue == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validate age input
            if (!int.TryParse(age.Text, out int ageValue))
            {
                MessageBox.Show("Invalid age. Please enter a numeric value.");
                return;
            }

            // Save the image and get the relative path
            string imagePath = SaveImage();

            // Map display gender to database gender
            string dbGender = MapDisplayToGender(CB_gender.SelectedItem.ToString());

            // Create animal model
            M_Animal animal = new M_Animal
            {
                Animal_id = Guid.NewGuid().ToString(),
                Animal_name = animal_name.Text,
                Gender = dbGender,
                Age = ageValue,
                Image_path = imagePath,
                Category_id = category_id.SelectedValue.ToString(),
                Created_at = DateTime.Now,
                Updated_at = DateTime.Now
            };

            // Insert animal into database
            C_Animal controller = new C_Animal();
            controller.InsertAnimal(animal);

            MessageBox.Show("Data saved successfully.");
            ClearForm();
            parentForm.LoadImage();
        }
        private string MapDisplayToGender(string displayGender)
        {
            switch (displayGender.ToLower())
            {
                case "jantan":
                    return "Jantan";
                case "betina":
                    return "Betina";
                default:
                    return string.Empty;
            }
        }


        private void CB_gender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
