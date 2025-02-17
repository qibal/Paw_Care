using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using PawCare.Model;

namespace PawCare.Controller
{
    internal class C_CategoryAnimal
    {
        private Koneksi conn = new Koneksi();
        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();

            try
            {
                conn.OpenConnection();
                string query = "SELECT category_id, category_name FROM animal_category";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn.kon);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching categories: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }

            return dt;
        }
        public void InsertCategory(M_CategoryAnimal category)
        {
            try
            {
                conn.OpenConnection();

                string query = "INSERT INTO animal_category (category_id, category_name, created_at, updated_at) " +
                               "VALUES (@category_id, @category_name, @created_at, @updated_at)";

                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@category_id", category.Category_id);
                cmd.Parameters.AddWithValue("@category_name", category.Category_name);
                cmd.Parameters.AddWithValue("@created_at", category.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", category.Updated_at);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting category: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }
    }
}
