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
                Console.WriteLine($"\nCódigo: {producto.codigo}\nNombre: {producto.nombre}\nPrecio: {producto.precio}\n");
            else
                Console.Write("\nNo se encontró una producto con ese código.\n");

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
    }
}