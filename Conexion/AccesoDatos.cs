using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_5.Conexion
{
    public class AccesoDatos
    {
        /// PROPIEDADES
        string rutaBD = @"Data Source=localhost\sqlexpress; Initial Catalog=BDSucursales; Integrated Security=True";

        /// METODO CONSTRUCTOR
        public AccesoDatos()
        {
            /// CONSTRUCTOR POR DEFECTO
        }

        /// METODOS
        public SqlConnection ObtenerConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(rutaBD);
            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public SqlDataAdapter ObtenerAdaptador(string consultaSql)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}