using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using TP7_GRUPO_5.Conexion;


namespace TP7_GRUPO_5
{
	public partial class SeleccionarSucursales : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
        {
            GestiónSucursal gestiónSucursal = new GestiónSucursal();
            if (!IsPostBack)
            {
                gestiónSucursal.CargarLV(LVSucursales);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            GestiónSucursal gestiónSucursal = new GestiónSucursal();
            gestiónSucursal.FiltrarLV(LVSucursales, TxtBusqueda);
        }
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

        protected void DLProvincia_ItemCommand(object source, DataListCommandEventArgs e)
        {
            GestiónSucursal gestiónSucursal = new GestiónSucursal();
            if (e.CommandName == "EventoProvincia")
            {
                string IdProvincia = e.CommandArgument.ToString();

                gestiónSucursal.FiltrarPorProvinciaLV(LVSucursales,IdProvincia);
            }
        }

        protected void LVSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            GestiónSucursal gestiónSucursal = new GestiónSucursal();
            (LVSucursales.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            gestiónSucursal.CargarLV(LVSucursales);
        }

    }
}