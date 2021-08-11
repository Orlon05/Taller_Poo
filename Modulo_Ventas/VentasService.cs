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

            validarDoc(documento);
        }

        

        private void validarDoc(string documento)
        {
            ClienteService.metodos metodos = new ClienteService.metodos();
            var consulta = (from clientes in metodos.listaClientes select clientes).ToList();
            bool encontradoConsulta = false;
            foreach (var persona in consulta)
            {
                if (persona.cedula == documento)
                {
                    Console.WriteLine($"\nCédula: {persona.cedula}\nNombre: {persona.nombre}\nDirección: {persona.direccion}\nTelefono: {persona.telefono}");
                    encontradoConsulta = true;
                }
            }
            if (encontradoConsulta == false)
            {
                Console.Write("\nEl número de cedula del cliente es incorrecto o no existe.\n");
                SolicitarDocumento();
            }
        }
    }
}
