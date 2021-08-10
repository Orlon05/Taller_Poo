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
        public void Agregar(string Nombre, float Precio, int Cantidad, int Codigo)
        {
            listaProducto.Add(new Producto { nombre = Nombre, precio = Precio, cantidad = Cantidad, codigo = Codigo });
        }

        public void Mostrar(int cod)
        {
            var consulta = (from productos in listaProducto where productos.codigo == cod select productos).ToList();
            foreach (var producto in consulta)
            {
                Console.WriteLine($"Nombre: {producto.nombre} Precio: {producto.precio}");
            }
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