using Modulo_Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClienteService
{
    public class metodos{
        
        //Creación de lista.
        public List<Cliente> listaClientes = new List<Cliente>();
        public void AgregarCliente(string cedula, string nombre, string direccion, string telefono)
        {
            listaClientes.Add(new Cliente{
                cedula = cedula, 
                nombre = nombre, 
                direccion = direccion, 
                telefono = telefono
            });
        }
        public void ConsultarCliente(string documento)
        {
            var consulta = (from clientes in listaClientes select clientes).ToList();
            bool encontradoConsulta = false;
            foreach (var persona in consulta){
                if(persona.cedula == documento){
                    Console.WriteLine($"\nCédula: {persona.cedula}\nNombre: {persona.nombre}\nDirección: {persona.direccion}\nTelefono: {persona.telefono}");
                    encontradoConsulta = true;
                }
            }
            if(encontradoConsulta == false){
                    Console.Write("\nNo se encontró una persona con ese número de documento\n");
            }
        }

        public void ModificarCliente(string cedula)
        {
            var consulta = (from clientes in listaClientes where clientes.cedula == cedula select clientes).ToList();
            foreach (var persona in consulta)
            {
                Console.WriteLine($"\nCedula: {persona.cedula} \nNombre: {persona.nombre} \ndirección: {persona.direccion} \nteléfono: {persona.telefono}\n");
                //listaClientes.Remove(persona);
                Console.Write("Ingrese el nuevo nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva dirección: ");
                string direccion = Console.ReadLine();
                Console.Write("Ingrese el nuevo teléfono: ");
                string telefono = Console.ReadLine();
                persona.nombre=nombre;
                persona.direccion=direccion;
                persona.telefono=telefono;
            }
        }
        public void EliminarCliente(string cedula)
        {
            var consulta = (from clientes in listaClientes where clientes.cedula == cedula select clientes).ToList();
            foreach (var persona in consulta)
            {
                listaClientes.Remove(persona);
            }
        }
        public bool validarClienteCreacion(string cedula)
        {
            bool existe = false;
            var consulta = (from clientes in listaClientes where clientes.cedula == cedula select clientes).ToList();
            foreach (var persona in consulta){
                if(persona.cedula == cedula){
                    Console.Write("\nUn cliente con esa cédula ya existe, repita por favor el proceso\n");
                    existe = true;
                }
            }
            return existe;
        }
        public bool validarClienteEdicion(string cedula)
        {
            bool existe = false;
            var consulta = (from clientes in listaClientes where clientes.cedula == cedula select clientes).ToList();
            foreach (var persona in consulta){
                if(persona.cedula == cedula){
                    existe = true;
                }
            }
            return existe;
        }
    }
}