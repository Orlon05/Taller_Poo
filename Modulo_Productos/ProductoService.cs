using Modulo_Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoService
{
    public class ProductoService
    {
        public List<Producto> listaProducto = new List<Producto>();
        public bool codiProduc;
        public string nombreProduc;
        public float precioProduc, total, pagar;
        public int cantidadProduc, codigoProduc, cantProduc, codigoProducto;

        public void AgregarProducto(Producto producto)
        {
            listaProducto.Add(producto);
        }

       /* public void Mostrar(int cod)
        {
            var consulta = (from productos in listaProducto where productos.codigo == cod select productos).ToList();
            foreach (var producto in consulta)
            {
                Console.WriteLine($"Nombre: {producto.nombre} Precio: {producto.precio}");
            }
        }*/

        public void Mostrar(int cod)
        {
            var producto = listaProducto.FirstOrDefault(producto => producto.codigo.Equals(cod));

            if (producto != null)
                Console.WriteLine($"\nC�digo: {producto.codigo}\nNombre: {producto.nombre}\nPrecio: {producto.precio}\nCantidad: {producto.cantidad}\n");
            else
                Console.Write("\nNo se encontr� una producto con ese c�digo.\n");

        }

        public void Modificar(int cod)
        {
            var consulta = (from productos in listaProducto where productos.codigo == cod select productos).ToList();
            foreach (var producto in consulta)
            {
                Console.WriteLine($"Nombre: {producto.nombre} Precio: {producto.precio} Cantidad: {producto.cantidad} ");
                listaProducto.Remove(producto);
            }
            Console.Write("Ingrese el nuevo nombre: ");
            string Nombre = Console.ReadLine();
            Console.Write("Ingrese el nuevo Precio: ");
            float Precio = float.Parse(Console.ReadLine());
            Console.Write("Ingrese la nueva cantidad: ");
            int Cantidad = int.Parse(Console.ReadLine());
            listaProducto.Add(new Producto { nombre = Nombre, precio = Precio, cantidad = Cantidad, codigo = cod });
        }

        public void Eliminar(int cod)
        {
            var consulta = (from productos in listaProducto where productos.codigo == cod select productos).ToList();
            foreach (var producto in consulta)
            {
                Console.WriteLine($"Nombre: {producto.nombre} Precio: {producto.precio} Cantidad: {producto.cantidad} ");
                listaProducto.Remove(producto);
            }
        }

        public void validarCod(int codigoP)
        {
            var producC = listaProducto.FirstOrDefault(producto => producto.codigo.Equals(codigoP));

            
            if (producC != null)
            {
                codiProduc = true;
                nombreProduc = producC.nombre;
                precioProduc = producC.precio;
                cantProduc = producC.cantidad;
                codigoProducto = producC.codigo;
                
            }
            else
                codiProduc = false;

        }

        public void cambiarCant(int codigoP, int cantidadProduc)
        {
            var consulta = (from productos in listaProducto where productos.codigo == codigoP select productos).ToList();

            foreach (var producto in listaProducto)
            {
                if (producto.codigo == codigoP)
                {
                    producto.cantidad = (producto.cantidad) - cantidadProduc;
                    total = total + (producto.precio * cantidadProduc);
                }
            }
        }

        public void ListandoProductos(){
            var consulta = listaProducto.ToList();
            foreach (var cliente in consulta)
            {
                System.Console.WriteLine($"Producto: {cliente.nombre}, Con Codigo: {cliente.codigo} de cantidad: {cliente.cantidad} y precio: {cliente.precio}");
                System.Console.WriteLine("-------------------------------------------------------------");
            }
        }

    }
}