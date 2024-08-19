using System;

namespace Segunda_Practica
{
    class PROGRAM
    {
        static void Main(string[] args)
        {
            //todo Declarar variable bool como verdadera para controlar el bucle principal del menú
            bool continuar = true;

            //todo Bucle do-while que mantiene el programa ejecutándose hasta que el usuario decida salir
            do
            {
                // Mostrar el menú principal
                Console.WriteLine("\n MENU PRINCIPAL: \n");
                Console.WriteLine(
                    "\n(1) Sistema de Registro de Clientes " +
                    "\n(2) Sistema de Seguimiento de Tareas  " +
                    "\n(3) Cerrar el programa\n");

                int seleccion = int.Parse(Console.ReadLine());

               
                switch (seleccion)
                {
                    case 1:
                        //todo Llamar al sistema de registro de clientes
                        SistemaRegistroClientes(); 
                        break;
                    case 2:
                        //todo Llamar al sistema de seguimiento de tareas
                        SistemaSeguimientoTareas(); 
                        break;
                    case 3:
                        //todo Terminar el bucle, cerrando el programa
                        continuar = false; 
                        Console.WriteLine("Programa cerrado \nPRESIONA CUALQUIER TECLA PARA SALIR\n.");
                        break;
                    default:
                        Console.WriteLine("\nOBCION INVALIDA\n."); 
                        break;
                }
            }
            //todo Continuar el bucle mientras 'continuar' sea verdadero
            while (continuar); 
        }

        //todo Método para el sistema de registro de clientes
        static void SistemaRegistroClientes()
        {
            //todo Crear una lista para almacenar los clientes
            List<Cliente> listaClientes = new List<Cliente>();
            bool continuarClientes = true; 

            //todo Bucle para el registro de clientes
            while (continuarClientes)
            {
                Console.WriteLine("\nSistema de Registro de Clientes:");
                Console.WriteLine("\n(1) Agregar Cliente " +
                                  "\n(2) Mostrar Clientes " +
                                  "\n(3) Volver al menú principal\n");
                int opcionClientes = int.Parse(Console.ReadLine());

                switch (opcionClientes)
                {
                    case 1:
                        //todo capturar la información del cliente
                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la edad del cliente: ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el correo del cliente: ");
                        string correo = Console.ReadLine();

                        //todo Determinar si el cliente es corporativo
                        Console.Write("¿El cliente es corporativo? (s/n): ");
                        string Corporativo = Console.ReadLine().ToLower();

                        //todo Crear y agregar el cliente a la lista según sea corporativo o no
                        if (Corporativo == "s")
                        {
                            Console.Write("Ingrese el nombre de la empresa: ");
                            string nombreEmpresa = Console.ReadLine();
                            Cliente cliente = new ClienteCorporativo(nombre, edad, correo, nombreEmpresa);
                            listaClientes.Add(cliente);
                        }
                        else
                        {
                            Cliente cliente = new Cliente(nombre, edad, correo);
                            listaClientes.Add(cliente);
                        }

                        Console.WriteLine("Cliente agregado con éxito.");
                        break;
                    case 2:
                        //todo Mostrar la lista de clientes registrados
                        Console.WriteLine("\nLista de Clientes:");
                        foreach (Cliente cliente in listaClientes)
                        {
                            cliente.MostrarInformacion();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        continuarClientes = false; 
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo."); 
                        break;
                }
            }
        }

        //todo Método para el sistema de seguimiento de tareas
        static void SistemaSeguimientoTareas()
        {
            //todo Crear una lista para almacenar las tareas
            List<Tarea> listaTareas = new List<Tarea>();
            bool continuarTareas = true;

            //todo Bucle para las tareas
            do
            {
                Console.WriteLine("\nSistema de Seguimiento de Tareas:");
                Console.WriteLine("\n(1) Agregar Tarea " +
                                  "\n(2) Mostrar Tareas " +
                                  "\n(3) Volver al menú principal\n");
                int opcionTareas = int.Parse(Console.ReadLine());

                switch (opcionTareas)
                {
                    case 1:
                        //todo capturar la información de la tarea
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Ingrese la fecha límite (dd/mm/aaaa): ");
                        DateTime fechaLimite = DateTime.Parse(Console.ReadLine());

                        //todo Determinar si la tarea es urgente
                        Console.Write("¿La tarea es urgente? (s/n): ");
                        string Urgente = Console.ReadLine().ToLower();

                        //todo Crear y agregar la tarea a la lista según sea urgente o no
                        if (Urgente == "s")
                        {
                            Console.Write("Ingrese el nivel de urgencia: ");
                            string nivelUrgencia = Console.ReadLine();
                            Tarea tarea = new TareaUrgente(titulo, descripcion, fechaLimite, nivelUrgencia);
                            listaTareas.Add(tarea);
                        }
                        else
                        {
                            Tarea tarea = new Tarea(titulo, descripcion, fechaLimite);
                            listaTareas.Add(tarea);
                        }

                        Console.WriteLine("Tarea agregada con éxito.");
                        break;
                    case 2:
                        //todo Mostrar la lista de tareas registradas
                        Console.WriteLine("\nLista de Tareas:");
                        foreach (Tarea tarea in listaTareas)
                        {
                            tarea.MostrarDetalles();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        continuarTareas = false; 
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo."); 
                        break;
                }
            }
            while (continuarTareas);
        }
    }

    //todo Clase base para representar un Cliente
    class Cliente
    {
        private string nombre;
        private int edad;
        private string correo;

      public Cliente(string nombre, int edad, string correo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.correo = correo;
        }

        //todo Métodos de acceso para las propiedades del cliente
        public void SetNombre(string nombre) { this.nombre = nombre; }
        public string GetNombre() { return nombre; }

        public void SetEdad(int edad) { this.edad = edad; }
        public int GetEdad() { return edad; }

        public void SetCorreo(string correo) { this.correo = correo; }
        public string GetCorreo() { return correo; }

        //todo Método para mostrar la información del cliente
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Correo: {correo}");
        }
    }

 
    class ClienteCorporativo : Cliente
    {
        private string nombreEmpresa;

