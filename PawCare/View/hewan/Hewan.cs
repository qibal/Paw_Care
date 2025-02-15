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

        private void LoadImage()
        {
            // 1. Dapatkan direktori root proyek
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            // 2. Bangun path gambar yang benar
            string imagePath = Path.Combine(projectDirectory, "Image", "cat_1.jpeg");

            try
            {
                if (File.Exists(imagePath))
                {
                    animal_image.Image = Image.FromFile(imagePath);
                }
                //else
                //{
                //    MessageBox.Show($"File not found: {imagePath}");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormHewan childForm = new FormHewan();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }
    }
}
