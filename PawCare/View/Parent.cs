using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PawCare.View;

namespace PawCare
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Home childForm = new Home();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void hewanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hewan childForm = new Hewan();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void peralatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Peralatan childForm = new Peralatan();
            childForm.MdiParent = this;
            childForm.Show();
        }
    }
}
