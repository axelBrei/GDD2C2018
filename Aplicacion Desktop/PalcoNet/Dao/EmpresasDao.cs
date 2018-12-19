using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using PalcoNet.Exceptions;
using PalcoNet.Constants;

namespace PalcoNet.Dao
{
    class EmpresasDao
    {
        string mainEmpresaQuery = "SELECT empr_id, empr_cuit, empr_razon_social, empr_mail, empr_telefono, " +
                                  "empr_direccion, empr_numero_calle, empr_piso, empr_dpto, empr_localidad, empr_codigo_postal, " + 
                                  "empr_ciudad, empr_dado_baja, empr_creacion, usua_usuario " +
                                  "FROM TheBigBangQuery.Empresa LEFT JOIN TheBigBangQuery.Usuario ON (empr_usuario = usua_id) ";
        string ordenarPorIdAsc = " ORDER BY empr_id ASC";

        public List<Empresa> getEmpresas() { 
            List<Empresa> empresas = new List<Empresa>();
            SqlDataReader reader = DatabaseConection.executeQuery(mainEmpresaQuery + ordenarPorIdAsc);
            if (reader.HasRows) {
                while (reader.Read()) {
                    empresas.Add(getEmpresaFromReader(reader));
                }
            }
            reader.Close();
            return empresas;
        }

        private Empresa getEmpresaFromReader(SqlDataReader reader) {
            Empresa empresa = new Empresa();

            empresa.id = (int)(reader.IsDBNull(0) ? -1 : reader.GetSqlDecimal(0));
            empresa.cuit = (string)(reader.IsDBNull(1) ? null : reader.GetSqlString(1).ToString());
            empresa.razonSocial = (string)(reader.IsDBNull(2) ? null : reader.GetSqlString(2).ToString());
            empresa.mailEmpresa = (string)(reader.IsDBNull(3) ? null : reader.GetSqlString(3).ToString());
            empresa.telefonoEmpresa = (reader.IsDBNull(4) ? null : reader.GetSqlString(4).ToString());
            Direccion dir = new Direccion();
            dir.calle = (reader.IsDBNull(5) ? null : reader.GetSqlString(5).ToString());
            dir.numero = (reader.IsDBNull(6) ? null : reader.GetSqlDecimal(6).ToString());
            dir.piso = (reader.IsDBNull(7) ? null : reader.GetSqlDecimal(7).ToString());
            dir.depto = (reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString());
            dir.localidad = (reader.IsDBNull(9) ? null : reader.GetSqlString(9).ToString());
            dir.codigoPostal = (reader.IsDBNull(10) ? null : reader.GetSqlString(10).ToString());
            dir.ciudad = (reader.IsDBNull(11) ? null : reader.GetSqlString(11).ToString());
            empresa.direccion = dir;

            empresa.bajaLogica = (reader.IsDBNull(12) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(12));
            empresa.creacion = (reader.IsDBNull(13) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(13));
            empresa.usuario = (reader.IsDBNull(14) ? null : reader.GetSqlString(14).ToString());

            return empresa;
        }

        public void insertarEmpresaConUsuario(Empresa empresa, String usuario , String contraseña) {
            string query = "EXEC [TheBigBangQuery].[InsertarEmpresaConUsuario]" +
                "@usuario = '" + usuario + "'," +
                "@contraseña = '" + contraseña + "'," +
                "@razonSocial = '" + empresa.razonSocial + "'," +
                "@cuit = '" + empresa.cuit + "'," +
                "@mail = '" + empresa.mailEmpresa + "'," +
                "@telefono = '" + empresa.telefonoEmpresa + "'," +
                "@calle = '" + empresa.direccion.calle + "'," +
                "@altura = '" + empresa.direccion.numero + "'," +
                "@piso = '" + empresa.direccion.piso + "'," +
                "@depto = '" + empresa.direccion.depto + "'," +
                "@localidad = '" + empresa.direccion.localidad + "'," +
                "@codigoPostal = '" + empresa.direccion.codigoPostal + "'," +
                "@ciudad = '" + empresa.direccion.ciudad + "'," +
                "@fechaCreacion = '" + Generals.getFecha() + "'";
            try
            {
                DatabaseConection.executeNoParamFunction(query);
            }
            catch (SqlException e) { 
                throw e; 
            }
        }

        public void actualizarEmpresa(Empresa empresa) {
            string query = "EXEC [TheBigBangQuery].[ActualizarEmpresa] " +
                "@id = '"+ empresa.id +"'," +
                "@cuit = '"+ empresa.cuit +"'," +
                "@razonSocial = '" + empresa.razonSocial + "'," +
                "@mail = '" + empresa.mailEmpresa + "'," +
                "@telefono = '" + empresa.telefonoEmpresa + "'," +
                "@direccion = '" + empresa.direccion.calle + "'," +
                "@altura = '" + empresa.direccion.numero + "'," +
                "@piso = '" + empresa.direccion.piso + "'," +
                "@depto = '" +  empresa.direccion.depto + "'," +
                "@localidad = '" + empresa.direccion.localidad + "'," +
                "@codigoPostal = '" + empresa.direccion.codigoPostal + "'," +
                "@ciudad = '" + empresa.direccion.ciudad + "'";

            try
            {
                DatabaseConection.executeNoParamFunction(query);
            }
            catch (SqlException e) {
                throw e;
            }
        }

        public List<Empresa> getEmpresasMayoresAId(int id) {
            List<Empresa> empresas = new List<Empresa>();
            string query = mainEmpresaQuery + "WHERE empr_id > @id" + ordenarPorIdAsc;
            SqlCommand command = new SqlCommand(query);
            SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Decimal);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = DatabaseConection.executeQuery(command);
            if(reader.HasRows){
                while (reader.Read()) { 
                       empresas.Add(getEmpresaFromReader(reader));
                }
            }else{
                reader.Close();
                throw new DataNotFoundException("No se han encontrado empresas mayores al id " + id);
            }
            reader.Close();
            return empresas;
        }

        public void habilitarODesahabilitarEmpresa(Empresa empresa) {
            string query = "UPDATE TheBigBangQuery.Empresa " +
                            "SET empr_dado_baja = " + 
                                (empresa.bajaLogica != null ? "'"+Generals.getFecha().ToString("yyyy-dd-MM")+"'" : "NULL" )  +
                            " WHERE empr_id = 1";
            try
            {
                DatabaseConection.executeNoParamFunction(query);
            }
            catch (SqlException ex) {
                throw ex;
            }
        }

        public Empresa getEmpresaPorId(int id, SqlTransaction trans = null) {
            Empresa empresa = new Empresa();
            string query = mainEmpresaQuery + "WHERE empr_id = @id";
            SqlCommand command = new SqlCommand(query);
            if (trans != null)
                command.Transaction = trans;
            SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Decimal);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = DatabaseConection.executeQuery(command);
            if (reader.HasRows)
            {
                reader.Read();
                empresa = getEmpresaFromReader(reader);
            }
            else {
                reader.Close();
                throw new DataNotFoundException("No se ha podido encontrar una empresa con dicho id");
            }
            reader.Close();
            return empresa;
        }

        public Empresa getEmpresaPorUserId(int userId) {
            string query = mainEmpresaQuery + " WHERE empr_usuario = @id";
            SqlCommand command = new SqlCommand(query);
            SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Int);
            param.Value = userId;
            command.Parameters.Add(param);
            Empresa empre = null;
            SqlDataReader reader = null;
            try
            {
                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows)
                {
                    reader.Read();
                    empre = getEmpresaFromReader(reader);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally {
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
            return empre;
        }
    }
}
