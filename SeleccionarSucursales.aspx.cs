using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP7_GRUPO_5
{
	public partial class SeleccionarSucursales : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSeleccionar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "eventoSeleccionar")
            {
                string[] datosSeleccion = e.CommandArgument.ToString().Split('-');

                string idSucursal = datosSeleccion[0];
                string nombreSucursal = datosSeleccion[1];
                string descripcionSucursal = datosSeleccion[2];

                LblMensaje.Text = "ID Sucursal: " + idSucursal + "<br />" +
                                    "Nombre Sucursal: " + nombreSucursal + "<br />" +
                                    "Descripcion Sucursal: " + descripcionSucursal;
            }      
        }
    }
}