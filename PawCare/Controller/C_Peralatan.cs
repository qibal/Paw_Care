using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PawCare.Model;

using MySql.Data.MySqlClient;


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


        public void AddEquipment(M_Peralatan equipment)
        {
            koneksi.OpenConnection();
            string query = "INSERT INTO equipment (equipment_id, equipment_name, amount, image_path, category_id, created_at, updated_at) VALUES (@EquipmentId, @EquipmentName, @Amount, @ImagePath, @CategoryId, @CreatedAt, @UpdatedAt)";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@EquipmentId", equipment.Equipment_id);
            cmd.Parameters.AddWithValue("@EquipmentName", equipment.Equipment_name);
            cmd.Parameters.AddWithValue("@Amount", equipment.Amount);
            cmd.Parameters.AddWithValue("@ImagePath", equipment.Image_path);
            cmd.Parameters.AddWithValue("@CategoryId", equipment.Category_id);
            cmd.Parameters.AddWithValue("@CreatedAt", equipment.Created_at);
            cmd.Parameters.AddWithValue("@UpdatedAt", equipment.Updated_at);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }

        public void UpdateEquipment(M_Peralatan equipment)
        {
            koneksi.OpenConnection();
            string query = "UPDATE equipment SET equipment_name = @EquipmentName, amount = @Amount, image_path = @ImagePath, category_id = @CategoryId, updated_at = @UpdatedAt WHERE equipment_id = @EquipmentId";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@EquipmentId", equipment.Equipment_id);
            cmd.Parameters.AddWithValue("@EquipmentName", equipment.Equipment_name);
            cmd.Parameters.AddWithValue("@Amount", equipment.Amount);
            cmd.Parameters.AddWithValue("@ImagePath", equipment.Image_path);
            cmd.Parameters.AddWithValue("@CategoryId", equipment.Category_id);
            cmd.Parameters.AddWithValue("@UpdatedAt", equipment.Updated_at);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }

        public void DeleteEquipment(string equipmentId)
        {
            koneksi.OpenConnection();
            string query = "DELETE FROM equipment WHERE equipment_id = @EquipmentId";
            MySqlCommand cmd = new MySqlCommand(query, koneksi.kon);
            cmd.Parameters.AddWithValue("@EquipmentId", equipmentId);
            cmd.ExecuteNonQuery();
            koneksi.CloseConnection();
        }
    }
}

