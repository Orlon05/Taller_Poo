using Modulo_Clientes;
using Modulo_Clientes.ClienteService;
using Modulo_Productos;
using System;
using System.Linq;
using Taller_Poo.Modulo_Ventas;

namespace Inicio
{
    class Inicio
    {
        public VentasService venta = new VentasService();
        public ClienteService clienteService = new ClienteService();
        public ProductoService.ProductoService productoService = new ProductoService.ProductoService();
        public string respuesta;
        public string documento;
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
            Console.Clear();
                Console.Write("--------------------------------------------\n---------------MÓDULO PRODUCTO---------------\n--------------------------------------------\n\n");
                Console.Write("---------------BIENVENIDO AL MÓDULO PRODUCTO, SELECCIONE SU OPERACIÓN POR FAVOR---------------");
            do
            {
                Console.Write("\n¿Qué operación desea ejecutar en el modulo de clientes?: \nIntroducir: 1 \nConsultar: 2 \nEditar: 3 \nEliminar: 4 \n\nRespuesta: ");
                Console.WriteLine();
                Console.Write("Ingrese el numero de la funciòn que dessea realizar: ");
                v = int.Parse(Console.ReadLine());
                switch (v)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("---------------AGREGAR UN PRODUCTO---------------\n");
                        do
                        {
                            Console.Write("Ingrese el nombre: ");
                            Nombre = Console.ReadLine();
                            Console.Write("Ingrese el precio: ");
                            Precio = float.Parse(Console.ReadLine());
                            Console.Write("Ingrese la cantidad: ");
                            Cantidad = int.Parse(Console.ReadLine());
                            productoService.AgregarProducto(new Producto
                            {
                                nombre = Nombre,
                                precio = Precio,
                                cantidad = Cantidad,
                                codigo = Codigo
                            });
                            Codigo++;
                            Console.Write("¿Quieres agregar otro producto? R// ");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("---------------MOSTRAR PRODUCTO---------------\n");
                        do
                        {
                            Console.Write("¿Cual producto desea inspeccionar? R// ");
                            cod = int.Parse(Console.ReadLine());
                            productoService.Mostrar(cod);
                            Console.WriteLine("¿Quieres inspeccionar otro producto? R// ");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("---------------ELIMINACIÓN DE PRODUCTO---------------\n");
                        do
                        {
                            Console.Write("¿Cual producto desea eliminar? R// ");
                            cod = int.Parse(Console.ReadLine());
                            productoService.Eliminar(cod);
                            Console.Write("¿Quieres eliminar otro producto? R// ");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("---------------MODICIFAR UN PRODUCTO---------------\n");
                        do
                        {
                            Console.Write("¿Cual producto desea editar? R// ");
                            cod = int.Parse(Console.ReadLine());
                            productoService.Modificar(cod);
                            Console.WriteLine("¿Quieres editar otro producto? R// ");
                            preg = Console.ReadLine();
                        } while (preg.Equals("si"));
                        break;
                    default:
                        Console.WriteLine("La funciòn agregada no existe");
                        break;
                }
                Console.Write("¿Quieres continuar con otra funciòn? R// ");
                preg = Console.ReadLine();
            } while (preg.Equals("si"));
            Console.Clear();
        }
        public void ModVentas()
        {
            SolicitarDocumento();
        }
        public void SolicitarDocumento()
        {
            Console.Write("Ingrese documento del cliente: ");
            documento = Console.ReadLine();

            clienteService.validarDoc(documento);
        }
    }
}
