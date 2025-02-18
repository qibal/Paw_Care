using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawCare.Model;

namespace PawCare.Controller
{
    internal class C_home
    {
        private M_home model;

        public C_home()
        {
            model = new M_home();
        }

        public int GetTotalAnimals()
        {
            return model.GetTotalAnimals();
        }
    }
}
