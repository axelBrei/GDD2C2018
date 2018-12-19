using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalcoNet.Model;
using PalcoNet.ConectionUtils;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using PalcoNet.Exceptions;

namespace PalcoNet.Dao
{
    class ClientesDao
    {

        private string getClientsQuery = "SELECT clie_id, clie_dni, usua_usuario, clie_nombre, clie_apellido, tipo_descripcion, clie_cuil, clie_mail, " +
                                            "clie_telefono, clie_direccion, clie_numero_calle, clie_piso, clie_locacalidad,clie_codigo_postal,clie_f_nacimiento, " +
                                            "clie_f_creacion, clie_dado_baja, clie_puntos, clie_departamento, clie_prox_vencimiento_puntos " +
                                        "FROM [TheBigBangQuery].[Cliente] LEFT JOIN [TheBigBangQuery].[Tipo_Documento] ON (clie_tipo_documento = tipo_id)" +
                                            "LEFT JOIN [TheBigBangQuery].[Usuario] ON (clie_usuario = usua_id)";

        public List<Cliente> getClientes() {
            SqlDataReader reader = null;
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                reader = DatabaseConection.executeQuery(getClientsQuery +
                " ORDER BY clie_id ASC");
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        clientes.Add(getClienteFromReder(reader));

                    }

                }
                return clientes;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public void getClientesHabilitados(Action<List<Cliente>>lambda) {
            string query = getClientsQuery + " WHERE clie_dado_baja IS NULL";
            SqlDataReader reader = null;
            List<Cliente> clientesHabilitados = new List<Cliente>();
            try {
                reader = DatabaseConection.executeQuery(query);
                if (reader.HasRows) {
                    while (reader.Read()) { 
                        clientesHabilitados.Add(getClienteFromReder(reader));
                    }
                }
                lambda(clientesHabilitados);
            }
            catch(Exception e){
                throw new DataNotFoundException("Error al buscar clientes habilitados");
            }
            finally{
                if (reader != null & !reader.IsClosed)
                    reader.Close();
            }
        }

