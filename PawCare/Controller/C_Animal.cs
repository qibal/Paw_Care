using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PawCare.Model;

namespace PawCare.Controller
{
    internal class C_Animal
    {
        private Koneksi conn = new Koneksi();


        public void InsertAnimal(M_Animal animal)
        {
            try
            {
                conn.OpenConnection();

                string query = "INSERT INTO animal (animal_id, animal_name, gender, age, image_path, category_id, created_at, update_at) " +
                               "VALUES (@animal_id, @animal_name, @gender, @age, @image_path, @category_id, @created_at, @updated_at)";

                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@animal_id", animal.Animal_id);
                cmd.Parameters.AddWithValue("@animal_name", animal.Animal_name);
                cmd.Parameters.AddWithValue("@gender", animal.Gender);
                cmd.Parameters.AddWithValue("@age", animal.Age);
                cmd.Parameters.AddWithValue("@image_path", animal.Image_path);
                cmd.Parameters.AddWithValue("@category_id", animal.Category_id);
                cmd.Parameters.AddWithValue("@created_at", animal.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", animal.Updated_at);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }

}
