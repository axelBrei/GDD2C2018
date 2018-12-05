using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;

namespace PalcoNet.Model
{
    public class Empresa : Registrable
    {
        public int id {get; set;}
        public string usuario { get; set; }
        public string razonSocial { get; set; }
        public string mailEmpresa { get; set; }
        public string telefonoEmpresa { get; set; }
        public string cuit { get; set; }
        public Direccion direccion { get; set; }
        public Nullable<DateTime> bajaLogica { get; set; }
        public Nullable<DateTime> creacion { get; set; }

        public int getId()
        {
            return id;
        }

        public string getNombre()
        {
            return razonSocial;
        }


        public string getTipo()
        {
            return UserData.UserData.TIPO_EMPRESA;
        }
    }
}
