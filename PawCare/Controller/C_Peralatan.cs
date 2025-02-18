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
    }
}

