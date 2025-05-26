using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_5.Conexion
{
	public class GestiónSucursal
	{

		public GestiónSucursal() 
		{
		
		}

        public void CargarLV(ListView listView)
        {
            string constr = ConfigurationManager.ConnectionStrings["BDSucursalesConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal]", con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    listView.DataSource = dt;
                    listView.DataBind();
                }
            }
        }

        public void FiltrarLV(ListView listView,TextBox textBox)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter = accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] WHERE [NombreSucursal] LIKE '" + textBox.Text + "%'");
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Sucursal");
            listView.DataSource = dataSet.Tables["Sucursal"];
            listView.DataBind();
        }

        public void FiltrarPorProvinciaLV(ListView listView,string provincia)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter = accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] WHERE Id_ProvinciaSucursal = " + provincia + "");
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Sucursal");
            listView.DataSource = dataSet.Tables["Sucursal"];
            listView.DataBind();
        }
    }
}