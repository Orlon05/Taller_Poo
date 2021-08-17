using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Poo.Modulo_Ventas
{
    class Venta
    {
        public int codigoFactura { get; set; }

        public DateTime fechaFactura { get; set; }

        public string nombreProducto { get; set; }
        public float precioProducto { get; set; }
        public float totalPagar { get; set; }
        public int cantidadProducto { get; set; }
        public int codigoProducto { get; set; }

        public string cedulaCliente { get; set; }
        public string nombreCliente { get; set; }
        public string direccionCliente { get; set; }
        public string telefonoCliente { get; set; }

        public int subCodigoFactura { get; set; }

        public DateTime subFechaFactura { get; set; }

        public string subNombreProducto { get; set; }
        public float subPrecioProducto { get; set; }
        public float subTotalPagar { get; set; }
        public int subCantidadProducto { get; set; }
        public int subCodigoProducto { get; set; }

        public string subCedulaCliente { get; set; }
        public string subNombreCliente { get; set; }
        public string subDireccionCliente { get; set; }
        public string subTelefonoCliente { get; set; }
    }
}
