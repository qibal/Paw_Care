using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawCare.Model
{
    internal class M_Peralatan
    {
        string equipment_id, equipment_name, image_path, category_id;
        int amount;
        DateTime created_at, updated_at;

        public M_Peralatan() { }

        public M_Peralatan(string equipment_id, string equipment_name, int amount, string image_path, string category_id, DateTime created_at, DateTime updated_at)
        {
            this.equipment_id = equipment_id;
            this.equipment_name = equipment_name;
            this.amount = amount;
            this.image_path = image_path;
            this.category_id = category_id;
            this.created_at = created_at;
            this.updated_at = updated_at;
        }

        public string Equipment_id { get => equipment_id; set => equipment_id = value; }
        public string Equipment_name { get => equipment_name; set => equipment_name = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Image_path { get => image_path; set => image_path = value; }
        public string Category_id { get => category_id; set => category_id = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
    }
}







