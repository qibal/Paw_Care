using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawCare.Model
{
    public class M_Animal
    {
        string animal_id, animal_name, gender, image_path, category_id, category_name;
        int age;
        DateTime created_at, updated_at;

        public M_Animal() { }

        public M_Animal(string animal_id, string animal_name, string gender, int age, string image_path, string category_id, string category_name, DateTime created_at, DateTime updated_at)
        {
            this.animal_id = animal_id;
            this.animal_name = animal_name;
            this.gender = gender;
            this.age = age;
            this.image_path = image_path;
            this.category_id = category_id;
            this.category_name = category_name;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }

        public string Animal_id { get => animal_id; set => animal_id = value; }
        public string Animal_name { get => animal_name; set => animal_name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public string Category_id { get => category_id; set => category_id = value; }
        public string Category_name { get => category_name; set => category_name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
    }

}
