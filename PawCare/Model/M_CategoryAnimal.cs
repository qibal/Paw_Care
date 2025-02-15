using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawCare.Model
{
    internal class M_CategoryAnimal
    {
        string category_id, category_name;
        DateTime created_at, updated_at;

        public M_CategoryAnimal() { }

        public M_CategoryAnimal(string category_id, string category_name, DateTime created_at, DateTime updated_at)
        {
            this.category_id = category_id;
            this.category_name = category_name;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }

        public string Category_id { get => category_id; set => category_id = value; }
        public string Category_name { get => category_name; set => category_name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
    }
}
