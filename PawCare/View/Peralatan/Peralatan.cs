using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawCare.View.hewan;

using PawCare.Controller;
using PawCare.Model;
using System.IO;
namespace PawCare.View.Peralatan
{
    public partial class Peralatan : Form
    {
        public Peralatan()
        {
            InitializeComponent();
            LoadEquipment();
        }

        public void LoadEquipment()
        {
            // Clear existing controls
            flowLayoutPanel1.Controls.Clear();

            // Create an instance of the controller
            C_Peralatan peralatanController = new C_Peralatan();

            // Get the list of equipment
            List<M_Peralatan> equipmentList = peralatanController.GetAllEquipment();

            foreach (M_Peralatan equipment in equipmentList)
            {
                // Create a Panel to hold all controls
                Panel panel = new Panel();
                panel.Width = 200;
                panel.Height = 250; // Adjust height to accommodate all controls
                panel.Margin = new Padding(10);

                // Create a Panel for the header (Equipment Name and Category)
                Panel headerPanel = new Panel();
                headerPanel.Dock = DockStyle.Top;
                headerPanel.Height = 30;

                // Create a Label for the equipment name
                Label nameLabel = new Label();
                nameLabel.Text = equipment.Equipment_name;
                nameLabel.AutoSize = false;
                nameLabel.TextAlign = ContentAlignment.MiddleLeft;
                nameLabel.Dock = DockStyle.Left;
                nameLabel.Width = 100;

                // Create a Label for the equipment category
                Label categoryLabel = new Label();
                categoryLabel.Text = equipment.Category_name;
                categoryLabel.AutoSize = false;
                categoryLabel.TextAlign = ContentAlignment.MiddleRight;
                categoryLabel.Dock = DockStyle.Fill;

                // Add labels to the header panel
                headerPanel.Controls.Add(categoryLabel);
                headerPanel.Controls.Add(nameLabel);

                // Create a PictureBox for the equipment image
                PictureBox pictureBox = new PictureBox();
                pictureBox.Width = 180;
                pictureBox.Height = 180;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox.Tag = equipment.Equipment_id; // Set the Tag property to the equipment_id
                pictureBox.Click += PictureBox_Click; // Add the click event handler
                pictureBox.Dock = DockStyle.Fill;

                // Load the image
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
                string imagePath = Path.Combine(projectDirectory, equipment.Image_path);

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
                deleteButton.Tag = equipment.Equipment_id;
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
                string equipmentId = button.Tag.ToString();
                DialogResult result = MessageBox.Show("Are you sure you want to delete this equipment?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    C_Peralatan peralatanController = new C_Peralatan();
                    peralatanController.DeleteEquipment(equipmentId);
                    LoadEquipment(); // Refresh the equipment list
                }
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag != null)
            {
                string equipmentId = pictureBox.Tag.ToString();
                FormPeralatan childForm = new FormPeralatan(this, equipmentId);
                childForm.Show();
            }
        }

        private void btn_view_add_Click(object sender, EventArgs e)
        {
            FormPeralatan childForm = new FormPeralatan(this, null); // Pass null or a valid equipmentId
            childForm.Show();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
