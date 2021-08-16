using Modulo_Clientes.ClienteService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_Poo.Modulo_Ventas
{
    class VentasService
    {
        private List<Venta> listaVentas = new List<Venta>();
        public string aggProducto,cc,clie;
        public float totalPI;
        public DateTime fecha;
        public void AgregarVenta(Venta venta)
        {
            listaVentas.Add(venta);
        }

        public void otroProducto()
        {
            Console.Write("\n¿Desea agregar otro producto: ");
            aggProducto = Console.ReadLine();
        }

        public void imprimirEncabezadoFactura(int codFactura)
        {
            Console.Write("---------------------FACTURA---------------------\n");
           
            var consulta = (from ventas in listaVentas where  ventas.codigoFactura == (codFactura - 1) select ventas).ToList();
            Console.WriteLine($"Número de factura: {(codFactura-1)}.");
            foreach (var ventas in consulta)
            {
                
                cc = ventas.nombreCliente;
                totalPI = ventas.totalPagar;
                fecha = ventas.fechaFactura;

            }
            Console.WriteLine($"\nFecha: {fecha}     Cedula cliente: {cc}     Total a Pagar: {totalPI.ToString("N0")}");


        }

        public bool ConsultarCodigoFactura(int numFactura)
        {
            var consulta = listaVentas.FirstOrDefault(ventas => ventas.codigoFactura.Equals(numFactura));
            if (consulta != null)//Si se encuentra registrado el cliente nos retornará un true, este para verificar si existe
                return true;
            return false;
        }
        public void imprimirDetalleFactura(int numFactura)
        {
            Console.Write("---------------------FACTURA---------------------\n");

            var consulta = (from ventas in listaVentas where ventas.codigoFactura == (numFactura) select ventas).ToList();
            
            foreach (var ventas in consulta)
            {
                clie = ventas.cedulaCliente;
                cc = ventas.nombreCliente;
                fecha = ventas.fechaFactura;

            }
            Console.WriteLine($"Número de factura: {(numFactura)}      Fecha factura: {fecha}.\n{cc}     {clie}.");

            foreach (var ventas in consulta)
            {
                //Console.WriteLine($"Número de factura: {ventas.codigoFactura}.");
                Console.WriteLine($"\n{ventas.cantidadProducto}     {ventas.nombreProducto}      {ventas.precioProducto}\n");
                totalPI = ventas.totalPagar;
            }
            Console.WriteLine($"\nTOTAL A PAGAR: {totalPI.ToString("N0")}");
        }

    }
}
