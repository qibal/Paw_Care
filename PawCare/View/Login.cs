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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PawCare.View
{
    public partial class Login : Form
    {
        private C_login controller;

        public Login()
        {
            InitializeComponent();
            this.Size = new Size(700, 400);
            controller = new C_login();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void input_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void input_password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ValidateLogin();
            }
        }

        private void ValidateLogin()
        {
            if (string.IsNullOrEmpty(input_password.Text))
            {
                MessageBox.Show("Pin tidak boleh kosong !!!");
            }
            else
            {
                string pin = input_password.Text;

                // Check if the pin is correct
                if (controller.CheckPin(pin))
                {
                    MessageBox.Show("Login Berhasil", "Berhasil");

                    // Hide the Login form
                    this.Hide();

                    // Show the Parent form using 'using' statement
                    using (Parent parentForm = new Parent())
                    {
                        parentForm.ShowDialog();
                    }

                    // Close the Login form after the Parent form is closed
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Pin Salah", "Gagal");
                    input_password.Clear();
                    input_password.Focus();
                }
            }
        }

        private void input_password_KeyDown(object sender, KeyEventArgs e)
        {
        }

    }
}
