using System;
using System.Collections.Generic;
using System.Data;
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
                               "VALUES (@animal_id, @animal_name, @gender, @age, @image_path, @category_id, @created_at, @update_at)";

                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@animal_id", animal.Animal_id);
                cmd.Parameters.AddWithValue("@animal_name", animal.Animal_name);
                cmd.Parameters.AddWithValue("@gender", animal.Gender);
                cmd.Parameters.AddWithValue("@age", animal.Age);
                cmd.Parameters.AddWithValue("@image_path", animal.Image_path);
                cmd.Parameters.AddWithValue("@category_id", animal.Category_id);
                cmd.Parameters.AddWithValue("@created_at", animal.Created_at);
                cmd.Parameters.AddWithValue("@update_at", animal.Updated_at); // Ensure consistency with DB column

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

        public List<M_Animal> GetAnimals()
        {
            List<M_Animal> animals = new List<M_Animal>();

            try
            {
                conn.OpenConnection();
                // Include 'created_at' and 'update_at' in the SELECT statement and order by 'update_at' descending
                string query = "SELECT animal_id, animal_name, gender, age, image_path, category_id, created_at, update_at FROM animal ORDER BY update_at DESC";
                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    M_Animal animal = new M_Animal
                    {
                        Animal_id = reader["animal_id"].ToString(),
                        Animal_name = reader["animal_name"].ToString(),
                        Gender = reader["gender"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        Image_path = reader["image_path"].ToString(),
                        Category_id = reader["category_id"].ToString(),
                        Created_at = Convert.ToDateTime(reader["created_at"]),
                        Updated_at = Convert.ToDateTime(reader["update_at"]) // Ensure consistency with DB column
                    };
                    animals.Add(animal);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving animals: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }

            return animals;
        }

        public M_Animal GetAnimalById(string animalId)
        {
            M_Animal animal = null;

            try
            {
                conn.OpenConnection();
                string query = "SELECT animal_id, animal_name, gender, age, image_path, category_id, created_at, update_at FROM animal WHERE animal_id = @animal_id";
                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@animal_id", animalId);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    animal = new M_Animal
                    {
                        Animal_id = reader["animal_id"].ToString(),
                        Animal_name = reader["animal_name"].ToString(),
                        Gender = reader["gender"].ToString(),
                        Age = Convert.ToInt32(reader["age"]),
                        Image_path = reader["image_path"].ToString(),
                        Category_id = reader["category_id"].ToString(),
                        Created_at = Convert.ToDateTime(reader["created_at"]),
                        Updated_at = Convert.ToDateTime(reader["update_at"]) // Ensure consistency with DB column
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving animal: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }

            return animal;
        }

        public void UpdateAnimal(M_Animal animal)
        {
            try
            {
                conn.OpenConnection();

                string query = "UPDATE animal SET animal_name=@animal_name, gender=@gender, age=@age, image_path=@image_path, category_id=@category_id, update_at=@update_at WHERE animal_id=@animal_id";

                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@animal_id", animal.Animal_id);
                cmd.Parameters.AddWithValue("@animal_name", animal.Animal_name);
                cmd.Parameters.AddWithValue("@gender", animal.Gender);
                cmd.Parameters.AddWithValue("@age", animal.Age);
                cmd.Parameters.AddWithValue("@image_path", animal.Image_path);
                cmd.Parameters.AddWithValue("@category_id", animal.Category_id);
                // Removed created_at as it should not change on update
                cmd.Parameters.AddWithValue("@update_at", animal.Updated_at); // Ensure consistency with DB column

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating animal: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }
        // Add this method in C_Animal.cs
        public void DeleteAnimal(string animalId)
        {
            try
            {
                conn.OpenConnection();
                string query = "DELETE FROM animal WHERE animal_id = @animal_id";
                MySqlCommand cmd = new MySqlCommand(query, conn.kon);
                cmd.Parameters.AddWithValue("@animal_id", animalId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting animal: {ex.Message}");
            }
            finally
            {
                conn.CloseConnection();
            }
        }


    }
}
