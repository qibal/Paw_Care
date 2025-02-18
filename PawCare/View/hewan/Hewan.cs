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
using PawCare.View.hewan;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using MySql.Data.MySqlClient;

using LicenseContext = OfficeOpenXml.LicenseContext; // Add this line to resolve ambiguity


namespace PawCare.View
{
    public partial class Hewan : Form
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_save_animal;
        private System.Windows.Forms.ComboBox category_id;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.TextBox animal_name;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button image;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox category_name;
        private System.Windows.Forms.Button btn_save_category;
        private System.Windows.Forms.ComboBox CB_gender;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Hewan parentForm;
        public Hewan()
        {
            InitializeComponent();
            LoadImage();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Use the correct enum here
        }




        public void LoadImage()
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Create an instance of the controller
            C_Animal animalController = new C_Animal();

            // Get the list of animals
            List<M_Animal> animals = animalController.GetAnimals();

            foreach (M_Animal animal in animals)
            {
                // Create a Panel to hold all controls
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 250; // Adjust height to accommodate all controls
                panel.Margin = new Padding(10);

                // Create a Panel for the header (Animal Name and Gender)
                Panel headerPanel = new Panel();
                headerPanel.Dock = DockStyle.Top;
                headerPanel.Height = 30;

                // Create a Label for the animal name
                Label nameLabel = new Label();
                nameLabel.Text = animal.Animal_name;
                nameLabel.AutoSize = false;
                nameLabel.TextAlign = ContentAlignment.MiddleLeft;
                nameLabel.Dock = DockStyle.Left;
                nameLabel.Width = 100;

                // Create a Label for the animal gender
                Label genderLabel = new Label();
                genderLabel.Text = animal.Gender;
                genderLabel.AutoSize = false;
                genderLabel.TextAlign = ContentAlignment.MiddleRight;
                genderLabel.Dock = DockStyle.Fill;

                // Add labels to the header panel
                headerPanel.Controls.Add(genderLabel);
                headerPanel.Controls.Add(nameLabel);

                // Create a PictureBox for the animal image
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 180;
                pictureBox.Height = 180;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Tag = animal.Animal_id; // Set the Tag property to the animal_id
                pictureBox.Click += PictureBox_Click; // Add the click event handler
                pictureBox.Dock = DockStyle.Fill;

                // Load the image
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string imagePath = Path.Combine(projectDirectory, animal.Image_path);

                if (File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                }
                else
                {
                    // Use the placeholder image from resources
                    pictureBox.Image = Properties.Resources.placeholder_image;
                }

                // Create a Delete Button
                Button deleteButton = new Button();
                deleteButton.Text = "Delete";
                deleteButton.Width = 180;
                deleteButton.Height = 30;
                deleteButton.Tag = animal.Animal_id;
                deleteButton.Click += DeleteButton_Click;
                deleteButton.Dock = DockStyle.Bottom;

                // Add controls to the main panel
                panel.Controls.Add(deleteButton);
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(headerPanel);

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
            }
        }

     





        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null && button.Tag != null)
            {
                string animalId = button.Tag.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this animal?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    C_Animal animalController = new C_Animal();
                    animalController.DeleteAnimal(animalId);
                    LoadImage(); // Refresh the image list
                }
            }
        }
        // Add this method in Hewan.cs

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            FormHewan childForm = new FormHewan(this, null); // Pass null or a valid animalId
            childForm.Show();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag != null)
            {
                string animalId = pictureBox.Tag.ToString();
                FormHewan childForm = new FormHewan(this, animalId);
                childForm.Show();
            }
        }


       

        private void LoadAnimalData(string animalId)
        {
            C_Animal animalController = new C_Animal();
            M_Animal animal = animalController.GetAnimalById(animalId);

            if (animal != null)
            {
                animal_name.Text = animal.Animal_name;
                CB_gender.SelectedItem = animal.Gender;
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
        private void btn_export_Click(object sender, EventArgs e)
        {
            // Get the project directory
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string excelFolderPath = Path.Combine(projectDirectory, "excel");

            // Create the 'excel' folder if it doesn't exist
            if (!Directory.Exists(excelFolderPath))
            {
                Directory.CreateDirectory(excelFolderPath);
            }

            // Generate a unique filename
            string fileName = "Animals_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
            string filePath = Path.Combine(excelFolderPath, fileName);

            // Get data from the database
            C_Animal animalController = new C_Animal();
            List<M_Animal> animals = animalController.GetAnimals();

            // Use EPPlus to create an Excel file
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Animals");

                // Add headers
                worksheet.Cells[1, 1].Value = "Animal Name";
                worksheet.Cells[1, 2].Value = "Gender";
                worksheet.Cells[1, 3].Value = "Age";
                worksheet.Cells[1, 4].Value = "Category";
                worksheet.Cells[1, 5].Value = "Created At";
                worksheet.Cells[1, 6].Value = "Updated At";
                worksheet.Cells[1, 7].Value = "Image";

                int row = 2;
                foreach (M_Animal animal in animals)
                {
                    worksheet.Cells[row, 1].Value = animal.Animal_name;
                    worksheet.Cells[row, 2].Value = animal.Gender;
                    worksheet.Cells[row, 3].Value = animal.Age;
                    worksheet.Cells[row, 4].Value = animal.Category_name;
                    worksheet.Cells[row, 5].Value = animal.Created_at;
                    worksheet.Cells[row, 6].Value = animal.Updated_at;

                    // Set date format for Created At and Updated At columns
                    worksheet.Cells[row, 5].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";
                    worksheet.Cells[row, 6].Style.Numberformat.Format = "dd-MM-yyyy HH:mm";

                    // Load the image from the file
                    string imagePath = Path.Combine(projectDirectory, animal.Image_path);

                    if (File.Exists(imagePath))
                    {
                        // Add image to worksheet
                        var excelImage = worksheet.Drawings.AddPicture("Image" + row, new FileInfo(imagePath));

                        // Set image position
                        excelImage.SetPosition(row - 1, 0, 6, 0);
                        excelImage.SetSize(75, 75);

                        // Adjust the row height
                        worksheet.Row(row).Height = 60;
                    }

                    row++;
                }

                // Auto-fit columns
                worksheet.Cells.AutoFitColumns();

                // Save the Excel file
                try
                {
                    package.SaveAs(new FileInfo(filePath));
                    MessageBox.Show($"Data exported successfully to {filePath}.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}");
                }
            }
        }



    }
}
