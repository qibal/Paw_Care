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
        public Dictionary<string, int> GetGenderCounts()
        {
            Dictionary<string, int> genderCounts = new Dictionary<string, int>();
            string query = "SELECT gender, COUNT(*) FROM animal GROUP BY gender";

            try
            {
                koneksi.OpenConnection();
                MySqlCommand command = new MySqlCommand(query, koneksi.kon);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string gender = reader.GetString(0);
                    int count = Convert.ToInt32(reader.GetValue(1));
                    genderCounts.Add(gender, count);
                }

                reader.Close();
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

            return genderCounts;
        }
    }
}
