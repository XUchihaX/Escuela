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
            Menu men_U = new Menu();
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
                Console.Title = "Registro de la escuela";
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1- REGISTRAR ESTUDIANTE.\r\n2- MODIFICAR INFORMACION DE ESTUDIANTE.\r\n3- CONSULTAR INFORMACION DE ESTUDIANTE.\r\n4- CONSULTAR INFORMACION DE TODOS LOS ESTUDIANTES REGISTRADOS.\r\n5- REGISTRAR CALIFICACIONES DE ESTUDIANTE.\r\n6- CONSULTAR INFORMACION DE ESTUDIANTE.\r\n7- CONSULTAR CALIFICACIONES DE TODOS LOS ESTUDIANTES.\r\n0- PARA SALIR.");

                while (!int.TryParse(Console.ReadLine(), out Seleccion))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Solo se puede hacer la seleccion con numeros.");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1- REGISTRAR ESTUDIANTE.\r\n2- MODIFICAR INFORMACION DE ESTUDIANTE.\r\n3- CONSULTAR INFORMACION DE ESTUDIANTE.\r\n4- CONSULTAR INFORMACION DE TODOS LOS ESTUDIANTES REGISTRADOS.\r\n5- REGISTRAR CALIFICACIONES DE ESTUDIANTE.\r\n6- CONSULTAR INFORMACION DE ESTUDIANTE.\r\n7- CONSULTAR CALIFICACIONES DE TODOS LOS ESTUDIANTES.\r\n0- PARA SALIR.");
                }

                if (Seleccion != 1 && Seleccion != 2 && Seleccion != 3 && Seleccion != 4 && Seleccion != 5 && Seleccion != 6 && Seleccion != 7 && Seleccion != 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcion no valida, vuelva a introducir otra opcion!!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                switch (Seleccion)
                {
                    case 1:
                        Registro.Registrar_Estudiante();
                        break;
                    case 2:
                        Registro.Editar_Estudiante();
                        break;
                    case 3:
                        Registro.Consultar_Estudiante();
                        break;
                    case 4:
                        Registro.Consultar_Estudiantes_Todos();
                        break;
                    case 5:
                        Registro.Registrar_Calificaciones();
                        break;
                    case 6:
                        Registro.Consultar_Notas();
                        break;
                    case 7:
                        Registro.Consultar_Notas_Todas();
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

        public void Registrar_Estudiante()
        {
            string Respuesta = "SI";
            do
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
                Console.WriteLine("Matricula del estudiante: {0}", _estudiante.Matricula = _estudiante.Nombre[0].ToString() + _estudiante.Apellido[0].ToString() + _estudiante.Edad);

                materias_.Matricula += _estudiante.Matricula;
                materias_.Español = 0;
                materias_.Matematicas = 0;
                materias_.Fisica = 0;
                materias_.Quimica = 0;
                materias_.Promedio = 0;

                Console.Write("Grado que va cursando el estudiante: ");
                _estudiante.Grado = Console.ReadLine().ToUpper();
                _estudiante.Estado = "N/D";
                Console.Clear();

                Lista_Estudiante.Add(_estudiante);
                Lista_Materias.Add(materias_);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Estudiante Registrado Satisfactoriamente.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ReadKey();
                Console.WriteLine("Desea Registrar otro estudiante? SI/NO");
                Respuesta = Console.ReadLine().ToUpper();

                while(Respuesta != "SI" && Respuesta != "NO")
                {
                    Console.WriteLine("Solo puede responder: SI o NO");
                    Respuesta = Console.ReadLine().ToUpper();
                }

                Console.Clear();
            } while (Respuesta != "NO");
        }
        public void Editar_Estudiante()
        {
            Console.Clear();
            Console.Title = "Modificar Informacion De Estudiante";

            string nombre = string.Empty;

            Console.Write("\n");
            if(Lista_Estudiante.Count > 0)
            {
                Console.Write("Digite el nombre del estudiante: ");
                nombre = Console.ReadLine().ToUpper();
                
                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
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
                        encontrado = true;

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Datos del estudiante que se van a modificar.");
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                        Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                        Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                        Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);

                        if (Lista_Materias[x].Promedio >= 70)
                        {
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        }
                        else
                            if (Lista_Materias[x].Promedio <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");

                        Console.WriteLine("Ingrese datos actualizados.");
                        Console.Write("Nombre estudiante: ");
                        Lista_Estudiante[x].Nombre = Console.ReadLine().ToUpper();
                        Console.Write("Apellido del estudiante: ");
                        Lista_Estudiante[x].Apellido = Console.ReadLine().ToUpper();
                        Console.Write("Edad del estudiante: ");
                        Lista_Estudiante[x].Edad = Console.ReadLine().ToUpper();
                        Console.WriteLine("Matricula del estudiante: {0}", Lista_Estudiante[x].Matricula = Lista_Estudiante[x].Nombre[0].ToString() + Lista_Estudiante[x].Apellido[0].ToString() + Lista_Estudiante[x].Edad);
                        Console.Write("Grado que va cursando el estudiante: ");
                        Lista_Estudiante[x].Grado = Console.ReadLine().ToUpper();

                        Lista_Materias[x].Matricula = string.Empty;
                        Lista_Materias[x].Matricula += Lista_Estudiante[x].Matricula;
                        Lista_Materias[x].Español = 0;
                        Lista_Materias[x].Matematicas = 0; 
                        Lista_Materias[x].Fisica = 0;
                        Lista_Materias[x].Quimica = 0;
                        Lista_Materias[x].Promedio = 0;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Datos modificados satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
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

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
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
                        encontrado = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                        Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                        Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                        Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);

                        if (Lista_Materias[x].Promedio >= 70)
                        {
                            Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                        }
                        else
                            if (Lista_Materias[x].Promedio <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.Write("\n");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Consultar_Estudiantes_Todos()
        {
            Console.Clear();
            Console.Title = "Todos los estudiantes registrados";
            Console.Write("\n");

            if (Lista_Estudiante.Count > 0)
            {
                for (int x = 0; x < Lista_Estudiante.Count; x++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("================================================================");
                    Console.WriteLine("Matricula : {0}", Lista_Estudiante[x].Matricula);
                    Console.WriteLine("Nombre    : {0}", Lista_Estudiante[x].Nombre);
                    Console.WriteLine("Apellido  : {0}", Lista_Estudiante[x].Apellido);
                    Console.WriteLine("Edad      : {0}", Lista_Estudiante[x].Edad);
                    Console.WriteLine("Grado     : {0}", Lista_Estudiante[x].Grado);

                    if (Lista_Materias[x].Promedio >= 70)
                    {
                        Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                    }
                    else
                        if (Lista_Materias[x].Promedio <= 69)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estado    : {0}", Lista_Estudiante[x].Estado);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("================================================================");
                    Console.Write("\n");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }

        }
        public void Registrar_Calificaciones()
        {
            Console.Clear();
            Console.Title = "Registro De Calificaciones";

            string matricula_ = string.Empty;
            Console.Write("\n");

            if (Lista_Materias.Count > 0)
            {
                Console.Write("Digite la matricula del estudiante: ");
                matricula_ = Console.ReadLine().ToUpper();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    ex++;

                    if (Lista_Materias[x].Matricula != matricula_ && ex == Lista_Materias.Count && encontrado != true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("MATRICULA NO ENCONTRADA. ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    if (Lista_Materias[x].Matricula == matricula_)
                    {
                        encontrado = true;
                        double Numero = 0;
                        Console.WriteLine("Matricula del Estudiante: {0}", Lista_Materias[x].Matricula);

                        Console.Write("Digite la calificacion de Español: ");
                        do
                        {
                            while (!double.TryParse(Console.ReadLine(), out Numero))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Solo se pueden introducir numeros.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Español: ");
                            }
                            Lista_Materias[x].Español = Numero;

                            if(Lista_Materias[x].Español >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Calificacion no valida, la calificacion no puede ser mayor a 100.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Español: ");
                            }
                        } while (Lista_Materias[x].Español >= 101);


                        Console.Write("Digite la calificacion de Matematicas: ");
                        do
                        {
                            while (!double.TryParse(Console.ReadLine(), out Numero))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Solo se pueden introducir numeros.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Matematicas: ");
                            }
                            Lista_Materias[x].Matematicas = Numero;

                            if (Lista_Materias[x].Matematicas >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Calificacion no valida, la calificacion no puede ser mayor a 100.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Matematicas: ");
                            }
                        } while (Lista_Materias[x].Matematicas >= 101);

                        Console.Write("Digite la calificacion de Fisica: ");
                        do
                        {
                            while (!double.TryParse(Console.ReadLine(), out Numero))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Solo se pueden introducir numeros.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Fisica: ");
                            }
                            Lista_Materias[x].Fisica = Numero;

                            if (Lista_Materias[x].Fisica >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Calificacion no valida, la calificacion no puede ser mayor a 100.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Fisica: ");
                            }
                        } while (Lista_Materias[x].Fisica >= 101);

                        Console.Write("Digite la calificacion de Quimica: ");
                        do
                        {
                            while (!double.TryParse(Console.ReadLine(), out Numero))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Solo se pueden introducir numeros.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Quimica: ");
                            }
                            Lista_Materias[x].Quimica = Numero;

                            if (Lista_Materias[x].Quimica >= 101)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Calificacion no valida, la calificacion no puede ser mayor a 100.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("Digite la calificacion de Quimica: ");
                            }
                        } while (Lista_Materias[x].Quimica >= 101);

                        Lista_Materias[x].Promedio = Materias.Promediar(Lista_Materias[x].Español, Lista_Materias[x].Matematicas, Lista_Materias[x].Fisica, Lista_Materias[x].Quimica);

                        if (Lista_Materias[x].Promedio >= 70)
                        {
                            Lista_Estudiante[x].Estado = "APROBADO";
                        }
                        else
                            if (Lista_Materias[x].Promedio <= 69)
                        {
                            Lista_Estudiante[x].Estado = "REPROBADO";
                        }

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Calificaciones Registradas Satisfactoriamente.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Consultar_Notas()
        {
            Console.Clear();
            Console.Title = "Consulta de Notas";

            string matricula = string.Empty;

            Console.Write("\n");

            if (Lista_Materias.Count > 0)
            {
                Console.Write("Digite la matricula: ");
                matricula = Console.ReadLine().ToUpper();

                int ex = 0;
                bool encontrado = false;

                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    ex++;
                    if (Lista_Materias[x].Matricula != matricula && ex == Lista_Materias.Count && encontrado != true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("NO SE ENCONTRO NINGUN ESTUDIANTE CON ESA MATRICULA.");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n");
                    }

                    if (Lista_Materias[x].Matricula == matricula)
                    {
                        Console.Clear();
                        encontrado = true;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("================================================================");
                        Console.WriteLine("Calificaciones.");
                        Console.WriteLine("Matricula del Estudiante : {0}", Lista_Materias[x].Matricula);
                        Console.WriteLine("Nombre Completo          : {0} {1}", Lista_Estudiante[x].Nombre, Lista_Estudiante[x].Apellido);
                        Console.WriteLine("Nota Español             : {0}", Lista_Materias[x].Español);
                        Console.WriteLine("Nota de Matematicas      : {0}", Lista_Materias[x].Matematicas);
                        Console.WriteLine("Nota de Fisica           : {0}", Lista_Materias[x].Fisica);
                        Console.WriteLine("Nota de Quimica          : {0}", Lista_Materias[x].Quimica);
                        Console.WriteLine("Promedio                 : {0}", Lista_Materias[x].Promedio);

                        if (Lista_Materias[x].Promedio >= 70 )
                        {
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        }
                        else
                            if(Lista_Materias[x].Promedio <= 69)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        Console.WriteLine("================================================================");
                        Console.ReadKey();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
        }
        public void Consultar_Notas_Todas()
        {
            Console.Clear();
            Console.Title = "Calificaciones de todos los estudiantes registrados";

            if(Lista_Materias.Count > 0)
            {
                for (int x = 0; x < Lista_Materias.Count; x++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("================================================================");
                    Console.WriteLine("Calificaciones.");
                    Console.WriteLine("Matricula del Estudiante : {0}", Lista_Materias[x].Matricula);
                    Console.WriteLine("Nombre Completo          : {0} {1}", Lista_Estudiante[x].Nombre, Lista_Estudiante[x].Apellido);
                    Console.WriteLine("Nota Español             : {0}", Lista_Materias[x].Español);
                    Console.WriteLine("Nota de Matematicas      : {0}", Lista_Materias[x].Matematicas);
                    Console.WriteLine("Nota de Fisica           : {0}", Lista_Materias[x].Fisica);
                    Console.WriteLine("Nota de Quimica          : {0}", Lista_Materias[x].Quimica);
                    Console.WriteLine("Promedio                 : {0}", Lista_Materias[x].Promedio);

                    if (Lista_Materias[x].Promedio >= 70)
                    {
                        Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                    }
                    else
                        if (Lista_Materias[x].Promedio <= 69)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Estado                   : {0} ", Lista_Estudiante[x].Estado);
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("================================================================");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO HAY ESTUDIANTES REGISTRADOS.");
            }
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
        public double Español { set; get; }
        public double Matematicas { set; get; }
        public double Fisica { set; get; }
        public double Quimica { set; get; }
        public double Promedio { set; get; }

        public static double Promediar(double Español, double Matematicas, double Fisica, double Quimica)
        {
            double _promedio = (Español + Matematicas + Fisica + Quimica) / 4;

            return _promedio;
        }
    }
}