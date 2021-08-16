using Modulo_Clientes;
using Modulo_Clientes.ClienteService;
using Modulo_Productos;
using Taller_Poo.Modulo_Ventas;
using System;
using System.Linq;

namespace Inicio
{
    class Inicio
    {
        public VentasService venta = new VentasService();
        public ClienteService clienteService = new ClienteService();
        public ProductoService.ProductoService productoService = new ProductoService.ProductoService();
        public VentasService VentasService = new VentasService();
        public string respuesta, documento,respuestaRV,respuestaV, resp = "0";
        public int codigoP, cantidadProduc, codFactura = 1,numM, opcionVenta,numFactura,codigo = 1;
        public float total;
        public DateTime fecha;


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
            Console.Clear();
            
            Console.WriteLine("\n" + DateTime.Now);

            Console.WriteLine("\nInicio\n");
            Console.Write("1) Módulo de Clientes.\n2) Módulo de Productos.\n3) Módulo de Venta.\n4) Módulo de Reportes.\n5) Módulo de Configuración.\n\nSeleccione el numero del módulo al que desea ingresar: ");
            numM = int.Parse(Console.ReadLine());
            switchnumM(numM);
        }

        public void switchnumM(int numM)
        {
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
                case 4:
                    ModReportes();
                    menuP();
                    break;
                default:
                    intenteNuevamente();
                    break;
            }
        }

        public void intenteNuevamente()
        {
            Console.Write("La opción ingresada no existe, intente nuevamente: ");
            numM = int.Parse(Console.ReadLine());
            switchnumM(numM);
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
            int cod;
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
                                codigo = codigo
                            });
                            codigo++;
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
            Console.Clear();
            Console.Write("--------------------------------------------\n---------------MÓDULO VENTAS Y FACTURACIÓN---------------\n--------------------------------------------\n\n");
            Console.Write("\n1) Realizar una venta.\n2) Buscar factura.\n  Ingrese la opción ala que quiere acceder: ");
            opcionVenta = int.Parse(Console.ReadLine());
            switchVentas(opcionVenta);
            SolicitarDocumento();
        }

        public void ModReportes(){
            Console.Clear();
            Console.Write("--------------------------------------------\n---------------MÓDULO REPORTES---------------\n--------------------------------------------\n\n");
            string preg;
            do{
                Console.Write("\n¿Qué operación desea ejecutar en el modulo de reportes?: \nListar Clientes: 1 \nListar Productos: 2 \nListar Facturas: 3\n\nRespuesta: ");
                string resp = Console.ReadLine();
                switch(resp){
                    case "1":
                        ListarCliente();
                        break;
                    case "2":
                        ListarProducto();
                        break;
                    case "3":
                        ListarEncabezadoFacturas();
                        break;
                    default:
                        Console.Write("Esa opción no existe en este módulo, rectifique por favor.");
                        break;
                }
                Console.Write("¿Quieres continuar con otra funciòn? R// ");
                preg = Console.ReadLine();

            }while (preg.Equals("si"));
            
            
        }

        public void ListarCliente (){
            Console.Clear();
            System.Console.WriteLine("--------------------------------------------\n---------------LISTA DE CLIENTES REGISTRADOS---------------\n--------------------------------------------\n");
            clienteService.ListandoClientes();
        }
        public void ListarProducto (){
            Console.Clear();
            System.Console.WriteLine("--------------------------------------------\n---------------LISTA DE PRODUCTOS REGISTRADOS---------------\n--------------------------------------------\n");
            productoService.ListandoProductos();
        }
        public void ListarEncabezadoFacturas (){
            Console.Clear();
            System.Console.WriteLine("--------------------------------------------\n---------------LISTA DE PRODUCTOS REGISTRADOS---------------\n--------------------------------------------\n");
            VentasService.ListandoEncabezadoFactura();
        }

        public void switchVentas(int opcionVenta)
        {
            switch (opcionVenta)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("---------------MÓDULO VENTA---------------");
                    SolicitarDocumento();
                    Console.Write("\n¿Desea realizar otra venta? ");
                    respuestaRV = Console.ReadLine();
                    if (respuestaRV.Equals("si"))
                    {
                        Console.Clear();
                        Console.WriteLine("---------------MÓDULO VENTA---------------");
                        SolicitarDocumento();
                    }
                   
                    break;
                case 2:
                    Console.WriteLine("---------------MÓDULO BUSCAR FACTURA---------------");
                    BuscarFactura();

                    Console.Write("\n¿Desea realizar otra busqueda? ");
                    respuestaRV = Console.ReadLine();
                    if (respuestaRV.Equals("si"))
                    {
                        Console.Clear();
                        Console.WriteLine("---------------MÓDULO BUSCAR FACTURA---------------");
                        BuscarFactura();
                    }
            
                    break;
                default:
                    intenteOpcion();
                    break;
            }
            Console.Write("\n¿Desea realizar otra opción en el módulo de venta y facturación? ");
            respuestaV = Console.ReadLine();

            if (respuestaV.Equals("si"))
            {
                ModVentas();
            }

            menuP();

        }

        public void BuscarFactura()
        {
            Console.Write("Número de factura: ");
            numFactura = int.Parse(Console.ReadLine());
            VentasService.ConsultarCodigoFactura(numFactura);

            if ((VentasService.ConsultarCodigoFactura(numFactura)) == true)
            {
                VentasService.imprimirDetalleFactura(numFactura);
            }
            else
            {
                Console.Write("El número de factura no existe. Vuelva a intentarlo:\n");
                BuscarFactura();
            }
        }

        public void intenteOpcion()
        {
            Console.Write("La opción ingresada no existe, intente nuevamente: ");
            opcionVenta = int.Parse(Console.ReadLine());
            switchVentas(opcionVenta);
        }

        public void SolicitarDocumento()
        {
            Console.Write("Ingrese documento del cliente: ");
            documento = Console.ReadLine();

            clienteService.validarDoc(documento);
            if ((clienteService.document) == true)
            {
                SolicitarCodigo();
            }
            else
            {
                Console.Write("El documento ingresado no existe.\n");
                SolicitarDocumento();
            }
        }

        public void SolicitarCodigo()
        {
            Console.Write("Ingrese código del producto: ");
            codigoP = int.Parse(Console.ReadLine());

            productoService.validarCod(codigoP);
            if ((productoService.codiProduc) == true)
            {
                SolicitarCanti();
            }
            else
            {
                SolicitarCodigo();
            }

        }

        public void SolicitarCanti()
        {
            Console.Write("Ingrese la catidad de producto que desea llevar: ");
            cantidadProduc = int.Parse(Console.ReadLine());

            validarCanti(cantidadProduc, codigoP);
        }

        public void aggVenta()
        {
            fecha = DateTime.Now;
            VentasService.AgregarVenta(new Venta
            {
                fechaFactura = fecha,
                codigoFactura = codFactura,
                cedulaCliente = clienteService.cedulaClie,
                nombreCliente = clienteService.nombreClie,
                direccionCliente = clienteService.direccionClie,
                telefonoCliente = clienteService.telefonoClie,
                codigoProducto = productoService.codigoProducto,
                nombreProducto = productoService.nombreProduc,
                precioProducto = productoService.precioProduc,
                cantidadProducto = cantidadProduc,
                totalPagar = productoService.total
            });
            codFactura = codFactura + 1;
            VentasService.otroProducto();
            aggOtroProducto();
        }

        public void aggOtroProducto()
        {
            if (VentasService.aggProducto.Equals("si"))
            {
                codFactura = codFactura - 1;

                SolicitarCodigo();
            }
            else
            {
                total = productoService.total;
                VentasService.imprimirEncabezadoFactura(codFactura);
            }
        }
        public void validarCanti(int cantidadProduc, int codigoP)
        {
            if (cantidadProduc <= productoService.cantProduc)
            {
                productoService.cambiarCant(codigoP, cantidadProduc);
                aggVenta();
            }else
            {
                Console.Write("La cantidad que ingresa excede la cantidad del producto, intente nuevamente: \n");
                SolicitarCanti();

            }
        }


        

    }
}
