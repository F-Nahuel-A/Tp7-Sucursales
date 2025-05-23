using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TP7_GRUPO_5
{
	public partial class ListadoSucursalesSeleccionados : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				// Carga la lista de sucursales seleccionadas al cargar la página
				CargarListView();
            }
        }

		private void CargarListView()
		{
            DataTable dataTableSeleccionados = (DataTable)Session["DataTableSeleccionados"];
			GvMostrarSucursalesSeleccionadas.DataSource = dataTableSeleccionados;
			GvMostrarSucursalesSeleccionadas.DataBind();
        }

        protected void GvMostrarSucursalesSeleccionadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvMostrarSucursalesSeleccionadas.PageIndex = e.NewPageIndex;
			CargarListView();
        }
    }
}