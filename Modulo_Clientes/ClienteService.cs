using Modulo_Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Modulo_Clientes.ClienteService
{
    public class ClienteService{
        
        //Creación de lista.
        private List<Cliente> listaClientes = new List<Cliente>();
        public bool document;
        public string cedulaClie, nombreClie, direccionClie, telefonoClie;
        public void AgregarCliente(Cliente cliente)
        {
            listaClientes.Add(cliente);
        }

        public bool ConsultarDocumento(string documento)
        {
            var consulta = listaClientes.FirstOrDefault(cliente=>cliente.cedula.Equals(documento));
            if (consulta != null)//Si se encuentra registrado el cliente nos retornará un true, este para verificar si existe
                return true;
            return false;
        }

        public void ConsultarCliente(string documento)
        {
            var cliente = listaClientes.FirstOrDefault(cliente => cliente.cedula.Equals(documento));

            if (cliente != null)
                Console.WriteLine($"\nCédula: {cliente.cedula}\nNombre: {cliente.nombre}\nDirección: {cliente.direccion}\nTelefono: {cliente.telefono}");
            else
                Console.Write("\nNo se encontró una persona con ese número de documento\n");
            
        }

        public void validarDoc(string documento)
        {
            var cliente = listaClientes.FirstOrDefault(cliente => cliente.cedula.Equals(documento));

            if (cliente != null)
            {
                document = true;
                cedulaClie = cliente.cedula;
                nombreClie = cliente.nombre;
                direccionClie = cliente.direccion;
                telefonoClie = cliente.telefono;
            }
            else
                document = false;

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

        public void ListandoClientes(){
            var consulta = listaClientes.ToList();
            foreach (var cliente in consulta)
            {
                System.Console.WriteLine($"CLIENTE: {cliente.nombre}, Con cedula: {cliente.cedula}, direccion: {cliente.direccion} y telefono: {cliente.telefono}");
                System.Console.WriteLine("-------------------------------------------------------------");
            }
        }
    }
}