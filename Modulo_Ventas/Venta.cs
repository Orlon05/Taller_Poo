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
    }
}
