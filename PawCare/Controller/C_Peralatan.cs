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
    internal class C_Peralatan
    {
        private Koneksi koneksi = new Koneksi();

        public List<M_Peralatan> GetAllEquipment()
        {
            List<M_Peralatan> equipmentList = new List<M_Peralatan>();
            koneksi.OpenConnection();
            string query = @"
            SELECT e.*, c.category_name 
            FROM equipment e
            JOIN category_equipment c ON e.category_id = c.category_id";
            MySqlDataReader reader = koneksi.Reader(query);
            while (reader.Read())
            {
                equipmentList.Add(new M_Peralatan
                {
                    Equipment_id = reader["equipment_id"].ToString(),
                    Equipment_name = reader["equipment_name"].ToString(),
                    Amount = Convert.ToInt32(reader["amount"]),
                    Image_path = reader["image_path"].ToString(),
                    Category_id = reader["category_id"].ToString(),
                    Category_name = reader["category_name"].ToString(),
                    Created_at = Convert.ToDateTime(reader["created_at"]),
                    Updated_at = Convert.ToDateTime(reader["updated_at"])
                });
            }
            koneksi.CloseConnection();
            return equipmentList;
        }

        public void InsertEquipment(M_Peralatan equipment)
        {
            try
            {
                koneksi.OpenConnection();

                string query = "INSERT INTO equipment (equipment_id, equipment_name, amount, image_path, category_id, created_at, updated_at) " +
                               "VALUES (@equipment_id, @equipment_name, @amount, @image_path, @category_id, @created_at, @updated_at)";

                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@equipment_id", equipment.Equipment_id);
                cmd.Parameters.AddWithValue("@equipment_name", equipment.Equipment_name);
                cmd.Parameters.AddWithValue("@amount", equipment.Amount);
                cmd.Parameters.AddWithValue("@image_path", equipment.Image_path);
                cmd.Parameters.AddWithValue("@category_id", equipment.Category_id);
                cmd.Parameters.AddWithValue("@created_at", equipment.Created_at);
                cmd.Parameters.AddWithValue("@updated_at", equipment.Updated_at);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public void UpdateEquipment(M_Peralatan equipment)
        {
            try
            {
                koneksi.OpenConnection();

                string query = "UPDATE equipment SET equipment_name=@equipment_name, amount=@amount, image_path=@image_path, category_id=@category_id, updated_at=@updated_at WHERE equipment_id=@equipment_id";

                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@equipment_id", equipment.Equipment_id);
                cmd.Parameters.AddWithValue("@equipment_name", equipment.Equipment_name);
                cmd.Parameters.AddWithValue("@amount", equipment.Amount);
                cmd.Parameters.AddWithValue("@image_path", equipment.Image_path);
                cmd.Parameters.AddWithValue("@category_id", equipment.Category_id);
                cmd.Parameters.AddWithValue("@updated_at", equipment.Updated_at);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating equipment: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public void DeleteEquipment(string equipmentId)
        {
            try
            {
                koneksi.OpenConnection();
                string query = "DELETE FROM equipment WHERE equipment_id = @equipment_id";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting equipment: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }
        }

        public M_Peralatan GetEquipmentById(string equipmentId)
        {
            M_Peralatan equipment = null;

            try
            {
                koneksi.OpenConnection();
                string query = "SELECT equipment_id, equipment_name, amount, image_path, category_id, created_at, updated_at FROM equipment WHERE equipment_id = @equipment_id";
                MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
                cmd.Parameters.AddWithValue("@equipment_id", equipmentId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    equipment = new M_Peralatan
                    {
                        Equipment_id = reader["equipment_id"].ToString(),
                        Equipment_name = reader["equipment_name"].ToString(),
                        Amount = Convert.ToInt32(reader["amount"]),
                        Image_path = reader["image_path"].ToString(),
                        Category_id = reader["category_id"].ToString(),
                        Created_at = Convert.ToDateTime(reader["created_at"]),
                        Updated_at = Convert.ToDateTime(reader["updated_at"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving equipment: {ex.Message}");
            }
            finally
            {
                koneksi.CloseConnection();
            }

            return equipment;
        }
    }
}
