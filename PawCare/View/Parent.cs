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
using PawCare.View.Peralatan;

namespace PawCare
{
    public partial class Parent : Form
    {
        private Hewan parentForm;
        public Parent()
        {
            InitializeComponent();
            this.Size = new Size(700, 400);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowChildForm(new Home());
        }

        private void hewanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            ShowChildForm(new Hewan());
        }

        private void peralatanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            ShowChildForm(new Peralatan());
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForms();
            ShowChildForm(new Home());
        }

        private void CloseAllChildForms()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }
        private void ShowChildForm(Form childForm)
        {
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Maximized;
            childForm.Show();
        }
    }
}
