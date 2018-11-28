using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;


namespace PalcoNet.Dao
{
    class ClientesDao
    {

        public void insertarCliente(Cliente cliente, string contraseña) {
            string query = "EXEC [TheBigBangQuery].[InsertarNuevoClienteConUsuario] " + 
                "@usuario = '"+ cliente.usuario +"',"+
                "@contraseña = '" + contraseña + "'," +
                " @nombre= '" + cliente.nombre + "', " +
                " @apellido= '" + cliente.apellido + "', " +
                "@tipoDoc= '" + cliente.TipoDocumento + "', " +
                "@documento= '" + cliente.documento + "', " +
                " @cuil= '" + cliente.cuil + "', " +
                " @mail = '" + cliente.mail + "', " +
                "@telefono = '" + cliente.telefono + "'," +
                "@calle = '" + cliente.direccion.calle + "', " +
                "@altura = '" + cliente.direccion.numero + "', " +
                "@piso = '" + cliente.direccion.piso + "', " +
                "@depto= '" + cliente.direccion.depto + "', " +
                "@localidad= '" + cliente.direccion.localidad + "', " +
                "@codigoPostal= '" + cliente.direccion.codigoPostal + "', " +
                "@fechaNacimiento = '" + cliente.fechaNacimiento.ToString("yyyy-MM-dd HH:mm:ss") + "'," +
                "@fechaCreacion = '" + cliente.fechaCreacion.ToString("yyyy-MM-dd HH:mm:ss") + "', " +
                "@numeroTarjeta= '" + cliente.numeroTarjeta + "'";

            DatabaseConection.executeQuery(query);
        }

    }
}
