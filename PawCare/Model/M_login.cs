using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PawCare.Controller;
namespace PawCare.Model
{
    internal class M_login
    {
        private Koneksi koneksi;

        public M_login()
        {
            koneksi = new Koneksi();
        }

        public bool CheckPin(string pin)
        {
            bool isValid = false;
            string query = "SELECT COUNT(*) FROM user WHERE pin = @pin";

            try
            {
                koneksi.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, koneksi.kon);
                command.Parameters.AddWithValue("@pin", pin);
                int count = Convert.ToInt32(command.ExecuteScalar());
                isValid = count > 0;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                Console.WriteLine(ex.Message);
            }
            finally
            {
                koneksi.CloseConnection();
            }

            return isValid;
        }
    }
}