        public ClienteCorporativo(string nombre, int edad, string correo, string nombreEmpresa)
            : base(nombre, edad, correo)
        {
            this.nombreEmpresa = nombreEmpresa;
        }

        public void SetNombreEmpresa(string nombreEmpresa) { this.nombreEmpresa = nombreEmpresa; }
        public string GetNombreEmpresa() { return nombreEmpresa; }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); 
            Console.WriteLine($"Nombre de la Empresa: {nombreEmpresa}");
        }
    }

    class Tarea
    {
        private string titulo;
        private string descripcion;
        private DateTime fechaLimite;

        public Tarea(string titulo, string descripcion, DateTime fechaLimite)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fechaLimite = fechaLimite;
        }


        public void SetTitulo(string titulo) { this.titulo = titulo; }
        public string GetTitulo() { return titulo; }

        public void SetDescripcion(string descripcion) { this.descripcion = descripcion; }
        public string GetDescripcion() { return descripcion; }

        public void SetFechaLimite(DateTime fechaLimite) { this.fechaLimite = fechaLimite; }
        public DateTime GetFechaLimite() { return fechaLimite; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Título: {titulo}, Descripción: {descripcion}, Fecha Límite: {fechaLimite.ToShortDateString()}");
        }
    }

    
    class TareaUrgente : Tarea
    {
        private string nivelUrgencia;

        
        public TareaUrgente(string titulo, string descripcion, DateTime fechaLimite, string nivelUrgencia)
            : base(titulo, descripcion, fechaLimite)
        {
            this.nivelUrgencia = nivelUrgencia;
        }

        
        public void SetNivelUrgencia(string nivelUrgencia) { this.nivelUrgencia = nivelUrgencia; }
        public string GetNivelUrgencia() { return nivelUrgencia; }

        
        public override void MostrarDetalles()
        {
            base.MostrarDetalles(); 
            Console.WriteLine($"Nivel de Urgencia: {nivelUrgencia}");
        }
    }
}

