using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PawCare.Controller;

namespace PawCare.Model
{
    internal class M_home
    {
        private Koneksi koneksi;

        public M_home()
        {
            koneksi = new Koneksi();
        }

        public int GetTotalAnimals()
        {
            int totalAnimals = 0;
            string query = "SELECT COUNT(*) FROM animal";

            try
            {
                koneksi.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, koneksi.kon);
                totalAnimals = Convert.ToInt32(command.ExecuteScalar());
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

            return totalAnimals;
        }
    }
}
