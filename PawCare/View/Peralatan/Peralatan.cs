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

namespace PawCare.View.Peralatan
{
    public partial class Peralatan : Form
    {
        public Peralatan()
        {
            InitializeComponent();
        }

        private void btn_view_add_Click(object sender, EventArgs e)
        {
            FormPeralatan childForm = new FormPeralatan(); // Pass null or a valid animalId
            childForm.Show();
        }
    }
}