        public void insertarCliente(Cliente cliente, string contraseña) {
            string query = "[TheBigBangQuery].[InsertarNuevoClienteConUsuario]";
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.CommandText = query;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@usuario", cliente.usuario.Trim());
                command.Parameters.AddWithValue("@contraseña", contraseña.Trim());
                command.Parameters.AddWithValue("@nombre", cliente.nombre.Trim());
                command.Parameters.AddWithValue("@apellido", cliente.apellido);
                command.Parameters.AddWithValue("@tipoDoc", cliente.TipoDocumento.Trim());
                command.Parameters.AddWithValue("@documento", cliente.documento.Trim());
                command.Parameters.AddWithValue("@cuil", cliente.cuil.Trim());
                command.Parameters.AddWithValue("@mail", cliente.mail.Trim());
                command.Parameters.AddWithValue("@telefono", cliente.telefono.Trim());
                command.Parameters.AddWithValue("@calle", cliente.direccion.calle.Trim());
                command.Parameters.AddWithValue("@altura", cliente.direccion.numero.Trim());
                command.Parameters.AddWithValue("@piso", cliente.direccion.piso.Trim());
                command.Parameters.AddWithValue("@depto", cliente.direccion.depto.Trim());
                command.Parameters.AddWithValue("@localidad", cliente.direccion.localidad.Trim());
                command.Parameters.AddWithValue("@codigoPostal", cliente.direccion.codigoPostal.Trim());
                command.Parameters.AddWithValue("@fechaNacimiento", ((DateTime)cliente.fechaNacimiento));
                command.Parameters.AddWithValue("@fechaCreacion", ((DateTime)cliente.fechaCreacion));

                DatabaseConection.executeNoParamFunction(command);
            }
            catch (SqlException e) { 
                if(e.Message.Contains("dni")){
                    throw new SqlInsertException("Ya existe un usuario con el dni ingresado",0);
                }else{
                    throw new SqlInsertException("Ya existe un usuario con el cuir ingresado",0);
                }
            }
            catch (Exception e)
            {
                throw new SqlInsertException("No se ha podido procesar el alta del cliente", 0);
            }
        }

        public List<Cliente> getClientesMayoresAId(int id) {
            List<Cliente> clientes = new List<Cliente>();
            SqlCommand command = new SqlCommand(getClientsQuery + "WHERE clie_id > @clieId ORDER BY clie_id DESC");
            command.Parameters.AddWithValue("@clieId", id);
            SqlDataReader reader = DatabaseConection.executeQuery(command);
            if (reader.HasRows) {
                while (reader.Read()) {
                    clientes.Add(getClienteFromReder(reader));
                }
            }
            reader.Close();
            if (clientes.Count == 0) {
                return null;
            }
            return clientes;
        }

        public int getPuntosDelCliente(int clieId) {
            string query = "SELECT clie_puntos FROM TheBigBangQuery.Cliente WHERE clie_id = @clieId";
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand(query);
                command.Parameters.AddWithValue("@clieId", clieId);

                reader = DatabaseConection.executeQuery(command);
                int ret = 0;
                if (reader.HasRows) {
                    reader.Read();
                    ret = (int) reader.GetSqlDecimal(0);
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw new DataNotFoundException("No se han encontrado puntos registrados para el cliente");
            }
            finally {
                if (reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }

        public Cliente getClientePorId(int id) {
            Cliente cliente = new Cliente();
            SqlCommand command = new SqlCommand(getClientsQuery + "WHERE clie_id = " + id);
            SqlParameter param = new SqlParameter("@clieId", System.Data.SqlDbType.Decimal);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = DatabaseConection.executeQuery(command);
            if (!reader.HasRows) return null;
            reader.Read();
            cliente = getClienteFromReder(reader);
            reader.Close();
            return cliente;
        }

        public void actualizarCliente(Cliente cliente) {
            string query = "EXEC [TheBigBangQuery].[ActualizarCliente] " +
                "@id = '" + cliente.id.ToString().Trim() + "', " +
                "@nombre = '" + cliente.nombre.Trim() + "', " +
                "@apellido = '" + cliente.apellido.Trim() + "'," +
                "@tipoDocumento = '" + cliente.TipoDocumento.Trim() + "', " +
                "@numeroDocumento = '" + cliente.documento.Trim() + "', " +
                "@cuil = '" + cliente.cuil.Trim() + "', " +
                "@mail = '" + cliente.mail.Trim() + "', " +
                "@telefono = '" + cliente.telefono.Trim() + "'," +
                "@calle = '" + cliente.direccion.calle.Trim() + "', " +
                "@altura = '" + cliente.direccion.numero.Trim() + "'," +
                "@piso = '" + cliente.direccion.piso.Trim() + "'," +
                "@depto = '" + cliente.direccion.depto.Trim() + "'," +
                "@localidad = '" + cliente.direccion.localidad.Trim() + "'," +
                "@codigoPostal = '" + cliente.direccion.codigoPostal.Trim() + "'," +
                "@fechaDeNacimiento = '" + ((DateTime)cliente.fechaNacimiento).ToString("yyyy-dd-MM").Trim() + "'," +
                "@fechaCreacion = '" + ((DateTime)cliente.fechaCreacion).ToString("yyyy-dd-MM").Trim() + "'";
            try
            {
                DatabaseConection.executeNoParamFunction(query);
            }
            catch (SqlException ex)
            {
                MessageBoxButtons alert = MessageBoxButtons.OK;
                MessageBox.Show(ex.Message, "ERROR", alert);
            }

        }
        


        private Cliente getClienteFromReder(SqlDataReader reader) {
            Cliente cliente = new Cliente();

            cliente.id = (int)(reader.IsDBNull(0) ? -1 : reader.GetSqlDecimal(0));
            cliente.documento = (string)(reader.IsDBNull(1) ? null : reader.GetSqlDecimal(1).ToString());
            cliente.usuario = (string)(reader.IsDBNull(2) ? null : reader.GetSqlString(2).ToString());
            cliente.nombre = (string)(reader.IsDBNull(3) ? null : reader.GetSqlString(3).ToString());
            cliente.apellido = (string)(reader.IsDBNull(4) ? null : reader.GetSqlString(4).ToString());
            cliente.TipoDocumento = (string)(reader.IsDBNull(5) ? null : reader.GetSqlString(5).ToString());
            cliente.cuil = (string)(reader.IsDBNull(6) ? null : reader.GetSqlString(6).ToString());
            cliente.mail = (string)(reader.IsDBNull(7) ? null : reader.GetSqlString(7).ToString());
            cliente.telefono = (string)(reader.IsDBNull(8) ? null : reader.GetSqlString(8).ToString());

            Direccion dir = new Direccion();
            dir.calle = (string)(reader.IsDBNull(9) ? null : reader.GetSqlString(9).ToString());
            dir.numero = (reader.IsDBNull(10) ? null : reader.GetSqlDecimal(10).ToString());
            dir.piso = (reader.IsDBNull(11) ? null : reader.GetSqlDecimal(11).ToString());
            dir.localidad = (string)(reader.IsDBNull(12) ? null : reader.GetSqlString(12).ToString());
            dir.codigoPostal = (string)(reader.IsDBNull(13) ? null : reader.GetSqlString(13).ToString());


            cliente.fechaNacimiento = (reader.IsDBNull(14) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(14));
            cliente.fechaCreacion = (reader.IsDBNull(15) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(15));
            cliente.bajaLogica = (reader.IsDBNull(16) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(16));
            if (reader.IsDBNull(18))
                cliente.puntos = null;
            else
                cliente.puntos = (int)reader.GetSqlDecimal(17);
            dir.depto = (string)(reader.IsDBNull(18) ? null : reader.GetSqlString(18).ToString());

            cliente.direccion = dir;

            cliente.vencimientoPuntos = (Nullable<DateTime>)(reader.IsDBNull(19) ? null : (Nullable<DateTime>)reader.GetSqlDateTime(19));
            return cliente;

        }

        public void habilitarODesabilitarCliente(Cliente cliente) {
            string query = "UPDATE [TheBigBangQuery].[Cliente] " +
                "SET clie_dado_baja = " + ( cliente.bajaLogica != null ? "NULL" : "GETDATE()" ) +
                " WHERE clie_id = '" + cliente.id + "'" ;

            SqlCommand command = new SqlCommand(query);
            DatabaseConection.executeNoParamFunction(command);
        }

        public Cliente getClientePorUserId(int id) {
            string query = getClientsQuery + " WHERE clie_usuario = @id";
            SqlCommand command = new SqlCommand(query);
            SqlParameter param = new SqlParameter("@id", System.Data.SqlDbType.Int);
            param.Value = id;
            command.Parameters.Add(param);
            SqlDataReader reader = null;
            Cliente cliente = null;
            try
            {
                reader = DatabaseConection.executeQuery(command);
                if (reader.HasRows) {
                    reader.Read();
                    cliente = getClienteFromReder(reader);
                }
            }
            catch (Exception e) {
                throw e;
            }
            finally{
                if(reader != null & !reader.IsClosed){
                    reader.Close();
                }
            }

            return cliente;
        }
    }

    
}
