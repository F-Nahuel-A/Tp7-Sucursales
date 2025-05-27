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
        private GestionSucursal gestionSucursales = new GestionSucursal();

		protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                gestionSucursales.CargarLV(LVSucursales);
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            gestionSucursales.FiltrarLV(LVSucursales, TxtBusqueda.Text.Trim());
        }

        protected void BtnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                string[] datosSeleccion = e.CommandArgument.ToString().Split('-');

                string idSucursal = datosSeleccion[0];
                string nombreSucursal = datosSeleccion[1];
                string descripcionSucursal = datosSeleccion[2];

                if (Session["tabla"] == null)
                {
                    Session["tabla"] = gestionSucursales.CrearTabla();
                }
                gestionSucursales.agregarFila((DataTable)Session["tabla"], idSucursal, nombreSucursal, descripcionSucursal);
            }      
        }

        protected void DLProvincia_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "EventoProvincia")
            {
                string IdProvincia = e.CommandArgument.ToString();
                gestionSucursales.FiltrarPorProvinciaLV(LVSucursales, IdProvincia);
            }
        }

        protected void LVSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (LVSucursales.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            gestionSucursales.CargarLV(LVSucursales);
        }
    }
}