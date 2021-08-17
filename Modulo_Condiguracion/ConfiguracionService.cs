using System;
using Modulo_Clientes.ClienteService;
using Modulo_Clientes;
using System.Text;

namespace Modulo_Configuracion
{

    public class ConfiguracionService
    {
        private string nombreEmpresa = ". . .";
        public void CabezeraAplicacion(){
            System.Console.WriteLine($"Bievenid@ al sistema de la empresa [ {nombreEmpresa} ] Porfavor proceda con las opciones: \n");
        }

        public void NombrandoEmpresa(string nombre){
            Console.Clear();
            nombreEmpresa = nombre;
        }
        
    }
}
