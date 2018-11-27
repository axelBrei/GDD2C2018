using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Security.Cryptography;

namespace PalcoNet.ConectionUtils
{
    class DatabaseConection
    {
        private static SqlConnection conection = null;

        public static void initDatabase(){
            var connectionString = ConfigurationManager.ConnectionStrings["TheBigBangQuery"].ConnectionString;
            conection = new SqlConnection(connectionString.ToString());
            conection.Open();
        }

        public static SqlConnection getInstance()
        {
            return conection;
        }

        public static void closeDatabase() {
            conection.Close();
        }

        public static SqlDataReader executeQuery(string query) {
            SqlCommand com = new SqlCommand(query, DatabaseConection.getInstance());
            com.CommandText = query;
            SqlDataReader result = com.ExecuteReader();
            return result;
        }

        public static SqlDataReader executeQuery(SqlCommand command) {
            command.Connection = DatabaseConection.getInstance();
            return command.ExecuteReader();
        }

    }
}
