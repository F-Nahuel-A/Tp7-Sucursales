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
    public class GestionSucursal
    {
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

        public void FiltrarLV(ListView listView, String nombreSucursal)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter = accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal]" + "WHERE [NombreSucursal]" + "LIKE '" + nombreSucursal + "%'");
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Sucursal");
            listView.DataSource = dataSet.Tables["Sucursal"];
            listView.DataBind();
        }

        public void FiltrarPorProvinciaLV(ListView listView, string provincia)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter = accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] WHERE Id_ProvinciaSucursal = " + provincia + "");
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Sucursal");
            listView.DataSource = dataSet.Tables["Sucursal"];
            listView.DataBind();
        }

        public DataTable CrearTabla()
        {
            DataTable dataTable = new DataTable();

            DataColumn dataColumn = new DataColumn("ID_SUCURSAL", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NOMBRE", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("DESCRIPCION", System.Type.GetType("System.String"));
            dataTable.Columns.Add(dataColumn);

            return dataTable;
        }

        public DataTable agregarFila(DataTable dataTable, string idSucursal, string nombreSucursal, string descripcionSucursal)
        {
            if (!ValidacionSeleccionado(dataTable, idSucursal))
            {
                DataRow dataRow = dataTable.NewRow();

                dataRow["ID_SUCURSAL"] = idSucursal;
                dataRow["NOMBRE"] = nombreSucursal;
                dataRow["DESCRIPCION"] = descripcionSucursal;
                dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }

        private bool ValidacionSeleccionado(DataTable dataTable, string idSucursal)
        {
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (row["ID_SUCURSAL"].ToString() == idSucursal)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}