using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP7_GRUPO_5.Conexion
{
    public class Sucursales
    {
        public Sucursales()
        {
            // Constructor de la clase Sucursales
        }

        public int Id_Sucursal { get; set; }
        public string NombreSucursal { get; set; }
        public string DescripcionSucursal { get; set; }
        public string URL_Imagen_Sucursal { get; set; }

        public Sucursales(int idSucursal, string nombreSucursal, string descripcionSucursal, string urlImagenSucursal)
        {
            Id_Sucursal = idSucursal;
            NombreSucursal = nombreSucursal;
            DescripcionSucursal = descripcionSucursal;
            URL_Imagen_Sucursal = urlImagenSucursal;

        }
    }
}