using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawCare.Model;

namespace PawCare.Controller
{
    internal class C_login
    {
        private M_login model;

        public C_login()
        {
            model = new M_login();
        }

        public bool CheckPin(string pin)
        {
            return model.CheckPin(pin);
        }
    }
}
