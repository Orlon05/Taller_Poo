using System;

namespace Modulo_Configuracion
{

    class ConfiguracionService
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
