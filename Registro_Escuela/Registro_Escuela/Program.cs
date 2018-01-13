using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_Escuela
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu men = new Menu();

        }
    }

    class Menu
    {
        Registro_Estudiante Registro = new Registro_Estudiante();
        int Seleccion = 0;

        public Menu()
        {
            do
            {
               
                Console.Title = "Registro de la escuela MARIA SE LA TRAGA";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1- Registrar Estudiante.\r\n2- Consulta informacion de estudiante.\r\n3- Registrar Calificaciones de estudiantes.\r\n4- Consultar Calificaciones de estudiante.\r\n0- Para Salir.");
                Seleccion = int.Parse(Console.ReadLine());
                switch (Seleccion)
                {
                    case 1:
                        Registro.Guardar_Estudiante();
                        break;
                    case 2:
                        Registro.Consultar_Estudiante();
                        break;
                    case 3:
                        Registro.Registrar_Notas();
                        break;
                    case 4:
                        Registro.Consultar_Notas();
                        break;
                }

            } while (Seleccion != 0);
        }
    }
    class Registro_Estudiante
    {
        List<Estudiante> Lista_Estudiante = new List<Estudiante>();
        Estudiante _estudiante = null;

        List<Materias> Lista_Materias = new List<Materias>();
        Materias materias_ = null;

        public void Guardar_Estudiante()
        {
            _estudiante = new Estudiante();
            materias_ = new Materias();

            Console.Title = "Registro De Nuevo Estudiante";

            Console.Clear();
            Console.Write("Nombre estudiante: ");
            _estudiante.Nombre = Console.ReadLine().ToUpper();
            Console.Write("Apellido del estudiante: ");
            _estudiante.Apellido = Console.ReadLine().ToUpper();
            Console.Write("Edad del estudiante: ");
            _estudiante.Edad = Console.ReadLine().ToUpper();
            Console.Write("Matricula del estudiante: ");
            _estudiante.Matricula = Console.ReadLine().ToUpper();

            materias_.Matricula = Copiar_Valor(_estudiante.Matricula);
            materias_.Español = string.Empty;
            materias_.Matematicas = string.Empty;
            materias_.Fisica = string.Empty;
            materias_.Quimica = string.Empty;

            Console.Write("Grado que va cursando el estudiante: ");
            _estudiante.Grado = Console.ReadLine().ToUpper();
            _estudiante.Estado = "N/D";
            Console.Clear();
            Lista_Estudiante.Add(_estudiante);
            Lista_Materias.Add(materias_);
            Console.Write("Estudiante Registrado.");
            Console.ReadKey();
        }
        public void Consultar_Estudiante()
        {
            Console.Clear();
            Console.Title = "Busqueda De Estudiante Registrado";
            string nombre = string.Empty;
            Console.Write("\n");

            if (Lista_Estudiante.Count > 0)
            {
                Console.Write("Nombre del estudiante: ");
                nombre = Console.ReadLine().ToUpper();
                //Console.Clear();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {

                    //Console.Clear();

                    ex++;

                    if (Lista_Estudiante[x].Nombre != nombre && ex == Lista_Estudiante.Count && encontrado != true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se encontro ningun estudiante registrado con ese nombre.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                    }

                    if (Lista_Estudiante[x].Nombre == nombre)
                    {
                        //Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("===================================================");
                        Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                        Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                        Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                        Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);
                        Console.WriteLine("===================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                        encontrado = true;
                    }

                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay alumnos registrados todavia.");
                Console.ReadKey();
            }
        }
        public void Registrar_Notas()
        {
            Console.Clear();
            materias_ = new Materias();
            Console.Title = "Registro De Calificaciones";

            string matricula_ = string.Empty;

            if (Lista_Estudiante.Count > 0)
            {
                Console.WriteLine("Digite la matricula del estudiante:");
                matricula_ = Console.ReadLine().ToUpper();

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
                    if (Lista_Materias[x].Matricula == matricula_)
                    {
                        Console.Clear();
                        Console.WriteLine("Matricula del Estudiante: {0}", Lista_Materias[x].Matricula);
                        Console.WriteLine("Digite la calificacion de Español: ");
                        Lista_Materias[x].Español = Console.ReadLine();
                        Console.WriteLine("Digite la calificacion de Matematicas: ");
                        Lista_Materias[x].Matematicas = Console.ReadLine();
                        Console.WriteLine("Digite la calificacion de Fisica: ");
                        Lista_Materias[x].Fisica = Console.ReadLine();
                        Console.WriteLine("Digite la calificacion de Quimica");
                        Lista_Materias[x].Quimica = Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("MATRICULA NO ENCONTRADA: ");
                        Console.ReadKey();
                    }
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aun no se han registrado estudiantes.");
                Console.ReadKey();
            }

        }
        public void Consultar_Notas()
        {
            Console.Clear();
            Console.Title = "Consulta de Notas";

            string matricula = string.Empty;

            if (Lista_Materias.Count > 0)
            {
                Console.Write("Digite la matricula: ");
                matricula = Console.ReadLine().ToUpper();

                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    if (Lista_Materias[x].Matricula == matricula)
                    {
                        Console.Clear();
                        Console.WriteLine("Calificaciones.");
                        Console.Write("Matricula del Estudiante: {0}", Lista_Materias[x].Matricula);
                        Console.Write("Nota Español: {0}", Lista_Materias[x].Español);
                        Console.Write("Nota de Matematicas: {0}", Lista_Materias[x].Matematicas);
                        Console.Write("Nota de Fisica: {0}", Lista_Materias[x].Fisica);
                        Console.Write("Nota de Quimica", Lista_Materias[x].Quimica);
                        Console.Write("Promedio", materias_.Promedio(Convert.ToDouble(Lista_Materias[x].Español), Convert.ToDouble(Lista_Materias[x].Matematicas), Convert.ToDouble(Lista_Materias[x].Fisica), Convert.ToDouble(Lista_Materias[x].Quimica)));
                    }
                    else
                    {
                        Console.WriteLine("MATRICULA NO ENCONTRADA: ");
                        Console.ReadKey();
                    }
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Aun no se han registrado estudiantes.");
                Console.ReadKey();
            }
        }
        public static string Copiar_Valor(string valor)
        {
            string cadena = valor;

            return cadena;
        }

    }
    class Estudiante
    {
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Edad { set; get; }
        public string Matricula { set; get; }
        public string Grado { set; get; }
        public string Estado { set; get; }
    }
    class Materias
    {
        public string Matricula { set; get; }
        public string Español { set; get; }
        public string Matematicas { set; get; }
        public string Fisica { set; get; }
        public string Quimica { set; get; }

        public double Promedio(double Español, double Matematicas, double Fisica, double Quimica)
        {
            double _promerdio = (Español + Matematicas + Fisica + Quimica) / 4;

            return _promerdio;
        }
        public void Estado(double promedio_)
        {
            string estado_;
            if (Convert.ToDouble(promedio_) >= 71)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                estado_ = "APROVADO";
                Console.WriteLine("{0}", estado_);
            }
            else
                if (Convert.ToDouble(promedio_) <= 70)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                estado_ = "REPROVADO";
                Console.WriteLine("{0}", estado_);
            }
        }
    }
}
