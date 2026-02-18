using System; // Importa el espacio de nombres System para usar funcionalidades básicas como Console

namespace AgendaClinica
{
    // Definición de la clase Paciente
    class Paciente
    {
        // Propiedad que almacena el nombre del paciente y permite lectura/escritura
        public string Nombre { get; set; }

        // Propiedad que almacena la edad del paciente y permite lectura/escritura
        public int Edad { get; set; }

        // Propiedad que almacena el teléfono del paciente y permite lectura/escritura
        public string Telefono { get; set; }

        // Constructor de la clase Paciente, recibe nombre, edad y teléfono
        public Paciente(string nombre, int edad, string telefono)
        {
            // Asigna el valor del nombre al objeto
            Nombre = nombre;

            // Asigna el valor de la edad al objeto
            Edad = edad;

            // Asigna el valor del teléfono al objeto
            Telefono = telefono;
        }

        // Método para mostrar la información del paciente en consola
        public void MostrarInfo()
        {
            // Escribe en la consola el nombre, edad y teléfono del paciente
            Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Teléfono: {Telefono}");
        }
    }

    // Clase principal del programa
    class Program
    {
        // Vector para almacenar pacientes, con capacidad máxima de 100
        static Paciente[] pacientes = new Paciente[100];

        // Contador que indica cuántos pacientes se han registrado actualmente
        static int contadorPacientes = 0;

        // Matriz de turnos, 7 días x 8 horarios por día
        static string[,] turnos = new string[7, 8];

        // Vector que almacena los horarios reales de los turnos
        static string[] horarios = { "08:00", "09:00", "10:00", "11:00", "12:00", "14:00", "15:00", "16:00" };

        // Vector que almacena los nombres de los días de la semana
        static string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };

