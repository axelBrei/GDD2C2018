using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;

namespace PalcoNet.Model
{
    public class Administrador : Registrable
    {
        public int getId()
        {
            return -1;
        }

        public string getNombre()
        {
            return "";
        }

        public string getTipo()
        {
            return UserData.UserData.TIPO_ADMIN;
        }
    }
}
