using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClienteService;

namespace Taller_Poo.Modulo_Ventas
{
    class VentasService
    {
        private string documento;
        public void SolicitarDocumento()
        {
            Console.Write("Ingrese documento del cliente: ");
            documento = Console.ReadLine();

            validarDoc();
        }

        public void validarDoc()
        {
            Console.Clear();
            ClienteService.metodos metodos = new ClienteService.metodos();
            Console.Write("\nDigite la cédula de la persona que desea buscar, en caso de querer ver todos los clientes digite 'todos': ");
            string documento = (Console.ReadLine().ToLower());
            if (documento == "todo")
            {
                var consulta = (from clientes in metodos.listaClientes select clientes).ToList();
                foreach (var persona in consulta)
                {
                    Console.WriteLine($"\nCedula: {persona.cedula} \nNombre: {persona.nombre} \ndirección: {persona.direccion} \nteléfono: {persona.telefono}\n");
                }
            }
            else
                metodos.ConsultarCliente(documento);
        }
    }
}
