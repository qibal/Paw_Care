using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PawCare.View
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Parent frm = new Parent();
            progressBar1.Value += 5;
            if (progressBar1.Value ==100)
            {
                timer1.Dispose();
                Hide();
                frm.Show();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }
    }
}
