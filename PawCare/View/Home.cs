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


namespace PawCare.View
{
    public partial class Home : Form
    {
        private C_home controller;

        public Home()
        {
            InitializeComponent();
            controller = new C_home();
            LoadTotalAnimals();
        }

        private void LoadTotalAnimals()
        {
            int totalAnimals = controller.GetTotalAnimals();
            counted_animal.Text = totalAnimals.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
