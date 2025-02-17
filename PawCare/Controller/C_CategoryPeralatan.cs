using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawCare.Model;
using MySql.Data.MySqlClient;


namespace PawCare.Controller
{
    internal class C_CategoryPeralatan
    {
        private Koneksi koneksi = new Koneksi();


        public List<M_CategoryPeralatan> GetAllCategories()
        {
            List<M_CategoryPeralatan> categories = new List<M_CategoryPeralatan>();
            koneksi.OpenConnection();
            string query = "SELECT * FROM category_equipment";
            MySqlDataReader reader = koneksi.Reader(query);
            while (reader.Read())
            {
                categories.Add(new M_CategoryPeralatan
                {
                    Category_id = reader["category_id"].ToString(),
                    Category_name = reader["category_name"].ToString(),
                    Created_at = Convert.ToDateTime(reader["created_at"]),
                    Updated_at = Convert.ToDateTime(reader["updated_at"])
                });
            }
            koneksi.CloseConnection();
            return categories;
        }

        public void AddCategory(M_CategoryPeralatan category)
        {
            koneksi.OpenConnection();
            string query = "INSERT INTO category_equipment (category_id, category_name, created_at, updated_at) VALUES (@CategoryId, @CategoryName, @CreatedAt, @UpdatedAt)";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@CategoryId", category.Category_id);
            cmd.Parameters.AddWithValue("@CategoryName", category.Category_name);
            cmd.Parameters.AddWithValue("@CreatedAt", category.Created_at);
            cmd.Parameters.AddWithValue("@UpdatedAt", category.Updated_at);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }

        public void UpdateCategory(M_CategoryPeralatan category)
        {
            koneksi.OpenConnection();
            string query = "UPDATE category_equipment SET category_name = @CategoryName, updated_at = @UpdatedAt WHERE category_id = @CategoryId";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@CategoryId", category.Category_id);
            cmd.Parameters.AddWithValue("@CategoryName", category.Category_name);
            cmd.Parameters.AddWithValue("@UpdatedAt", category.Updated_at);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }

        public void DeleteCategory(string categoryId)
        {
            koneksi.OpenConnection();
            string query = "DELETE FROM category_equipment WHERE category_id = @CategoryId";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }
    }
}

