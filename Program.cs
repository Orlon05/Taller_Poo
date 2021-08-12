using Modulo_Clientes;
using Modulo_Clientes.ClienteService;
using System;
using System.Linq;
using Taller_Poo.Modulo_Ventas;

namespace Inicio
{
    class Inicio
    {
        public VentasService venta = new VentasService();
        public ClienteService clienteService = new ClienteService();
        public ProductoService.ProductoService lista = new ProductoService.ProductoService();
        public string respuesta;
        static void Main(string[] args)
        {
            Inicio inicio = new Inicio();
            inicio.inicio();
        }

        public void menuP()
        {
            Console.Write("¿Desea realizar alguna acción en otro módulo?");
            respuesta = Console.ReadLine();
            while (respuesta.Equals("si"))
            {
                inicio();
            }
        }

        public void inicio()
        {
            int numM;
            Console.WriteLine("\n" + DateTime.Now);

            Console.WriteLine("\nInicio\n");
            Console.Write("1) Módulo de Clientes.\n2) Módulo de Productos.\n3) Módulo de Venta.\n4) Módulo de Reportes.\n5) Módulo de Configuración.\n\nSeleccione el numero del módulo al que desea ingresar: ");
            numM = int.Parse(Console.ReadLine());

            switch (numM)
            {
                case 1:
                    ModCliente();
                    menuP();
                    break;
                case 2:
                    ModProducto();
                    menuP();
                    break;
                case 3:
                    ModVentas();
                    menuP();
                    break;
            }
        }

        public void ModCliente()
        {
            string Operacion = "";
            while (Operacion != "no")
            {
                Console.Clear();
                Console.Write("--------------------------------------------\n---------------MÓDULO CLIENTE---------------\n--------------------------------------------\n\n");
                Console.Write("---------------BIENVENIDO AL MÓDULO USUARIO, SELECCIONE SU OPERACIÓN POR FAVOR---------------");
                Console.Write("\n¿Qué operación desea ejecutar en el modulo de clientes?: \nIntroducir: 1 \nConsultar: 2 \nEditar: 3 \nEliminar: 4 \n\nRespuesta: ");
                string resp = Console.ReadLine();

                //Switch de operaciones.
                switch (resp)
                {
                    case ("1"):
                        Console.Clear();
                        Console.Write("---------------INTRODUCCIÓN DE CLIENTE---------------\n");
                        string respNuevoCliente = "";
                        while (respNuevoCliente != "no")
                        {
                            Console.Write("\nDigite la cedula de la persona por favor: ");
                            string cedula = Console.ReadLine();
                            Console.Write("Digite el nombre de la persona por favor: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Digite la direccion de la persona por favor: ");
                            string direccion = Console.ReadLine();
                            Console.Write("Digite el telefono de la persona por favor: ");
                            string telefono = Console.ReadLine();
                            if (clienteService.validarClienteCreacion(cedula) == false)
                            {
                                clienteService.AgregarCliente(new Cliente
                                {
                                    cedula = cedula,
                                    nombre = nombre,
                                    direccion = direccion,
                                    telefono = telefono
                                });

                                Console.Write("\n¿Desea agregar un cliente más?: ");
                                string clienteNuevo = (Console.ReadLine().ToLower());
                                if (clienteNuevo == "no")
                                    respNuevoCliente = "no";
                            }
                            else
                                break;
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("---------------CONSULTA DE CLIENTE---------------\n");
                        Console.Write("\nDigite la cédula de la persona que desea buscar, en caso de querer ver todos los clientes digite 'todos': ");
                        string documento = (Console.ReadLine().ToLower());

                        clienteService.ConsultarCliente(documento);
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("---------------ACTUALIZACIÓN/EDICION DE CLIENTE---------------\n");
                        Console.Write("\nDigite el documento de la persona que desea editar: ");
                        string editar = Console.ReadLine();
                        if (clienteService.validarClienteEdicion(editar) == true)
                        {
                            clienteService.ModificarCliente(editar);
                        }
                        else
                            Console.Write("\nNo se encontró una persona con ese numero de cédula\n");
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("---------------ELIMINACIÓN DE CLIENTE---------------\n");
                        Console.Write("\nDigite el documento de la persona que desea eliminar: ");
                        string eliminar = Console.ReadLine();
                        if (clienteService.validarClienteEdicion(eliminar) == true)
                        {
                            clienteService.EliminarCliente(eliminar);
                        }
                        else
                            Console.Write("\nNo se encontró una persona con ese numero de cédula\n");
                        break;
                    default:
                        Console.Write("Esa opción no existe en este módulo, rectifique por favor.");
                        break;
                }
                Console.Write("\n¿Desea realizar otra operación en el módulo de clientes? Si/No: ");
                string respModuloClientes = (Console.ReadLine().ToLower());
                if (respModuloClientes == "no")
                    Operacion = "no";
                else
                    continue;
            }
        }

        public void ModProducto()
        {
            int v;
            string preg;
            string Nombre;
            float Precio;
            int Cantidad;
            int Codigo = 1, cod;
            Console.WriteLine("¡Bienvenidos!");
            Console.WriteLine();
            Console.WriteLine("A continuaciòn le daremos las opciones disponibles: ");
            Console.WriteLine();
            do
            {
                Console.WriteLine("1. para agregar un producto");
                Console.WriteLine("2. para inspeccionar un producto");
                Console.WriteLine("3. para eliminar un producto");
                Console.WriteLine("4. para modificar un producto");
                Console.WriteLine();
                Console.Write("Ingrese el numero de la funciòn que dessea realizar: ");
                v = int.Parse(Console.ReadLine());
                switch (v)
                {
                    case 1:
                        Console.WriteLine("----- AGREGAR -----");
                        do
                        {
                            Console.Write("Ingrese el nombre: ");
                            Nombre = Console.ReadLine();
                            Console.Write("Ingrese el precio: ");
                            Precio = float.Parse(Console.ReadLine());
                            Console.Write("Ingrese la cantidad: ");
                            Cantidad = int.Parse(Console.ReadLine());
                            lista.Agregar(Nombre, Precio, Cantidad, Codigo);
                            Codigo++;
                            Console.Write("¿Quieres agregar otro producto? R// ");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 2:
                        Console.WriteLine("----- MOSTRAR -----");
                        do
                        {
                            Console.WriteLine("¿Cual producto desea inspeccionar?");
                            cod = int.Parse(Console.ReadLine());
                            lista.Mostrar(cod);
                            Console.WriteLine("¿Quieres inspeccionar otro producto?");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 3:
                        Console.WriteLine("----- ELIMINAR -----");
                        do
                        {
                            Console.WriteLine("¿Cual producto desea eliminar?");
                            cod = int.Parse(Console.ReadLine());
                            lista.Eliminar(cod);
                            Console.WriteLine("¿Quieres eliminar otro producto?");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 4:
                        Console.WriteLine("----- MODIFICAR -----");
                        do
                        {
                            Console.WriteLine("¿Cual porducto desea editar?");
                            cod = int.Parse(Console.ReadLine());
                            lista.Modificar(cod);
                            Console.WriteLine("¿Quieres editar otro producto?");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    default:
                        Console.WriteLine("La funciòn agregada no existe");
                        break;
                }
                Console.WriteLine("¿Quieres continuar con otra funciòn?");
                preg = Console.ReadLine();
            } while (preg.Equals("si"));
        }
        public void ModVentas()
        {
            venta.SolicitarDocumento();
        }
    }
}
