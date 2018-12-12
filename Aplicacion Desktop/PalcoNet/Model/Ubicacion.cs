using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PalcoNet.Exceptions;

namespace PalcoNet.Model
{
    public class Ubicacion
    {
        public int id { get; set; }
        public string fila { get; set; }
        public int asiento { get; set; }
        public int sinEnumerar { get; set; }
        public int precio { get; set; }
        public TipoUbicacion tipoUbicaciones { get; set; }

        public override string ToString()
        {
            return tipoUbicaciones.descripcion + " fila: " + fila + " / asiento: " + asiento;
        }

        public Ubicacion() { }

        public Ubicacion(SqlDataReader reader) {

            try
            {
                if (reader.HasRows & reader.FieldCount == 7)
                {
                    this.id = (int)(reader.IsDBNull(0) ? null : (Nullable<int>)reader.GetSqlDecimal(0));
                    this.fila = (reader.IsDBNull(1) ? null : reader.GetSqlString(1).ToString());
                    this.asiento = (int)(reader.IsDBNull(2) ? null : (Nullable<int>)reader.GetSqlDecimal(2));
                    this.sinEnumerar = (int)(reader.IsDBNull(3) ? null : (Nullable<int>)( ( (bool) reader.GetValue(3)) ? 1 : 0 ));
                    TipoUbicacion tipo = new TipoUbicacion();
                    tipo.id = (int)(reader.IsDBNull(4) ? null : (Nullable<int>)reader.GetSqlDecimal(4));
                    tipo.descripcion = (reader.IsDBNull(5) ? null : reader.GetSqlString(5).ToString());
                    this.precio = (int)(reader.IsDBNull(6) ? null : (Nullable<int>)reader.GetSqlDecimal(6));
                    this.tipoUbicaciones = tipo;
                }
            }
            catch (Exception e) {
                throw new ObjectParseException("Error al parsear ubicacion");
            }
        }

        public override bool Equals(object obj)
        {
            var ubic = obj as Ubicacion;
            if (ubic != null)
                return this.fila.ToUpper().Equals(ubic.fila.ToUpper()) & this.asiento.Equals(ubic.asiento);
            else
                return false;
        }
    }
}
