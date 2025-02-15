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
            this.Size = new Size(700, 400);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 5;
            if (progressBar1.Value >= 100)
            {
                timer1.Stop();

                // Hide the Loading form
                this.Hide();

                // Show the Login form using 'using' statement to ensure proper disposal
                using (Login loginForm = new Login())
                {
                    loginForm.ShowDialog();
                }

                // Close the Loading form after the Login form is closed
                this.Close();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
