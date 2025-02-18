using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawCare.Model;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace PawCare.Controller
{
    internal class C_CategoryPeralatan
    {
        private Koneksi conn = new Koneksi();

        public DataTable GetCategories()
        {
            DataTable dt = new DataTable();

            try
            {
                conn.OpenConnection();
                string query = "SELECT category_id, category_name FROM category_equipment";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn.kon);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching equipment categories: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }

            return dt;
        }
        public void InsertCategory(M_CategoryPeralatan category)
        {
            try
            {
                conn.OpenConnection();

                string query = "INSERT INTO category_equipment (category_id, category_name, created_at, updated_at) " +
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
                MessageBox.Show($"Error inserting equipment category: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        public void DeleteCategory(string categoryId)
        {
            try
            {
                conn.OpenConnection();
                string query = "DELETE FROM category_equipment WHERE category_id = @category_id";
                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@category_id", categoryId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting equipment category: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }

    }
}

