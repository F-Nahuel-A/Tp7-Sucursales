using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace TP7_GRUPO_5
{
	public partial class SeleccionarSucursales : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            TxtBusqueda.Text.Trim();
            Sucursal.SelectCommand = "SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] WHERE [NombreSucursal] LIKE '" + TxtBusqueda.Text + "%'";
            /*
            AccesoDatos accesoDatos = new AccesoDatos();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter=accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal] WHERE [NombreSucursal] LIKE '" + TxtBusqueda.Text + "%'");
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Sucursal");
            LVSucursales.DataSource = dataSet.Tables["Sucursal"];
            LVSucursales.DataBind();
            */
        }

        /*protected void CargarListView()
          {
              DataSet dataSet = new DataSet();
              SqlConnection sqlConnection = new SqlConnection();
              AccesoDatos accesoDatos = new AccesoDatos();
              sqlConnection = accesoDatos.ObtenerConexion();

              SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
              sqlDataAdapter = accesoDatos.ObtenerAdaptador("SELECT [NombreSucursal], [DescripcionSucursal], [URL_Imagen_Sucursal], [Id_Sucursal] FROM [Sucursal]");

              sqlDataAdapter.Fill(dataSet, "Sucursal");
              LVSucursales.DataSource = dataSet.Tables["Sucursal"];
              LVSucursales.DataBind();
          }*/


        protected void BtnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                string[] datosSeleccion = e.CommandArgument.ToString().Split('-');

                string idSucursal = datosSeleccion[0];
                string nombreSucursal = datosSeleccion[1];
                string descripcionSucursal = datosSeleccion[2];


                DataTable dataTableSeleccionados = (DataTable)Session["DataTableSeleccionados"];

                if (dataTableSeleccionados == null)
                {
                    dataTableSeleccionados = new DataTable();
                    dataTableSeleccionados.Columns.Add("Id_Sucursal", typeof(string));
                    dataTableSeleccionados.Columns.Add("NombreSucursal", typeof(string));
                    dataTableSeleccionados.Columns.Add("DescripcionSucursal", typeof(string));
                }
                if (!Yaseleccionado(idSucursal))
                {
                    DataRow NuevaFila = dataTableSeleccionados.NewRow();
                    NuevaFila["Id_Sucursal"] = idSucursal;
                    NuevaFila["NombreSucursal"] = nombreSucursal;
                    NuevaFila["DescripcionSucursal"] = descripcionSucursal;
                    dataTableSeleccionados.Rows.Add(NuevaFila);
                    Session["DataTableSeleccionados"] = dataTableSeleccionados;
                }

                LblMensaje.Text = "ID Sucursal: " + idSucursal + "<br />" +
                                    "Nombre Sucursal: " + nombreSucursal + "<br />" +
                                    "Descripcion Sucursal: " + descripcionSucursal;
            }      
        }

        private bool Yaseleccionado(string idSucursal)
        {
            DataTable dataTableSeleccionados = (DataTable)Session["DataTableSeleccionados"];
            if (dataTableSeleccionados != null)
            {
                foreach (DataRow row in dataTableSeleccionados.Rows)
                {
                    if (row["Id_Sucursal"].ToString() == idSucursal)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        protected void BtnProvincia_Click(object sender, EventArgs e)
        {

        }
    }
}