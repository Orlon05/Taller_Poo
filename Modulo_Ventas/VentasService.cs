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
        public void AgregarVenta(Venta venta)
        {
            listaVentas.Add(venta);
        }

        public void otroProducto()
        {
            Console.Write("\n¿Desea agregar otro producto: ");
            aggProducto = Console.ReadLine();
        }

        public void imprimirFactura(int codFactura)
        {
            Console.Write("---------------------FACTURA---------------------\n");
           
            var consulta = (from ventas in listaVentas where  ventas.codigoFactura == (codFactura - 1) select ventas).ToList();
            Console.WriteLine($"Número de factura: {(codFactura-1)}.");
            foreach (var ventas in consulta)
            {
                clie = ventas.cedulaCliente;
                cc = ventas.nombreCliente;

            }
            foreach (var ventas in consulta)
            {
                //Console.WriteLine($"Número de factura: {ventas.codigoFactura}.");
                Console.WriteLine($"\n{ventas.cantidadProducto}     {ventas.nombreProducto}      {ventas.precioProducto}\n");
                totalPI = ventas.totalPagar;
            }
            Console.WriteLine($"\nTOTAL A PAGAR: {totalPI}");


        }

        public bool ConsultarCodigoFactura(int numFactura)
        {
            var consulta = listaVentas.FirstOrDefault(ventas => ventas.codigoFactura.Equals(numFactura));
            if (consulta != null)//Si se encuentra registrado el cliente nos retornará un true, este para verificar si existe
                return true;
            return false;
        }
        public void BuscaFactura(int numFactura)
        {
            Console.Write("---------------------FACTURA---------------------\n");

            var consulta = (from ventas in listaVentas where ventas.codigoFactura == (numFactura) select ventas).ToList();
            Console.WriteLine($"Número de factura: {(numFactura)}.");
            foreach (var ventas in consulta)
            {
                clie = ventas.cedulaCliente;
                cc = ventas.nombreCliente;

            }
            Console.WriteLine($"{clie}     {cc}");
            foreach (var ventas in consulta)
            {
                //Console.WriteLine($"Número de factura: {ventas.codigoFactura}.");
                Console.WriteLine($"\n{ventas.cantidadProducto}     {ventas.nombreProducto}      {ventas.precioProducto}\n");
                totalPI = ventas.totalPagar;
            }
            Console.WriteLine($"\nTOTAL A PAGAR: {totalPI}");


        }

    }
}
