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

namespace PawCare.View
{
    public partial class Hewan : Form
    {
        public Hewan()
        {
            InitializeComponent();
            LoadImage();
        }

        public void LoadImage()
        {
            //// 1. Dapatkan direktori root proyek
            //string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            //// 2. Bangun path gambar yang benar
            //string imagePath = Path.Combine(projectDirectory, "Image", "cat_1.jpeg");

            //try
            //{
            //    if (File.Exists(imagePath))
            //    {
            //        animal_image.Image = Image.FromFile(imagePath);
            //    }
            //    //else
            //    //{
            //    //    MessageBox.Show($"File not found: {imagePath}");
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading image: {ex.Message}");
            //}

            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Create an instance of the controller
            C_Animal animalController = new C_Animal();

            // Get the list of animals
            List<M_Animal> animals = animalController.GetAnimals();

            foreach (M_Animal animal in animals)
            {
                // Create a Panel to hold the PictureBox and Label
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 250;
                panel.Margin = new Padding(10);

                // Create a PictureBox for the animal image
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 180;
                pictureBox.Height = 180;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
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


                // Create a Label for the animal name
                Label nameLabel = new Label();
                nameLabel.Text = animal.Animal_name;
                nameLabel.AutoSize = false;
                nameLabel.TextAlign = ContentAlignment.MiddleCenter;
                nameLabel.Dock = DockStyle.Bottom;

                // Add controls to the panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(nameLabel);

                // Add the panel to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(panel);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHewan childForm = new FormHewan(this);
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
