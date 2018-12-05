using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;

namespace PalcoNet.Model
{
    public class Cliente : Registrable
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string documento { get; set; }
        public string cuil { get; set; }
        public string mail { get; set; }
        public string telefono { get; set; }
        public Direccion direccion { get; set; }
        public Nullable<DateTime> fechaNacimiento { get; set; }
        public Nullable<DateTime> fechaCreacion { get; set; }
        public string numeroTarjeta { get; set; }
        public string usuario { get; set; }
        public Nullable<DateTime> bajaLogica { get; set; }
        public Nullable<int> puntos;
        public Nullable<DateTime> vencimientoPuntos { get; set; }


        public int getId()
        {
            return id;
        }

        public string getNombre()
        {
            return nombre + " " + apellido;
        }


        public string getTipo()
        {
            return UserData.UserData.TIPO_CLIENTE;
        }
    }
}