        // Método principal que se ejecuta al iniciar el programa
        static void Main(string[] args)
        {
            int opcion; // Variable que almacena la opción seleccionada por el usuario

            do
            {
                // Muestra el menú principal en consola
                Console.WriteLine("\n--- Agenda de Turnos de Pacientes ---");
                Console.WriteLine("1. Registrar paciente");
                Console.WriteLine("2. Modificar paciente");
                Console.WriteLine("3. Eliminar paciente");
                Console.WriteLine("4. Asignar turno");
                Console.WriteLine("5. Modificar turno");
                Console.WriteLine("6. Eliminar turno");
                Console.WriteLine("7. Consultar turnos");
                Console.WriteLine("8. Mostrar pacientes");
                Console.WriteLine("9. Salir");

                // Solicita al usuario que ingrese una opción
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine()); // Lee la opción y la convierte a entero

                // Evalúa la opción seleccionada por el usuario
                switch (opcion)
                {
                    case 1:
                        RegistrarPaciente(); // Llama al método para registrar un nuevo paciente
                        break;
                    case 2:
                        ModificarPaciente(); // Llama al método para modificar un paciente existente
                        break;
                    case 3:
                        EliminarPaciente(); // Llama al método para eliminar un paciente
                        break;
                    case 4:
                        AsignarTurno(); // Llama al método para asignar un turno
                        break;
                    case 5:
                        ModificarTurno(); // Llama al método para modificar un turno existente
                        break;
                    case 6:
                        EliminarTurno(); // Llama al método para eliminar un turno
                        break;
                    case 7:
                        ConsultarTurnos(); // Llama al método para mostrar todos los turnos
                        break;
                    case 8:
                        MostrarPacientes(); // Llama al método para mostrar la lista de pacientes
                        break;
                    case 9:
                        Console.WriteLine("Saliendo del sistema..."); // Mensaje de salida
                        break;
                    default:
                        Console.WriteLine("Opción no válida."); // Mensaje si el usuario ingresa una opción incorrecta
                        break;
                }

            } while (opcion != 9); // El menú se repetirá hasta que el usuario elija salir
        }

        // Método para registrar un nuevo paciente
        static void RegistrarPaciente()
        {
            // Verifica si se ha alcanzado el límite de pacientes
            if (contadorPacientes >= pacientes.Length)
            {
                Console.WriteLine("Límite de pacientes alcanzado.");
                return; // Sale del método si no se puede registrar más pacientes
            }

            // Solicita el nombre del paciente
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();

            // Solicita la edad del paciente y la convierte a entero
            Console.Write("Ingrese edad: ");
            int edad = int.Parse(Console.ReadLine());

            // Solicita el teléfono del paciente
            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine();

            // Crea un nuevo objeto Paciente y lo agrega al vector
            pacientes[contadorPacientes] = new Paciente(nombre, edad, telefono);

            // Incrementa el contador de pacientes
            contadorPacientes++;

            Console.WriteLine("Paciente registrado exitosamente."); // Mensaje de confirmación
        }

        // Método para modificar los datos de un paciente existente
        static void ModificarPaciente()
        {
            // Muestra la lista de pacientes registrados
            MostrarPacientes();

            // Solicita el índice del paciente a modificar
            Console.Write("Ingrese el índice del paciente a modificar: ");
            int index = int.Parse(Console.ReadLine());

            // Verifica si el índice es válido
            if (index < 0 || index >= contadorPacientes)
            {
                Console.WriteLine("Índice no válido.");
                return;
            }

            // Solicita y actualiza el nombre del paciente
            Console.Write("Ingrese nuevo nombre: ");
            pacientes[index].Nombre = Console.ReadLine();

            // Solicita y actualiza la edad del paciente
            Console.Write("Ingrese nueva edad: ");
            pacientes[index].Edad = int.Parse(Console.ReadLine());

            // Solicita y actualiza el teléfono del paciente
            Console.Write("Ingrese nuevo teléfono: ");
            pacientes[index].Telefono = Console.ReadLine();

            Console.WriteLine("Paciente modificado exitosamente."); // Mensaje de confirmación
        }

        // Método para eliminar un paciente
        static void EliminarPaciente()
        {
            // Muestra la lista de pacientes
            MostrarPacientes();

            // Solicita el índice del paciente a eliminar
            Console.Write("Ingrese el índice del paciente a eliminar: ");
            int index = int.Parse(Console.ReadLine());

            // Verifica que el índice sea válido
            if (index < 0 || index >= contadorPacientes)
            {
                Console.WriteLine("Índice no válido.");
                return;
            }

            // Desplaza todos los pacientes después del índice hacia atrás
            for (int i = index; i < contadorPacientes - 1; i++)
            {
                pacientes[i] = pacientes[i + 1];
            }

            // Elimina la referencia del último paciente
            pacientes[contadorPacientes - 1] = null;

            // Decrementa el contador de pacientes
            contadorPacientes--;

            // Elimina los turnos asociados a este paciente
            for (int d = 0; d < 7; d++)
            {
                for (int h = 0; h < 8; h++)
                {
                    if (turnos[d, h] == pacientes[index]?.Nombre)
                        turnos[d, h] = null;
                }
            }

            Console.WriteLine("Paciente eliminado exitosamente."); // Mensaje de confirmación
        }

        // Método para asignar un turno a un paciente
        static void AsignarTurno()
        {
            // Muestra la lista de pacientes para seleccionar
            MostrarPacientes();
            Console.Write("Ingrese el índice del paciente: ");
            int pacienteIndex = int.Parse(Console.ReadLine());

            // Verifica que el índice sea válido
            if (pacienteIndex < 0 || pacienteIndex >= contadorPacientes)
            {
                Console.WriteLine("Índice no válido.");
                return;
            }

            // Solicita el día para asignar el turno
            Console.Write("Ingrese día del turno (0 = Lunes, 6 = Domingo): ");
            int dia = int.Parse(Console.ReadLine());
            if (dia < 0 || dia > 6)
            {
                Console.WriteLine("Día no válido.");
                return;
            }

            // Busca automáticamente el primer horario disponible
            int horarioDisponible = -1;
            for (int h = 0; h < 8; h++)
            {
                if (turnos[dia, h] == null) // Verifica si el horario está libre
                {
                    horarioDisponible = h; // Guarda el índice del horario disponible
                    break; // Sale del bucle una vez que encuentra horario
                }
            }

            // Verifica si se encontró un horario disponible
            if (horarioDisponible == -1)
            {
                Console.WriteLine("No hay horarios disponibles ese día.");
            }
            else
            {
                // Asigna el paciente al horario disponible
                turnos[dia, horarioDisponible] = pacientes[pacienteIndex].Nombre;
                Console.WriteLine($"Turno asignado a las {horarios[horarioDisponible]} el día {diasSemana[dia]}.");
            }
        }

        // Método para modificar un turno existente
        static void ModificarTurno()
        {
            // Muestra los turnos actuales
            ConsultarTurnos();

            // Solicita el día y horario del turno a modificar
            Console.Write("Ingrese día del turno a modificar (0-6): ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Ingrese horario a modificar (0-7): ");
            int horario = int.Parse(Console.ReadLine());

            // Verifica si existe un turno en ese horario
            if (turnos[dia, horario] == null)
            {
                Console.WriteLine("No hay turno en ese horario.");
                return;
            }

            // Muestra los pacientes disponibles
            MostrarPacientes();
            Console.Write("Ingrese el nuevo índice de paciente para el turno: ");
            int pacienteIndex = int.Parse(Console.ReadLine());

            // Verifica que el índice sea válido
            if (pacienteIndex < 0 || pacienteIndex >= contadorPacientes)
            {
                Console.WriteLine("Índice no válido.");
                return;
            }

            // Asigna el nuevo paciente al turno seleccionado
            turnos[dia, horario] = pacientes[pacienteIndex].Nombre;
            Console.WriteLine("Turno modificado exitosamente."); // Mensaje de confirmación
        }

        // Método para eliminar un turno
        static void EliminarTurno()
        {
            // Muestra los turnos actuales
            ConsultarTurnos();

            // Solicita el día y horario del turno a eliminar
            Console.Write("Ingrese día del turno a eliminar (0-6): ");
            int dia = int.Parse(Console.ReadLine());
            Console.Write("Ingrese horario a eliminar (0-7): ");
            int horario = int.Parse(Console.ReadLine());

            // Verifica si existe un turno en ese horario
            if (turnos[dia, horario] == null)
            {
                Console.WriteLine("No hay turno en ese horario.");
                return;
            }

            // Elimina el turno
            turnos[dia, horario] = null;
            Console.WriteLine("Turno eliminado exitosamente."); // Mensaje de confirmación
        }

        // Método para mostrar todos los turnos de la semana
        static void ConsultarTurnos()
        {
            Console.WriteLine("\n--- Turnos de la Semana ---");

            // Recorre los 7 días de la semana
            for (int d = 0; d < 7; d++)
            {
                Console.WriteLine($"\n{diasSemana[d]}:"); // Muestra el nombre del día

                // Recorre los 8 horarios de cada día
                for (int h = 0; h < 8; h++)
                {
                    // Si el turno está vacío, muestra "Disponible", si no, el nombre del paciente
                    string paciente = turnos[d, h] ?? "Disponible";
                    Console.WriteLine($"  {horarios[h]}: {paciente}"); // Muestra horario y paciente
                }
            }
        }

        // Método para mostrar todos los pacientes registrados
        static void MostrarPacientes()
        {
            if (contadorPacientes == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return; // Sale si no hay pacientes
            }

            Console.WriteLine("\n--- Lista de Pacientes ---");

            // Recorre todos los pacientes registrados
            for (int i = 0; i < contadorPacientes; i++)
            {
                Console.Write($"{i}. "); // Muestra el índice del paciente
                pacientes[i].MostrarInfo(); // Llama al método MostrarInfo() de cada paciente
            }
        }
    }
}
