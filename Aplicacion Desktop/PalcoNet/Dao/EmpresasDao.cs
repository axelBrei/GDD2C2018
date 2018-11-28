using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;

namespace PalcoNet.Dao
{
    class EmpresasDao
    {

        public void insertarEmpresaConUsuario(Empresa empresa, String usuario , String contraseña) { 
            string query = "EXEC [TheBigBangQuery].[InsertarEmpresaConUsuario]" +
	            "@usuario = '" + usuario +"'," +
	            "@contraseña = '" + contraseña +"'," +
	            "@razonSocial = '" + empresa.razonSocial +"'," +
	            "@cuit = '" + empresa.cuit +"'," +
	            "@mail = '" + empresa.mailEmpresa +"'," +
	            "@telefono = '" + empresa.telefonoEmpresa+"'," +
	            "@calle = '" + empresa.direccion.calle +"'," +
	            "@altura = '" + empresa.direccion.numero +"'," +
	            "@piso = '" + empresa.direccion.piso +"'," +
	            "@depto = '" + empresa.direccion.depto +"'," +
	            "@localidad = '" + empresa.direccion.localidad +"'," +
	            "@codigoPostal = '" + empresa.direccion.codigoPostal +"'," +
	            "@ciudad = '" + empresa.direccion.ciudad +"'," +
                "@fechaCreacion = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";

            DatabaseConection.executeQuery(query).Close();
        }
    }
}
